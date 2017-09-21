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
    public class PathHistory
    {
        public double Simularity = 0;
        public List<PointF> Points = new List<PointF>();
    }

    public partial class SequenceViewer : Form
    {
        string[] _sequences;
        List<Image<Gray, Byte>> _seqImages;
        BackgroundSubtractorMOG2 _subMog2;

        int _currSequence = 0;
        int _currImage = 0;

        string _sequencesPath = @"C:\Users\Hunter\Desktop\ImageAssignTwo";
        string _templatePath = @"C:\Users\Hunter\Desktop\StoatRecognizer\StoatRecognizer\images\templates\stoat.bmp";
        
        
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

        private void UpdateSequence()
        {
            sequenceLbl.Text = "Sequence " + (_currSequence + 1);
            foreach (var image in _seqImages)
                image.Dispose();
            _seqImages.Clear();

            if (_subMog2 != null)
                _subMog2.Dispose();
            _subMog2 = new BackgroundSubtractorMOG2();

            Image<Gray, Byte> fgMask = new Image<Gray, byte>(752, 480);

            foreach (var imagePath in Directory.GetFiles(_sequences[_currSequence]))
                _seqImages.Add(new Image<Gray, byte>(imagePath).SmoothMedian(5));

            miniMap.Image = _seqImages[0].ToBitmap();

            _paths.Clear();
            _paths.Add(new PathHistory());
            _currImage = 0;
            UpdateImage();
        }

        private void UpdateImage()
        {
            imageLbl.Text = "Image " + (_currImage + 1);

            var tempImg = _seqImages[_currImage].Copy();

            if (bgChkBox.Checked)
            {
                Image<Gray, Byte> fgMask = _seqImages[_currImage].CopyBlank();
                _subMog2.Apply(_seqImages[0], fgMask);
                _subMog2.Apply(tempImg, fgMask);

                if (medianChkBox.Checked)
                {
                    if (medianSlider.Value % 2 == 0)
                        return;
                    tempImg = tempImg.SmoothMedian(medianSlider.Value);
                }

                if (cannyChkBox.Checked)
                    tempImg = tempImg.Canny(cannySlider.Value, cannySlider.Value * 3);
                tempImg &= fgMask.Erode(1).Dilate(8).Erode(1);

                if (contourChkBox.Checked)
                {
                    var dispImg = tempImg.Convert<Bgr, Byte>();
                    
                    var maskContours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(fgMask.Erode(1).Dilate(8).Erode(1), maskContours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);
                    int biggestContour = -1;
                    double contourSize = 0, currSize, simularity;
                    VectorOfVectorOfPoint tempContours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(new Image<Gray, Byte>(_templatePath).Not(), tempContours, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                    for (int i = 0; i < maskContours.Size; i++)
                    {
                        currSize = CvInvoke.ContourArea(maskContours[i]);
                        if (currSize > contourSize && currSize > 600 && currSize < 6000)
                        {
                            biggestContour = i;
                            contourSize = currSize;
                        }
                    }
                    contourLbl.Text = "Biggest Contour: " + contourSize;
                    if (biggestContour != -1)
                    { 
                        dispImg.Draw(maskContours, biggestContour, new Bgr(0, 0, 255), -1);
                        // dispImg.Draw(hullContour.ToArray(), new Bgr(255, 255, 255), 1);
                        simularity = CvInvoke.MatchShapes(maskContours[biggestContour], tempContours[0], Emgu.CV.CvEnum.ContoursMatchType.I1);
                        if (simularity < 0.2)
                            dispImg.Draw("stoat", new Point(10, 470), Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new Bgr(255, 255, 255));
                        else if (simularity < 1)
                            dispImg.Draw("maybe stoat", new Point(10, 470), Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new Bgr(255, 255, 255));
                        else 
                            dispImg.Draw("probably not stoat", new Point(10, 470), Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new Bgr(255, 255, 255));
                        
                        var newPosition = GetContourCentroid(maskContours[biggestContour]);
                        dispImg.Draw(new CircleF(newPosition, 2), new Bgr(0, 255, 0), 2);
                        UpdateTrail(newPosition, simularity);
                    }
                    else
                    {
                        if (_paths.Last().Points.Count > 0)
                            _paths.Add(new PathHistory());
                    }
                    picBox.Image = dispImg.ToBitmap();
                    return;
                }
            }     
            picBox.Image = tempImg.ToBitmap();
        }

        private void bgChkBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void cannySlider_Scroll(object sender, EventArgs e)
        {
            cannyLbl.Text = cannySlider.Value.ToString();
            if (cannyChkBox.Checked)
                UpdateImage();
        }

        private void medianSlider_Scroll(object sender, EventArgs e)
        {
            if (medianSlider.Value % 2 == 0)
                return;
            medianLbl.Text = medianSlider.Value.ToString();
            if (medianChkBox.Checked)
                UpdateImage();
        }

        private void UpdateTrail(PointF newPos, double simularity)
        {
            if (_paths.Last().Points.Count > 0)
            {
                var oldPos = _paths.Last().Points.Last();
                var dist = Math.Sqrt(Math.Pow(newPos.X - oldPos.X, 2) + Math.Pow(newPos.Y - oldPos.Y, 2));
                if (dist > 250)
                {
                    _paths.Add(new PathHistory());
                }
                else
                {
                    var currPath = _paths.Last().Points;
                    double largestDist = -1;

                    if (currPath.Count > 2)
                    {
                        for (int i = 1; i < currPath.Count - 1; i++)
                        {
                            var movement = Math.Sqrt(Math.Pow(currPath[i].X - currPath[i - 1].X, 2) + Math.Pow(currPath[i].Y - currPath[i - 1].Y, 2));
                            if (movement > largestDist)
                                largestDist = movement;
                        }
                        if (dist > largestDist * 2)
                        {
                            _paths.Add(new PathHistory());
                        }
                        else
                        {
                            _paths.Last().Points.Add(newPos);
                            _paths.Last().Simularity += simularity;
                        }
                    }
                    else
                    {
                        _paths.Last().Points.Add(newPos);
                    }
                }
            }
            else
            {
                _paths.Last().Points.Add(newPos);
            }

            DrawTrail();
        }

        private void DrawTrail()
        {
            Image<Bgr, Byte> map = _seqImages[0].Convert<Bgr, Byte>();
            var rnd = new Random();

            int j = 1;
            while (j < _paths.Count)
            {
                if (_paths[j - 1].Points.Count != 0 && _paths[j].Points.Count != 0)
                {
                    map.Draw(new LineSegment2DF(_paths[j - 1].Points.Last(), _paths[j].Points.First()), new Bgr(0, 0, 170), 4);
                }
                j++;

            }

            foreach (var path in _paths)
            {
                if (path.Points.Count < 2)
                    continue;

                var lineColour = new Bgr(0, 255, 255);
                for (int i = 0; i < path.Points.Count - 1; i++)
                {
                    map.Draw(new LineSegment2DF(path.Points[i], path.Points[i + 1]), lineColour, 4);
                }
            }
            miniMap.Image = map.ToBitmap();
        }

        private PointF GetContourCentroid(VectorOfPoint contour)
        {
            var M = CvInvoke.Moments(contour);
            PointF centre = new PointF((float) (M.M10/ M.M00), (float) (M.M01/M.M00));
            return centre;
        }
        
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
}
