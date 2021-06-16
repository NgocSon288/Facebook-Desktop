
namespace Facebook.Components.Messenger
{
    partial class ShareFilesUC
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.picIcon = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.picIcon);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(298, 38);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.Click += new System.EventHandler(this.pnlTitle_Click);
            this.pnlTitle.MouseEnter += new System.EventHandler(this.pnlTitle_MouseEnter);
            this.pnlTitle.MouseLeave += new System.EventHandler(this.pnlTitle_MouseLeave);
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.AngleUp;
            this.picIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 20;
            this.picIcon.Location = new System.Drawing.Point(270, 12);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(20, 20);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.pnlTitle_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.pnlTitle_MouseEnter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tệp được chia sẻ";
            this.lblTitle.Click += new System.EventHandler(this.pnlTitle_Click);
            this.lblTitle.MouseEnter += new System.EventHandler(this.pnlTitle_MouseEnter);
            // 
            // flpContent
            // 
            this.flpContent.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.Location = new System.Drawing.Point(0, 38);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(298, 150);
            this.flpContent.TabIndex = 1;
            // 
            // ShareFilesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpContent);
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ShareFilesUC";
            this.Size = new System.Drawing.Size(298, 188);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconPictureBox picIcon;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
    }
}
