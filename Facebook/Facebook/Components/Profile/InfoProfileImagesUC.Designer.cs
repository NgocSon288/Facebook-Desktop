
namespace Facebook.Components.Profile
{
    partial class InfoProfileImagesUC
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
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.flpContent);
            this.pnlWrap.Location = new System.Drawing.Point(3, 3);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(976, 365);
            this.pnlWrap.TabIndex = 8;
            // 
            // flpContent
            // 
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.Location = new System.Drawing.Point(0, 0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(976, 365);
            this.flpContent.TabIndex = 0;
            // 
            // InfoProfileImagesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InfoProfileImagesUC";
            this.Size = new System.Drawing.Size(982, 371);
            this.pnlWrap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
    }
}
