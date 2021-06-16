
namespace Facebook.Components.Messenger
{
    partial class ShareSettingThemeUC
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
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.Delicious;
            this.picIcon.IconColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 26;
            this.picIcon.Location = new System.Drawing.Point(14, 7);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(26, 26);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.ShareSettingThemeUC_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(56, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Đổi màu sắc";
            this.lblTitle.Click += new System.EventHandler(this.ShareSettingThemeUC_Click);
            // 
            // ShareSettingThemeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picIcon);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ShareSettingThemeUC";
            this.Size = new System.Drawing.Size(298, 38);
            this.Click += new System.EventHandler(this.ShareSettingThemeUC_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
    }
}
