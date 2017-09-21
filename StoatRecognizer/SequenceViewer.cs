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
            {
                _seqImages.Add(new Image<Gray, byte>(imagePath).SmoothMedian(3));
                _subMog2.Apply(_seqImages[0], fgMask);

                _subMog2.Apply(_seqImages.Last(), fgMask);
            }

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
                tempImg &= fgMask.Erode(1).Dilate(7).Erode(2);

                if (contourChkBox.Checked)
                {
                    var dispImg = tempImg.Convert<Bgr, Byte>();
                    
                    var maskContours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(fgMask.Erode(1).Dilate(8).Erode(1), maskContours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);
                    int biggestContour = -1;
                    double contourSize = 0, currSize;
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
                        dispImg.Draw(maskContours, biggestContour, new Bgr(0, 0, 255), -1);

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
