
namespace Facebook.Components.Profile
{
    partial class InfoProfileFriendsUC
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
            this.flpContentLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.flpContentRight = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.flpContentRight);
            this.pnlWrap.Controls.Add(this.flpContentLeft);
            this.pnlWrap.Location = new System.Drawing.Point(3, 3);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(976, 365);
            this.pnlWrap.TabIndex = 7;
            // 
            // flpContentLeft
            // 
            this.flpContentLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpContentLeft.Location = new System.Drawing.Point(0, 0);
            this.flpContentLeft.Margin = new System.Windows.Forms.Padding(0);
            this.flpContentLeft.Name = "flpContentLeft";
            this.flpContentLeft.Size = new System.Drawing.Size(478, 365);
            this.flpContentLeft.TabIndex = 0;
            // 
            // flpContentRight
            // 
            this.flpContentRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpContentRight.Location = new System.Drawing.Point(498, 0);
            this.flpContentRight.Margin = new System.Windows.Forms.Padding(0);
            this.flpContentRight.Name = "flpContentRight";
            this.flpContentRight.Size = new System.Drawing.Size(478, 365);
            this.flpContentRight.TabIndex = 1;
            // 
            // InfoProfileFriendsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InfoProfileFriendsUC";
            this.Size = new System.Drawing.Size(982, 371);
            this.pnlWrap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.FlowLayoutPanel flpContentLeft;
        private System.Windows.Forms.FlowLayoutPanel flpContentRight;
    }
}
