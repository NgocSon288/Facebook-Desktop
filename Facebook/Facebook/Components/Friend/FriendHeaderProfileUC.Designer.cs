
namespace Facebook.Components.Friend
{
    partial class FriendHeaderProfileUC
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
            this.pnlWrapImage = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlWrap.SuspendLayout();
            this.pnlWrapImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.pnlWrapImage);
            this.pnlWrap.Controls.Add(this.pnlBottom);
            this.pnlWrap.Controls.Add(this.lblName);
            this.pnlWrap.Controls.Add(this.picAvatar);
            this.pnlWrap.Location = new System.Drawing.Point(10, 10);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(706, 479);
            this.pnlWrap.TabIndex = 0;
            // 
            // pnlWrapImage
            // 
            this.pnlWrapImage.Controls.Add(this.picImage);
            this.pnlWrapImage.Location = new System.Drawing.Point(18, 9);
            this.pnlWrapImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapImage.Name = "pnlWrapImage";
            this.pnlWrapImage.Size = new System.Drawing.Size(674, 249);
            this.pnlWrapImage.TabIndex = 30;
            // 
            // picImage
            // 
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.Location = new System.Drawing.Point(2, 2);
            this.picImage.Margin = new System.Windows.Forms.Padding(0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(670, 245);
            this.picImage.TabIndex = 21;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(321, 464);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(81, 10);
            this.pnlBottom.TabIndex = 29;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblName.Location = new System.Drawing.Point(252, 425);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(239, 34);
            this.lblName.TabIndex = 28;
            this.lblName.Text = "Huỳnh Ngọc Sơn";
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(276, 265);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(150, 150);
            this.picAvatar.TabIndex = 26;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // FriendHeaderProfileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FriendHeaderProfileUC";
            this.Size = new System.Drawing.Size(732, 491);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            this.pnlWrapImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlWrapImage;
    }
}
