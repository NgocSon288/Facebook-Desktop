
namespace Facebook.Components.Drive
{
    partial class DriveLinkItemUC
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
            this.picIcon = new FontAwesome.Sharp.IconPictureBox();
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.picIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 50;
            this.picIcon.Location = new System.Drawing.Point(0, 32);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(50, 54);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.lblName);
            this.pnlWrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrap.Location = new System.Drawing.Point(89, 13);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(188, 80);
            this.pnlWrap.TabIndex = 1;
            this.pnlWrap.Click += new System.EventHandler(this.pnlWrap_Click);
            this.pnlWrap.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            this.pnlWrap.MouseLeave += new System.EventHandler(this.pnlWrap_MouseLeave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(24, 19);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(139, 43);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.pnlWrap_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            // 
            // DriveLinkItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Controls.Add(this.picIcon);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DriveLinkItemUC";
            this.Size = new System.Drawing.Size(360, 100);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox picIcon;
        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Label lblName;
    }
}
