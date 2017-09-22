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
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(11, 76);
            this.picBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1504, 961);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // prevSequenceBtn
            // 
            this.prevSequenceBtn.Location = new System.Drawing.Point(1403, 12);
            this.prevSequenceBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prevSequenceBtn.Name = "prevSequenceBtn";
            this.prevSequenceBtn.Size = new System.Drawing.Size(53, 55);
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
            this.sequenceLbl.Location = new System.Drawing.Point(11, 21);
            this.sequenceLbl.Name = "sequenceLbl";
            this.sequenceLbl.Size = new System.Drawing.Size(167, 32);
            this.sequenceLbl.TabIndex = 2;
            this.sequenceLbl.Text = "Sequence 1";
            // 
            // nextSequenceBtn
            // 
            this.nextSequenceBtn.Location = new System.Drawing.Point(1464, 12);
            this.nextSequenceBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextSequenceBtn.Name = "nextSequenceBtn";
            this.nextSequenceBtn.Size = new System.Drawing.Size(53, 55);
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
            this.imageLbl.Location = new System.Drawing.Point(19, 1059);
            this.imageLbl.Name = "imageLbl";
            this.imageLbl.Size = new System.Drawing.Size(116, 32);
            this.imageLbl.TabIndex = 3;
            this.imageLbl.Text = "Image 1";
            // 
            // prevImageBtn
            // 
            this.prevImageBtn.Location = new System.Drawing.Point(1403, 1047);
            this.prevImageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prevImageBtn.Name = "prevImageBtn";
            this.prevImageBtn.Size = new System.Drawing.Size(53, 55);
            this.prevImageBtn.TabIndex = 1;
            this.prevImageBtn.Text = "«";
            this.prevImageBtn.UseVisualStyleBackColor = true;
            this.prevImageBtn.Click += new System.EventHandler(this.prevImageBtn_Click);
            this.prevImageBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.prevImageBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // nextImageBtn
            // 
            this.nextImageBtn.Location = new System.Drawing.Point(1464, 1047);
            this.nextImageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextImageBtn.Name = "nextImageBtn";
            this.nextImageBtn.Size = new System.Drawing.Size(53, 55);
            this.nextImageBtn.TabIndex = 1;
            this.nextImageBtn.Text = "»";
            this.nextImageBtn.UseVisualStyleBackColor = true;
            this.nextImageBtn.Click += new System.EventHandler(this.nextImageBtn_Click);
            this.nextImageBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.nextImageBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            // 
            // SequenceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 1109);
            this.Controls.Add(this.imageLbl);
            this.Controls.Add(this.sequenceLbl);
            this.Controls.Add(this.nextImageBtn);
            this.Controls.Add(this.prevImageBtn);
            this.Controls.Add(this.nextSequenceBtn);
            this.Controls.Add(this.prevSequenceBtn);
            this.Controls.Add(this.picBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SequenceViewer";
            this.Text = "Sequence Viewer";
            this.Load += new System.EventHandler(this.SequenceViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceViewer_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SequenceViewer_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
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
    }
}