
namespace Facebook.Components.Messenger
{
    partial class MessageItemFileItemUC
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
            this.pnlWrapIcon = new System.Windows.Forms.Panel();
            this.picFile = new FontAwesome.Sharp.IconPictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlWrapIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWrapIcon
            // 
            this.pnlWrapIcon.Controls.Add(this.picFile);
            this.pnlWrapIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlWrapIcon.Location = new System.Drawing.Point(10, 5);
            this.pnlWrapIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapIcon.Name = "pnlWrapIcon";
            this.pnlWrapIcon.Size = new System.Drawing.Size(26, 26);
            this.pnlWrapIcon.TabIndex = 5;
            this.pnlWrapIcon.Click += new System.EventHandler(this.pnlWrapIcon_Click);
            // 
            // picFile
            // 
            this.picFile.BackColor = System.Drawing.SystemColors.Control;
            this.picFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picFile.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.picFile.IconColor = System.Drawing.SystemColors.ControlText;
            this.picFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picFile.IconSize = 16;
            this.picFile.Location = new System.Drawing.Point(5, 5);
            this.picFile.Margin = new System.Windows.Forms.Padding(0);
            this.picFile.Name = "picFile";
            this.picFile.Size = new System.Drawing.Size(16, 16);
            this.picFile.TabIndex = 3;
            this.picFile.TabStop = false;
            this.picFile.Click += new System.EventHandler(this.pnlWrapIcon_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(43, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 18);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.pnlWrapIcon_Click);
            // 
            // MessageItemFileItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlWrapIcon);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "MessageItemFileItemUC";
            this.Size = new System.Drawing.Size(300, 36);
            this.Click += new System.EventHandler(this.pnlWrapIcon_Click);
            this.pnlWrapIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrapIcon;
        private FontAwesome.Sharp.IconPictureBox picFile;
        private System.Windows.Forms.Label lblName;
    }
}
