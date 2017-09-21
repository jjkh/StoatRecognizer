namespace StoatRecognizer
{
    partial class StoatForm
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
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.picBox3 = new System.Windows.Forms.PictureBox();
            this.picBox4 = new System.Windows.Forms.PictureBox();
            this.picBox6 = new System.Windows.Forms.PictureBox();
            this.picBox7 = new System.Windows.Forms.PictureBox();
            this.picBox5 = new System.Windows.Forms.PictureBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.recognizeBtn = new System.Windows.Forms.Button();
            this.laplaceSlider = new System.Windows.Forms.TrackBar();
            this.laplaceLabel = new System.Windows.Forms.Label();
            this.threshSlider = new System.Windows.Forms.TrackBar();
            this.threshLabel = new System.Windows.Forms.Label();
            this.sequenceBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laplaceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox1
            // 
            this.picBox1.Location = new System.Drawing.Point(12, 12);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(652, 515);
            this.picBox1.TabIndex = 0;
            this.picBox1.TabStop = false;
            // 
            // picBox2
            // 
            this.picBox2.Location = new System.Drawing.Point(670, 12);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(652, 515);
            this.picBox2.TabIndex = 0;
            this.picBox2.TabStop = false;
            // 
            // picBox3
            // 
            this.picBox3.Location = new System.Drawing.Point(1328, 12);
            this.picBox3.Name = "picBox3";
            this.picBox3.Size = new System.Drawing.Size(652, 515);
            this.picBox3.TabIndex = 0;
            this.picBox3.TabStop = false;
            // 
            // picBox4
            // 
            this.picBox4.Location = new System.Drawing.Point(1986, 12);
            this.picBox4.Name = "picBox4";
            this.picBox4.Size = new System.Drawing.Size(652, 515);
            this.picBox4.TabIndex = 0;
            this.picBox4.TabStop = false;
            // 
            // picBox6
            // 
            this.picBox6.Location = new System.Drawing.Point(670, 533);
            this.picBox6.Name = "picBox6";
            this.picBox6.Size = new System.Drawing.Size(652, 515);
            this.picBox6.TabIndex = 0;
            this.picBox6.TabStop = false;
            // 
            // picBox7
            // 
            this.picBox7.Location = new System.Drawing.Point(1328, 533);
            this.picBox7.Name = "picBox7";
            this.picBox7.Size = new System.Drawing.Size(652, 515);
            this.picBox7.TabIndex = 0;
            this.picBox7.TabStop = false;
            // 
            // picBox5
            // 
            this.picBox5.Location = new System.Drawing.Point(12, 533);
            this.picBox5.Name = "picBox5";
            this.picBox5.Size = new System.Drawing.Size(652, 515);
            this.picBox5.TabIndex = 0;
            this.picBox5.TabStop = false;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(1986, 534);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(652, 113);
            this.loadBtn.TabIndex = 1;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // recognizeBtn
            // 
            this.recognizeBtn.Location = new System.Drawing.Point(1986, 653);
            this.recognizeBtn.Name = "recognizeBtn";
            this.recognizeBtn.Size = new System.Drawing.Size(652, 113);
            this.recognizeBtn.TabIndex = 1;
            this.recognizeBtn.Text = "Recognize";
            this.recognizeBtn.UseVisualStyleBackColor = true;
            this.recognizeBtn.Click += new System.EventHandler(this.recognizeBtn_Click);
            // 
            // laplaceSlider
            // 
            this.laplaceSlider.LargeChange = 2;
            this.laplaceSlider.Location = new System.Drawing.Point(1986, 783);
            this.laplaceSlider.Maximum = 31;
            this.laplaceSlider.Minimum = 1;
            this.laplaceSlider.Name = "laplaceSlider";
            this.laplaceSlider.Size = new System.Drawing.Size(590, 114);
            this.laplaceSlider.SmallChange = 2;
            this.laplaceSlider.TabIndex = 2;
            this.laplaceSlider.TickFrequency = 2;
            this.laplaceSlider.Value = 1;
            this.laplaceSlider.Scroll += new System.EventHandler(this.recognizeBtn_Click);
            // 
            // laplaceLabel
            // 
            this.laplaceLabel.AutoSize = true;
            this.laplaceLabel.Location = new System.Drawing.Point(2583, 792);
            this.laplaceLabel.Name = "laplaceLabel";
            this.laplaceLabel.Size = new System.Drawing.Size(31, 32);
            this.laplaceLabel.TabIndex = 3;
            this.laplaceLabel.Text = "1";
            // 
            // threshSlider
            // 
            this.threshSlider.LargeChange = 20;
            this.threshSlider.Location = new System.Drawing.Point(1986, 861);
            this.threshSlider.Maximum = 255;
            this.threshSlider.Name = "threshSlider";
            this.threshSlider.Size = new System.Drawing.Size(590, 114);
            this.threshSlider.SmallChange = 2;
            this.threshSlider.TabIndex = 2;
            this.threshSlider.Value = 20;
            this.threshSlider.Scroll += new System.EventHandler(this.recognizeBtn_Click);
            // 
            // threshLabel
            // 
            this.threshLabel.AutoSize = true;
            this.threshLabel.Location = new System.Drawing.Point(2583, 870);
            this.threshLabel.Name = "threshLabel";
            this.threshLabel.Size = new System.Drawing.Size(47, 32);
            this.threshLabel.TabIndex = 3;
            this.threshLabel.Text = "20";
            // 
            // sequenceBtn
            // 
            this.sequenceBtn.Location = new System.Drawing.Point(1989, 935);
            this.sequenceBtn.Name = "sequenceBtn";
            this.sequenceBtn.Size = new System.Drawing.Size(652, 113);
            this.sequenceBtn.TabIndex = 1;
            this.sequenceBtn.Text = "Image Sequence";
            this.sequenceBtn.UseVisualStyleBackColor = true;
            this.sequenceBtn.Click += new System.EventHandler(this.sequenceBtn_Click);
            // 
            // StoatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2665, 1064);
            this.Controls.Add(this.sequenceBtn);
            this.Controls.Add(this.threshLabel);
            this.Controls.Add(this.laplaceLabel);
            this.Controls.Add(this.threshSlider);
            this.Controls.Add(this.laplaceSlider);
            this.Controls.Add(this.recognizeBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.picBox4);
            this.Controls.Add(this.picBox7);
            this.Controls.Add(this.picBox3);
            this.Controls.Add(this.picBox6);
            this.Controls.Add(this.picBox5);
            this.Controls.Add(this.picBox2);
            this.Controls.Add(this.picBox1);
            this.Name = "StoatForm";
            this.Text = "Feret Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laplaceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.PictureBox picBox3;
        private System.Windows.Forms.PictureBox picBox4;
        private System.Windows.Forms.PictureBox picBox6;
        private System.Windows.Forms.PictureBox picBox7;
        private System.Windows.Forms.PictureBox picBox5;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button recognizeBtn;
        private System.Windows.Forms.TrackBar laplaceSlider;
        private System.Windows.Forms.Label laplaceLabel;
        private System.Windows.Forms.TrackBar threshSlider;
        private System.Windows.Forms.Label threshLabel;
        private System.Windows.Forms.Button sequenceBtn;
    }
}

