using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
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
    public partial class StoatForm : Form
    {
        List<Image<Bgr, byte>> _pics;
        string _exampleDir = @"C:\Users\Jamie\Desktop\source\StoatRecognizer\StoatRecognizer\images\examples";

        public StoatForm()
        {
            InitializeComponent();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (_pics == null)
            {
                _pics = new List<Image<Bgr, byte>>();
                foreach (var pic in Directory.GetFiles(_exampleDir))
                    _pics.Add(new Image<Bgr, byte>(pic));
            }

            UpdatePictureBoxes(_pics);
        }

        private void recognizeBtn_Click(object sender, EventArgs e)
        {
            if (_pics == null)
                return;

            var updatedPics = new List<Image<Bgr, byte>>();

            if (laplaceSlider.Value % 2 == 0)
                return;
            laplaceLabel.Text = laplaceSlider.Value.ToString();
            threshLabel.Text = threshSlider.Value.ToString();

            foreach (var pic in _pics)
                updatedPics.Add(new Image<Bgr, byte>(pic.ToBitmap()));

            Random rnd = new Random();
            foreach (var pic in updatedPics)
            {
                using (var contours = new VectorOfVectorOfPoint())
                {
                    pic.Laplace(laplaceSlider.Value).Convert<Bgr, Byte>().CopyTo(pic);
                    CvInvoke.FindContours(pic.Convert<Gray, byte>().ThresholdBinaryInv(new Gray(threshSlider.Value), new Gray(255)), contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                    for (int i = 0; i < contours.Size; i++)
                        pic.Draw(contours, i, new Bgr(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                }
            }

            UpdatePictureBoxes(updatedPics);
        }

        private void UpdatePictureBoxes(List<Image<Bgr, Byte>> pics)
        {
            var picBoxes = new PictureBox[] { picBox1, picBox2, picBox3, picBox4, picBox5, picBox6, picBox7 };

            for (int i = 0; i < picBoxes.Length; i++)
                picBoxes[i].Image = pics[i].ToBitmap(picBoxes[i].Width, picBoxes[i].Height);
        }

        private void sequenceBtn_Click(object sender, EventArgs e)
        {
            new SequenceViewer().Show();
        }
    }
}
