
namespace Facebook.Components.Profile
{
    partial class PostListProfileUC
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlThink = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.picThink = new System.Windows.Forms.PictureBox();
            this.pnlContent.SuspendLayout();
            this.pnlThink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThink)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlContent.Controls.Add(this.flpContent);
            this.pnlContent.Controls.Add(this.pnlSeparator);
            this.pnlContent.Controls.Add(this.pnlThink);
            this.pnlContent.Location = new System.Drawing.Point(15, 11);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(464, 487);
            this.pnlContent.TabIndex = 0;
            // 
            // flpContent
            // 
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.Location = new System.Drawing.Point(0, 64);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(464, 423);
            this.flpContent.TabIndex = 2;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 59);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(464, 5);
            this.pnlSeparator.TabIndex = 1;
            // 
            // pnlThink
            // 
            this.pnlThink.Controls.Add(this.picAvatar);
            this.pnlThink.Controls.Add(this.picThink);
            this.pnlThink.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThink.Location = new System.Drawing.Point(0, 0);
            this.pnlThink.Name = "pnlThink";
            this.pnlThink.Size = new System.Drawing.Size(464, 59);
            this.pnlThink.TabIndex = 0;
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(10, 4);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // picThink
            // 
            this.picThink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picThink.Location = new System.Drawing.Point(79, 11);
            this.picThink.Margin = new System.Windows.Forms.Padding(0);
            this.picThink.Name = "picThink";
            this.picThink.Size = new System.Drawing.Size(367, 35);
            this.picThink.TabIndex = 0;
            this.picThink.TabStop = false;
            this.picThink.Click += new System.EventHandler(this.picThink_Click);
            this.picThink.MouseEnter += new System.EventHandler(this.picThink_MouseEnter);
            this.picThink.MouseLeave += new System.EventHandler(this.picThink_MouseLeave);
            // 
            // PostListProfileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.pnlContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PostListProfileUC";
            this.Size = new System.Drawing.Size(491, 515);
            this.pnlContent.ResumeLayout(false);
            this.pnlThink.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThink)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlThink;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.PictureBox picThink;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}
