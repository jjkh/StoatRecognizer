using Emgu.CV;
using Emgu.CV.BgSegm;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.VideoSurveillance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoatRecognizer
{
    public partial class SequenceViewer : Form
    {
        string[] _sequences;
        List<Image<Gray, Byte>> _seqImages;
        BackgroundSubtractorMOG2 _subMog2;

        int _currSequence = 0;
        int _currImage = 0;

        string _sequencesPath = @"C:\Users\Jamie\Desktop\source\StoatRecognizer\StoatRecognizer\images\sequences";
        string _templatePath = @"C:\Users\Jamie\Desktop\source\StoatRecognizer\StoatRecognizer\images\templates\stoat.bmp";
        
        List<PathHistory> _paths = new List<PathHistory>();

        public SequenceViewer()
        {
            _seqImages = new List<Image<Gray, byte>>();

            InitializeComponent();
        }

        private void SequenceViewer_Load(object sender, EventArgs e)
        {
            _sequences = Directory.GetDirectories(_sequencesPath);
            UpdateSequence();
        }

        // loads in a new sequence of images, median blurring them
        private void UpdateSequence()
        {
            sequenceLbl.Text = "Sequence " + (_currSequence + 1);
            foreach (var image in _seqImages)
                image.Dispose();
            _seqImages.Clear();

            if (_subMog2 != null)
                _subMog2.Dispose();
            _subMog2 = new BackgroundSubtractorMOG2();

            foreach (var imagePath in Directory.GetFiles(_sequences[_currSequence]))
                _seqImages.Add(new Image<Gray, byte>(imagePath).SmoothMedian(5));

            _paths.Clear();
            _paths.Add(new PathHistory());
            _currImage = 0;
            UpdateImage();
        }

        // updates the display image - image processing happens here
        private void UpdateImage()
        {
            imageLbl.Text = "Image " + (_currImage + 1);

            var tempImg = _seqImages[_currImage].Copy();
            
            Image<Gray, Byte> fgMask = _seqImages[_currImage].CopyBlank();
            // apply the first image and the current image to the background subtractor
            // this helps to detect stationary objects while still taking into account the last frame
            _subMog2.Apply(_seqImages[0], fgMask);
            _subMog2.Apply(tempImg, fgMask);
            
            // makes a BGR display image so coloured lines can be drawn
            var dispImg = _seqImages[_currImage].Convert<Bgr, Byte>();

            // find contours based on the movement detected by background subtractor
            var maskContours = new VectorOfVectorOfPoint();
            // eroded once to remove noise, dilated 6 times to blobs of larger contours
            CvInvoke.FindContours(fgMask.Erode(1).Dilate(6), maskContours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            // iterate through the contours, finding the largest one within thresholds
            int biggestContour = -1;
            double contourSize = 0, currSize, simularity;
            for (int i = 0; i < maskContours.Size; i++)
            {
                currSize = CvInvoke.ContourArea(maskContours[i]);
                if (currSize > contourSize && currSize > 600 && currSize < 6000)
                {
                    biggestContour = i;
                    contourSize = currSize;
                }
            }

            // if a contour exists
            if (biggestContour != -1)
            {
                // get the contours of the template for matching
                VectorOfVectorOfPoint tempContours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(new Image<Gray, Byte>(_templatePath).Not(), tempContours, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                // match contour with template using Hu moments
                simularity = CvInvoke.MatchShapes(maskContours[biggestContour], tempContours[0], Emgu.CV.CvEnum.ContoursMatchType.I1);
                
                // find the centre of the contour for drawing lines
                var newPosition = GetContourCentroid(maskContours[biggestContour]);
                // update the path history
                UpdateTrail(newPosition, simularity);

                // display the trail and simularities on the output image
                dispImg = DrawTrail(dispImg);

                // draw on a rotated bounding rect and the centre of the contour
                dispImg.Draw(CvInvoke.MinAreaRect(maskContours[biggestContour]), new Bgr(0, 255, 0), 2);
                dispImg.Draw(new CircleF(newPosition, 2), new Bgr(0, 255, 0), 2);
            }
            // if no contour exists
            else
            {
                dispImg = DrawTrail(dispImg);
                
                // end the current path
                if (_paths.Last().Points.Count > 0)
                    _paths.Add(new PathHistory());
            }

            // put this on the screen
            picBox.Image = dispImg.ToBitmap();
        }

        private void UpdateTrail(PointF newPos, double simularity)
        {
            // if the current path has no points, add the new point without processing
            if (_paths.Last().Points.Count > 0)
            {
                // get the point immediately preceding the new one
                var oldPos = _paths.Last().Points.Last();
                // get the distance between the two points using pythagoras
                var dist = Math.Sqrt(Math.Pow(newPos.X - oldPos.X, 2) + Math.Pow(newPos.Y - oldPos.Y, 2));

                // if this distance is too large, it's probably noise
                // don't add the point and start a new trail
                if (dist > 250)
                {
                    _paths.Add(new PathHistory());
                    return;
                }
                else
                {
                    var currPath = _paths.Last().Points;
                    double largestDist = -1;

                    // otherwise, if the path has 3 or more points
                    if (currPath.Count > 2)
                    {
                        // iterate through each pair of points, finding the biggest distance between them
                        for (int i = 1; i < currPath.Count - 1; i++)
                        {
                            var movement = Math.Sqrt(Math.Pow(currPath[i].X - currPath[i - 1].X, 2) + Math.Pow(currPath[i].Y - currPath[i - 1].Y, 2));
                            if (movement > largestDist)
                                largestDist = movement;
                        }
                        // if the distance between the new point and the last is twice that of the previous largest distance,
                        // don't add the point and create a new trail
                        if (dist > largestDist * 2)
                        {
                            _paths.Add(new PathHistory());
                            return;
                        }
                    }
                }
            }

            // if the end of the function has been reached, the point is valid
            // add the point's position and update the simularity if it is smaller than previous
            _paths.Last().Points.Add(newPos);
            _paths.Last().UpdateSimularity(simularity);
        }

        private Image<Bgr, Byte> DrawTrail(Image<Bgr, Byte> map)
        {
            var rnd = new Random();

            // add a dark rectangle down the bottom so text is visible
            var overlayMap = map.Copy();
            overlayMap.Draw(new Rectangle(0, map.Height - 40, map.Width, 40), new Bgr(0, 0, 0), -1);
            map = map.AddWeighted(overlayMap, 0.5, 0.5, 0);

            // draw a red line between stoat paths
            int j = 1;
            while (j < _paths.Count)
            {
                if (_paths[j - 1].Points.Count != 0 && _paths[j].Points.Count != 0)
                {
                    map.Draw(new LineSegment2DF(_paths[j - 1].Points.Last(), _paths[j].Points.First()), new Bgr(0, 0, 170), 4);
                }
                j++;

            }

            // draw the paths
            foreach (var path in _paths)
            {
                if (path.Points.Count < 2)
                    continue;

                Bgr lineColour = new Bgr(0, 0, 170);

                if (path.Points.Count > 2)
                {
                    
                    if (path.Simularity < 0.025)
                    {
                        if (path == _paths.Last())
                            map.Draw(String.Format("probably stoat ({0:0.###})", path.Simularity), new Point(10, 470), Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new Bgr(255, 255, 255));
                        lineColour = new Bgr(0, 255, 255);
                    }
                    else if (path.Simularity < 0.35)
                    {
                        if (path == _paths.Last())
                            map.Draw(String.Format("maybe stoat ({0:0.###})", path.Simularity), new Point(10, 470), Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new Bgr(255, 255, 255));
                        lineColour = new Bgr(0, 210, 210);
                    }
                    else
                    {
                        if (path == _paths.Last())
                            map.Draw(String.Format("probably not stoat ({0:0.###})", path.Simularity), new Point(10, 470), Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new Bgr(255, 255, 255));
                        lineColour = new Bgr(0, 160, 160);
                    }
                }
                for (int i = 0; i < path.Points.Count - 1; i++)
                {
                    map.Draw(new LineSegment2DF(path.Points[i], path.Points[i + 1]), lineColour, 4);
                }
            }
            return map; 
        }

        // gets centre of contour using moments
        private PointF GetContourCentroid(VectorOfPoint contour)
        {
            var M = CvInvoke.Moments(contour);
            PointF centre = new PointF((float) (M.M10/ M.M00), (float) (M.M01/M.M00));
            return centre;
        }
        
        // code for navigating sequences
        #region MOVEMENT
        private void prevSequenceBtn_Click(object sender, EventArgs e)
        {
            if (_currSequence == 0)
                return;

            _currSequence--;
            UpdateSequence();
        }

        private void nextSequenceBtn_Click(object sender, EventArgs e)
        {
            if (_currSequence == 6)
                return;

            _currSequence++;
            UpdateSequence();
        }

        private void prevImageBtn_Click(object sender, EventArgs e)
        {
            if (_currImage == 0)
                return;

            _currImage--;
            UpdateImage();
        }

        private void nextImageBtn_Click(object sender, EventArgs e)
        {
            if (_currImage == _seqImages.Count - 1)
                return;

            _currImage++;
            UpdateImage();
        }



        private void SequenceViewer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    prevImageBtn_Click(null, null);
                    break;
                case Keys.Right:
                    nextImageBtn_Click(null, null);
                    break;
            }
            Task.Delay(100).Wait();
        }

        private void SequenceViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        #endregion
    }
    // class to hold the path and the best match along the path
    public class PathHistory
    {
        public double Simularity = 0;
        public List<PointF> Points = new List<PointF>();

        public void UpdateSimularity(double simularity)
        {
            if (simularity < Simularity || Points.Count == 1)
                Simularity = simularity;
        }
    }
}
