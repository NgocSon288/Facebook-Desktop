
namespace Facebook.Components.Messenger
{
    partial class FileAttachItemUC
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
            this.lblName = new System.Windows.Forms.Label();
            this.picFile = new FontAwesome.Sharp.IconPictureBox();
            this.pnlWrapIcon = new System.Windows.Forms.Panel();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).BeginInit();
            this.pnlWrapIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(41, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            // 
            // picFile
            // 
            this.picFile.BackColor = System.Drawing.SystemColors.Control;
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
            // 
            // pnlWrapIcon
            // 
            this.pnlWrapIcon.Controls.Add(this.picFile);
            this.pnlWrapIcon.Location = new System.Drawing.Point(8, 7);
            this.pnlWrapIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrapIcon.Name = "pnlWrapIcon";
            this.pnlWrapIcon.Size = new System.Drawing.Size(26, 26);
            this.pnlWrapIcon.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnDelete.IconColor = System.Drawing.Color.Black;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 28;
            this.btnDelete.Location = new System.Drawing.Point(119, -12);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(0, 17, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(26, 26);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FileAttachItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlWrapIcon);
            this.Controls.Add(this.lblName);
            this.Name = "FileAttachItemUC";
            this.Size = new System.Drawing.Size(146, 40);
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).EndInit();
            this.pnlWrapIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private FontAwesome.Sharp.IconPictureBox picFile;
        private System.Windows.Forms.Panel pnlWrapIcon;
        private System.Windows.Forms.ToolTip tt;
        private FontAwesome.Sharp.IconButton btnDelete;
    }
}
