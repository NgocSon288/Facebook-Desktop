
namespace Facebook.Components.Profile
{
    partial class HeaderProfileUC
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
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.beWrapAavatar = new System.Windows.Forms.PictureBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlWrapImage = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beWrapAavatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlWrapImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.picAvatar);
            this.pnlWrap.Controls.Add(this.pnlWrapImage);
            this.pnlWrap.Controls.Add(this.pnlBottom);
            this.pnlWrap.Controls.Add(this.lblName);
            this.pnlWrap.Location = new System.Drawing.Point(19, 18);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(946, 627);
            this.pnlWrap.TabIndex = 0;
            // 
            // beWrapAavatar
            // 
            this.beWrapAavatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.beWrapAavatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.beWrapAavatar.Location = new System.Drawing.Point(2, 2);
            this.beWrapAavatar.Margin = new System.Windows.Forms.Padding(0);
            this.beWrapAavatar.Name = "beWrapAavatar";
            this.beWrapAavatar.Size = new System.Drawing.Size(900, 333);
            this.beWrapAavatar.TabIndex = 20;
            this.beWrapAavatar.TabStop = false;
            this.beWrapAavatar.Click += new System.EventHandler(this.picImage_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(384, 365);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(200, 200);
            this.picAvatar.TabIndex = 25;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // pnlWrapImage
            // 
            this.pnlWrapImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlWrapImage.Controls.Add(this.beWrapAavatar);
            this.pnlWrapImage.Location = new System.Drawing.Point(20, 20);
            this.pnlWrapImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapImage.Name = "pnlWrapImage";
            this.pnlWrapImage.Size = new System.Drawing.Size(904, 337);
            this.pnlWrapImage.TabIndex = 28;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(447, 607);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(81, 10);
            this.pnlBottom.TabIndex = 27;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblName.Location = new System.Drawing.Point(378, 568);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(239, 34);
            this.lblName.TabIndex = 26;
            this.lblName.Text = "Huỳnh Ngọc Sơn";
            // 
            // HeaderProfileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HeaderProfileUC";
            this.Size = new System.Drawing.Size(982, 660);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beWrapAavatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlWrapImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlWrapImage;
        private System.Windows.Forms.PictureBox beWrapAavatar;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblName;
    }
}
