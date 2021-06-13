
namespace Facebook.Components.Profile
{
    partial class InfoProfileImageItemUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlWrap = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pnlWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.Location = new System.Drawing.Point(14, 15);
            this.picImage.Margin = new System.Windows.Forms.Padding(0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(144, 153);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.picImage);
            this.pnlWrap.Location = new System.Drawing.Point(7, 8);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(180, 179);
            this.pnlWrap.TabIndex = 1;
            // 
            // InfoProfileImageItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InfoProfileImageItemUC";
            this.Size = new System.Drawing.Size(190, 190);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlWrap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Panel pnlWrap;
    }
}
