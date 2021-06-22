
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
            this.pnlWrapText = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlThink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlWrapText.SuspendLayout();
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
            this.flpContent.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
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
            this.pnlThink.Controls.Add(this.pnlWrapText);
            this.pnlThink.Controls.Add(this.picAvatar);
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
            // pnlWrapText
            // 
            this.pnlWrapText.Controls.Add(this.lblText);
            this.pnlWrapText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrapText.Location = new System.Drawing.Point(78, 12);
            this.pnlWrapText.Name = "pnlWrapText";
            this.pnlWrapText.Size = new System.Drawing.Size(367, 35);
            this.pnlWrapText.TabIndex = 1;
            this.pnlWrapText.Click += new System.EventHandler(this.pnlWrapText_Click);
            this.pnlWrapText.MouseEnter += new System.EventHandler(this.pnlWrapText_MouseEnter);
            this.pnlWrapText.MouseLeave += new System.EventHandler(this.pnlWrapText_MouseLeave);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblText.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 4);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(180, 22);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Bạn đang nghĩ gì?";
            this.lblText.Click += new System.EventHandler(this.pnlWrapText_Click);
            this.lblText.MouseEnter += new System.EventHandler(this.pnlWrapText_MouseEnter);
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
            this.pnlWrapText.ResumeLayout(false);
            this.pnlWrapText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlThink;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlWrapText;
        private System.Windows.Forms.Label lblText;
    }
}
