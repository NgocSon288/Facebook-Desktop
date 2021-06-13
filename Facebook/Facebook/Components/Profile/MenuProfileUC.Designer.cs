
namespace Facebook.Components.Profile
{
    partial class MenuProfileUC
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
            this.pnlBorderIntro = new System.Windows.Forms.Panel();
            this.pnlWrapIntro = new System.Windows.Forms.Panel();
            this.lblIntro = new System.Windows.Forms.Label();
            this.pnlBorderImages = new System.Windows.Forms.Panel();
            this.lblImages = new System.Windows.Forms.Label();
            this.pnlWrapImages = new System.Windows.Forms.Panel();
            this.pnlBorderFriends = new System.Windows.Forms.Panel();
            this.lblFriends = new System.Windows.Forms.Label();
            this.pnlWrapFriends = new System.Windows.Forms.Panel();
            this.pnlWrap.SuspendLayout();
            this.pnlWrapIntro.SuspendLayout();
            this.pnlWrapImages.SuspendLayout();
            this.pnlWrapFriends.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.pnlBorderImages);
            this.pnlWrap.Controls.Add(this.pnlBorderFriends);
            this.pnlWrap.Controls.Add(this.pnlWrapImages);
            this.pnlWrap.Controls.Add(this.pnlWrapFriends);
            this.pnlWrap.Controls.Add(this.pnlBorderIntro);
            this.pnlWrap.Controls.Add(this.pnlWrapIntro);
            this.pnlWrap.Location = new System.Drawing.Point(6, 6);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(1952, 142);
            this.pnlWrap.TabIndex = 3;
            // 
            // pnlBorderIntro
            // 
            this.pnlBorderIntro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBorderIntro.Location = new System.Drawing.Point(280, 121);
            this.pnlBorderIntro.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlBorderIntro.Name = "pnlBorderIntro";
            this.pnlBorderIntro.Size = new System.Drawing.Size(450, 21);
            this.pnlBorderIntro.TabIndex = 4;
            // 
            // pnlWrapIntro
            // 
            this.pnlWrapIntro.Controls.Add(this.lblIntro);
            this.pnlWrapIntro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrapIntro.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlWrapIntro.Location = new System.Drawing.Point(280, 0);
            this.pnlWrapIntro.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapIntro.Name = "pnlWrapIntro";
            this.pnlWrapIntro.Size = new System.Drawing.Size(450, 115);
            this.pnlWrapIntro.TabIndex = 3;
            this.pnlWrapIntro.Click += new System.EventHandler(this.pnlWrapIntro_Click);
            this.pnlWrapIntro.MouseEnter += new System.EventHandler(this.pnlWrapIntro_Enter);
            this.pnlWrapIntro.MouseLeave += new System.EventHandler(this.pnlWrapIntro_MouseLeave);
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIntro.Location = new System.Drawing.Point(96, 40);
            this.lblIntro.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(252, 50);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Giới thiệu";
            this.lblIntro.Click += new System.EventHandler(this.pnlWrapIntro_Click);
            this.lblIntro.MouseEnter += new System.EventHandler(this.pnlWrapIntro_Enter);
            // 
            // pnlBorderImages
            // 
            this.pnlBorderImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBorderImages.Location = new System.Drawing.Point(1266, 121);
            this.pnlBorderImages.Margin = new System.Windows.Forms.Padding(6);
            this.pnlBorderImages.Name = "pnlBorderImages";
            this.pnlBorderImages.Size = new System.Drawing.Size(450, 21);
            this.pnlBorderImages.TabIndex = 6;
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblImages.Location = new System.Drawing.Point(96, 40);
            this.lblImages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(206, 50);
            this.lblImages.TabIndex = 0;
            this.lblImages.Text = "Hình ảnh";
            this.lblImages.Click += new System.EventHandler(this.lblImages_Click);
            this.lblImages.MouseEnter += new System.EventHandler(this.lblImages_MouseEnter);
            this.lblImages.MouseLeave += new System.EventHandler(this.lblImages_MouseLeave);
            // 
            // pnlWrapImages
            // 
            this.pnlWrapImages.Controls.Add(this.lblImages);
            this.pnlWrapImages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrapImages.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlWrapImages.Location = new System.Drawing.Point(1266, 0);
            this.pnlWrapImages.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapImages.Name = "pnlWrapImages";
            this.pnlWrapImages.Size = new System.Drawing.Size(450, 115);
            this.pnlWrapImages.TabIndex = 5;
            this.pnlWrapImages.Click += new System.EventHandler(this.lblImages_Click);
            this.pnlWrapImages.MouseEnter += new System.EventHandler(this.lblImages_MouseEnter);
            this.pnlWrapImages.MouseLeave += new System.EventHandler(this.lblImages_MouseLeave);
            // 
            // pnlBorderFriends
            // 
            this.pnlBorderFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBorderFriends.Location = new System.Drawing.Point(778, 121);
            this.pnlBorderFriends.Margin = new System.Windows.Forms.Padding(6);
            this.pnlBorderFriends.Name = "pnlBorderFriends";
            this.pnlBorderFriends.Size = new System.Drawing.Size(450, 21);
            this.pnlBorderFriends.TabIndex = 6;
            // 
            // lblFriends
            // 
            this.lblFriends.AutoSize = true;
            this.lblFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFriends.Location = new System.Drawing.Point(96, 40);
            this.lblFriends.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFriends.Name = "lblFriends";
            this.lblFriends.Size = new System.Drawing.Size(160, 50);
            this.lblFriends.TabIndex = 0;
            this.lblFriends.Text = "Bạn bè";
            this.lblFriends.Click += new System.EventHandler(this.lblFriends_Click);
            this.lblFriends.MouseEnter += new System.EventHandler(this.pnlWrapFriends_MouseEnter);
            this.lblFriends.MouseLeave += new System.EventHandler(this.pnlWrapFriends_MouseLeave);
            // 
            // pnlWrapFriends
            // 
            this.pnlWrapFriends.Controls.Add(this.lblFriends);
            this.pnlWrapFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrapFriends.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlWrapFriends.Location = new System.Drawing.Point(778, 0);
            this.pnlWrapFriends.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapFriends.Name = "pnlWrapFriends";
            this.pnlWrapFriends.Size = new System.Drawing.Size(450, 115);
            this.pnlWrapFriends.TabIndex = 5;
            this.pnlWrapFriends.Click += new System.EventHandler(this.lblFriends_Click);
            this.pnlWrapFriends.MouseEnter += new System.EventHandler(this.pnlWrapFriends_MouseEnter);
            this.pnlWrapFriends.MouseLeave += new System.EventHandler(this.pnlWrapFriends_MouseLeave);
            // 
            // MenuProfileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MenuProfileUC";
            this.Size = new System.Drawing.Size(1964, 154);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrapIntro.ResumeLayout(false);
            this.pnlWrapIntro.PerformLayout();
            this.pnlWrapImages.ResumeLayout(false);
            this.pnlWrapImages.PerformLayout();
            this.pnlWrapFriends.ResumeLayout(false);
            this.pnlWrapFriends.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Panel pnlWrapIntro;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Panel pnlBorderIntro;
        private System.Windows.Forms.Panel pnlBorderImages;
        private System.Windows.Forms.Panel pnlBorderFriends;
        private System.Windows.Forms.Panel pnlWrapImages;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Panel pnlWrapFriends;
        private System.Windows.Forms.Label lblFriends;
    }
}
