
namespace Facebook.Components.Drive
{
    partial class DriveFileItemUC
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
            this.components = new System.ComponentModel.Container();
            this.picIcon = new FontAwesome.Sharp.IconPictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.picIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 24;
            this.picIcon.Location = new System.Drawing.Point(12, 13);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(24, 24);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.pnlWrap_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(43, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.pnlWrap_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.lblName);
            this.pnlWrap.Controls.Add(this.picIcon);
            this.pnlWrap.Location = new System.Drawing.Point(3, 3);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(224, 44);
            this.pnlWrap.TabIndex = 2;
            this.pnlWrap.Click += new System.EventHandler(this.pnlWrap_Click);
            this.pnlWrap.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            this.pnlWrap.MouseLeave += new System.EventHandler(this.DriveFileItemUC_MouseLeave);
            // 
            // DriveFileItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrap);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "DriveFileItemUC";
            this.Size = new System.Drawing.Size(230, 50);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlWrap.ResumeLayout(false);
            this.pnlWrap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox picIcon;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.ToolTip tt;
    }
}
