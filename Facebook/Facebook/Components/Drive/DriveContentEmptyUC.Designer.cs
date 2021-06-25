
namespace Facebook.Components.Drive
{
    partial class DriveContentEmptyUC
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pnlWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.picImage);
            this.pnlWrap.Controls.Add(this.lbl2);
            this.pnlWrap.Controls.Add(this.lbl1);
            this.pnlWrap.Location = new System.Drawing.Point(266, 216);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(400, 400);
            this.pnlWrap.TabIndex = 0;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(124, 104);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(150, 150);
            this.picImage.TabIndex = 2;
            this.picImage.TabStop = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(102, 299);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(200, 18);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "or use the  \"New\" button";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(120, 267);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(160, 22);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Drop files here";
            // 
            // DriveContentEmptyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DriveContentEmptyUC";
            this.Size = new System.Drawing.Size(992, 700);
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.PictureBox picImage;
    }
}
