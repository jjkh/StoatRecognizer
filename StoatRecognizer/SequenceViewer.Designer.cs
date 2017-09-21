namespace StoatRecognizer
{
    partial class SequenceViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox = new System.Windows.Forms.PictureBox();
            this.prevSequenceBtn = new System.Windows.Forms.Button();
            this.sequenceLbl = new System.Windows.Forms.Label();
            this.nextSequenceBtn = new System.Windows.Forms.Button();
            this.imageLbl = new System.Windows.Forms.Label();
            this.prevImageBtn = new System.Windows.Forms.Button();
            this.nextImageBtn = new System.Windows.Forms.Button();
            this.bgChkBox = new System.Windows.Forms.CheckBox();
            this.cannyLbl = new System.Windows.Forms.Label();
            this.cannyChkBox = new System.Windows.Forms.CheckBox();
            this.cannySlider = new System.Windows.Forms.TrackBar();
            this.contourChkBox = new System.Windows.Forms.CheckBox();
            this.medianChkBox = new System.Windows.Forms.CheckBox();
            this.medianLbl = new System.Windows.Forms.Label();
            this.medianSlider = new System.Windows.Forms.TrackBar();
            this.contourLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(12, 76);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1504, 960);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // prevSequenceBtn
            // 
            this.prevSequenceBtn.Location = new System.Drawing.Point(1404, 12);
            this.prevSequenceBtn.Name = "prevSequenceBtn";
            this.prevSequenceBtn.Size = new System.Drawing.Size(53, 54);
            this.prevSequenceBtn.TabIndex = 1;
            this.prevSequenceBtn.Text = "«";
            this.prevSequenceBtn.UseVisualStyleBackColor = true;
            this.prevSequenceBtn.Click += new System.EventHandler(this.prevSequenceBtn_Click);
            this.prevSequenceBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.prevSequenceBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // sequenceLbl
            // 
            this.sequenceLbl.AutoSize = true;
            this.sequenceLbl.Location = new System.Drawing.Point(12, 22);
            this.sequenceLbl.Name = "sequenceLbl";
            this.sequenceLbl.Size = new System.Drawing.Size(167, 32);
            this.sequenceLbl.TabIndex = 2;
            this.sequenceLbl.Text = "Sequence 1";
            // 
            // nextSequenceBtn
            // 
            this.nextSequenceBtn.Location = new System.Drawing.Point(1463, 12);
            this.nextSequenceBtn.Name = "nextSequenceBtn";
            this.nextSequenceBtn.Size = new System.Drawing.Size(53, 54);
            this.nextSequenceBtn.TabIndex = 1;
            this.nextSequenceBtn.Text = "»";
            this.nextSequenceBtn.UseVisualStyleBackColor = true;
            this.nextSequenceBtn.Click += new System.EventHandler(this.nextSequenceBtn_Click);
            this.nextSequenceBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.nextSequenceBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // imageLbl
            // 
            this.imageLbl.AutoSize = true;
            this.imageLbl.Location = new System.Drawing.Point(18, 1059);
            this.imageLbl.Name = "imageLbl";
            this.imageLbl.Size = new System.Drawing.Size(116, 32);
            this.imageLbl.TabIndex = 3;
            this.imageLbl.Text = "Image 1";
            // 
            // prevImageBtn
            // 
            this.prevImageBtn.Location = new System.Drawing.Point(1404, 1047);
            this.prevImageBtn.Name = "prevImageBtn";
            this.prevImageBtn.Size = new System.Drawing.Size(53, 54);
            this.prevImageBtn.TabIndex = 1;
            this.prevImageBtn.Text = "«";
            this.prevImageBtn.UseVisualStyleBackColor = true;
            this.prevImageBtn.Click += new System.EventHandler(this.prevImageBtn_Click);
            this.prevImageBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.prevImageBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // nextImageBtn
            // 
            this.nextImageBtn.Location = new System.Drawing.Point(1463, 1047);
            this.nextImageBtn.Name = "nextImageBtn";
            this.nextImageBtn.Size = new System.Drawing.Size(53, 54);
            this.nextImageBtn.TabIndex = 1;
            this.nextImageBtn.Text = "»";
            this.nextImageBtn.UseVisualStyleBackColor = true;
            this.nextImageBtn.Click += new System.EventHandler(this.nextImageBtn_Click);
            this.nextImageBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.nextImageBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // bgChkBox
            // 
            this.bgChkBox.AutoSize = true;
            this.bgChkBox.Location = new System.Drawing.Point(1557, 76);
            this.bgChkBox.Name = "bgChkBox";
            this.bgChkBox.Size = new System.Drawing.Size(317, 36);
            this.bgChkBox.TabIndex = 4;
            this.bgChkBox.Text = "Remove Background";
            this.bgChkBox.UseVisualStyleBackColor = true;
            this.bgChkBox.CheckedChanged += new System.EventHandler(this.bgChkBox_CheckedChanged);
            this.bgChkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.bgChkBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // cannyLbl
            // 
            this.cannyLbl.AutoSize = true;
            this.cannyLbl.Location = new System.Drawing.Point(1970, 280);
            this.cannyLbl.Name = "cannyLbl";
            this.cannyLbl.Size = new System.Drawing.Size(47, 32);
            this.cannyLbl.TabIndex = 5;
            this.cannyLbl.Text = "20";
            // 
            // cannyChkBox
            // 
            this.cannyChkBox.AutoSize = true;
            this.cannyChkBox.Location = new System.Drawing.Point(1557, 227);
            this.cannyChkBox.Name = "cannyChkBox";
            this.cannyChkBox.Size = new System.Drawing.Size(337, 36);
            this.cannyChkBox.TabIndex = 4;
            this.cannyChkBox.Text = "Canny Edge Detection";
            this.cannyChkBox.UseVisualStyleBackColor = true;
            this.cannyChkBox.CheckedChanged += new System.EventHandler(this.bgChkBox_CheckedChanged);
            this.cannyChkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.cannyChkBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // cannySlider
            // 
            this.cannySlider.Location = new System.Drawing.Point(1557, 269);
            this.cannySlider.Maximum = 200;
            this.cannySlider.Minimum = 1;
            this.cannySlider.Name = "cannySlider";
            this.cannySlider.Size = new System.Drawing.Size(407, 114);
            this.cannySlider.TabIndex = 6;
            this.cannySlider.Value = 20;
            this.cannySlider.Scroll += new System.EventHandler(this.cannySlider_Scroll);
            // 
            // contourChkBox
            // 
            this.contourChkBox.AutoSize = true;
            this.contourChkBox.Location = new System.Drawing.Point(1557, 346);
            this.contourChkBox.Name = "contourChkBox";
            this.contourChkBox.Size = new System.Drawing.Size(154, 36);
            this.contourChkBox.TabIndex = 7;
            this.contourChkBox.Text = "Contour";
            this.contourChkBox.UseVisualStyleBackColor = true;
            this.contourChkBox.CheckedChanged += new System.EventHandler(this.bgChkBox_CheckedChanged);
            // 
            // medianChkBox
            // 
            this.medianChkBox.AutoSize = true;
            this.medianChkBox.Location = new System.Drawing.Point(1557, 118);
            this.medianChkBox.Name = "medianChkBox";
            this.medianChkBox.Size = new System.Drawing.Size(205, 36);
            this.medianChkBox.TabIndex = 4;
            this.medianChkBox.Text = "Median Blur";
            this.medianChkBox.UseVisualStyleBackColor = true;
            this.medianChkBox.CheckedChanged += new System.EventHandler(this.bgChkBox_CheckedChanged);
            this.medianChkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.medianChkBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // medianLbl
            // 
            this.medianLbl.AutoSize = true;
            this.medianLbl.Location = new System.Drawing.Point(1970, 171);
            this.medianLbl.Name = "medianLbl";
            this.medianLbl.Size = new System.Drawing.Size(31, 32);
            this.medianLbl.TabIndex = 5;
            this.medianLbl.Text = "3";
            // 
            // medianSlider
            // 
            this.medianSlider.Location = new System.Drawing.Point(1557, 160);
            this.medianSlider.Maximum = 99;
            this.medianSlider.Minimum = 3;
            this.medianSlider.Name = "medianSlider";
            this.medianSlider.Size = new System.Drawing.Size(407, 114);
            this.medianSlider.SmallChange = 2;
            this.medianSlider.TabIndex = 6;
            this.medianSlider.TickFrequency = 2;
            this.medianSlider.Value = 3;
            this.medianSlider.Scroll += new System.EventHandler(this.medianSlider_Scroll);
            // 
            // contourLbl
            // 
            this.contourLbl.AutoSize = true;
            this.contourLbl.Location = new System.Drawing.Point(1557, 390);
            this.contourLbl.Name = "contourLbl";
            this.contourLbl.Size = new System.Drawing.Size(227, 32);
            this.contourLbl.TabIndex = 8;
            this.contourLbl.Text = "Biggest Contour:";
            // 
            // SequenceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2077, 1115);
            this.Controls.Add(this.contourLbl);
            this.Controls.Add(this.contourChkBox);
            this.Controls.Add(this.cannySlider);
            this.Controls.Add(this.cannyLbl);
            this.Controls.Add(this.cannyChkBox);
            this.Controls.Add(this.medianChkBox);
            this.Controls.Add(this.bgChkBox);
            this.Controls.Add(this.imageLbl);
            this.Controls.Add(this.sequenceLbl);
            this.Controls.Add(this.nextImageBtn);
            this.Controls.Add(this.prevImageBtn);
            this.Controls.Add(this.nextSequenceBtn);
            this.Controls.Add(this.prevSequenceBtn);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.medianSlider);
            this.Controls.Add(this.medianLbl);
            this.Name = "SequenceViewer";
            this.Text = "Sequence Viewer";
            this.Load += new System.EventHandler(this.SequenceViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button prevSequenceBtn;
        private System.Windows.Forms.Label sequenceLbl;
        private System.Windows.Forms.Button nextSequenceBtn;
        private System.Windows.Forms.Label imageLbl;
        private System.Windows.Forms.Button prevImageBtn;
        private System.Windows.Forms.Button nextImageBtn;
        private System.Windows.Forms.CheckBox bgChkBox;
        private System.Windows.Forms.Label cannyLbl;
        private System.Windows.Forms.CheckBox cannyChkBox;
        private System.Windows.Forms.TrackBar cannySlider;
        private System.Windows.Forms.CheckBox contourChkBox;
        private System.Windows.Forms.CheckBox medianChkBox;
        private System.Windows.Forms.Label medianLbl;
        private System.Windows.Forms.TrackBar medianSlider;
        private System.Windows.Forms.Label contourLbl;
    }
}