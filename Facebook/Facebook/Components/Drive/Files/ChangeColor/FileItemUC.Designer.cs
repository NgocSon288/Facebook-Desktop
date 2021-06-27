
namespace Facebook.Components.Drive.Files.ChangeColor
{
    partial class FileItemUC
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
            this.picColor = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.lblName);
            this.pnlWrap.Controls.Add(this.picColor);
            this.pnlWrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrap.Location = new System.Drawing.Point(5, 5);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(382, 60);
            this.pnlWrap.TabIndex = 1;
            this.pnlWrap.Click += new System.EventHandler(this.pnlWrap_Click);
            this.pnlWrap.MouseEnter += new System.EventHandler(this.picColor_MouseEnter);
            this.pnlWrap.MouseLeave += new System.EventHandler(this.pnlWrap_MouseLeave);
            // 
            // picColor
            // 
            this.picColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picColor.Location = new System.Drawing.Point(10, 10);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(40, 40);
            this.picColor.TabIndex = 0;
            this.picColor.TabStop = false;
            this.picColor.Click += new System.EventHandler(this.pnlWrap_Click);
            this.picColor.MouseEnter += new System.EventHandler(this.picColor_MouseEnter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Location = new System.Drawing.Point(65, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.pnlWrap_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.picColor_MouseEnter);
            // 
            // FileItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FileItemUC";
            this.Size = new System.Drawing.Size(392, 70);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Label lblName;
    }
}
