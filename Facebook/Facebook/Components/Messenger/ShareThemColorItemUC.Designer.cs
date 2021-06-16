
namespace Facebook.Components.Messenger
{
    partial class ShareThemColorItemUC
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
            this.pnlColor = new System.Windows.Forms.Panel();
            this.pnlWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.pnlColor);
            this.pnlWrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrap.Location = new System.Drawing.Point(10, 10);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(70, 70);
            this.pnlWrap.TabIndex = 0;
            this.pnlWrap.Click += new System.EventHandler(this.pnlColor_Click);
            this.pnlWrap.MouseEnter += new System.EventHandler(this.pnlWrap_Enter);
            this.pnlWrap.MouseLeave += new System.EventHandler(this.pnlWrap_MouseLeave);
            // 
            // pnlColor
            // 
            this.pnlColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlColor.Location = new System.Drawing.Point(10, 10);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(50, 50);
            this.pnlColor.TabIndex = 0;
            this.pnlColor.Click += new System.EventHandler(this.pnlColor_Click);
            this.pnlColor.MouseEnter += new System.EventHandler(this.pnlWrap_Enter);
            // 
            // ShareThemColorItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Name = "ShareThemColorItemUC";
            this.Size = new System.Drawing.Size(90, 90);
            this.pnlWrap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Panel pnlColor;
    }
}
