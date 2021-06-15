
namespace Facebook.Components.Messenger
{
    partial class MessengerHeaderMessageUC
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
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.picPhone = new FontAwesome.Sharp.IconPictureBox();
            this.picVideo = new FontAwesome.Sharp.IconPictureBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(5, 5);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(67, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 19);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            // 
            // picPhone
            // 
            this.picPhone.BackColor = System.Drawing.SystemColors.Control;
            this.picPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picPhone.IconChar = FontAwesome.Sharp.IconChar.Phone;
            this.picPhone.IconColor = System.Drawing.SystemColors.ControlText;
            this.picPhone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picPhone.IconSize = 30;
            this.picPhone.Location = new System.Drawing.Point(325, 13);
            this.picPhone.Margin = new System.Windows.Forms.Padding(0);
            this.picPhone.Name = "picPhone";
            this.picPhone.Size = new System.Drawing.Size(30, 30);
            this.picPhone.TabIndex = 3;
            this.picPhone.TabStop = false;
            // 
            // picVideo
            // 
            this.picVideo.BackColor = System.Drawing.SystemColors.Control;
            this.picVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVideo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picVideo.IconChar = FontAwesome.Sharp.IconChar.Video;
            this.picVideo.IconColor = System.Drawing.SystemColors.ControlText;
            this.picVideo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picVideo.IconSize = 30;
            this.picVideo.Location = new System.Drawing.Point(359, 13);
            this.picVideo.Margin = new System.Windows.Forms.Padding(0);
            this.picVideo.Name = "picVideo";
            this.picVideo.Size = new System.Drawing.Size(30, 30);
            this.picVideo.TabIndex = 4;
            this.picVideo.TabStop = false;
            // 
            // MessengerHeaderMessageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picVideo);
            this.Controls.Add(this.picPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picAvatar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MessengerHeaderMessageUC";
            this.Size = new System.Drawing.Size(400, 60);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAvatar;
        public System.Windows.Forms.Label lblName;
        private FontAwesome.Sharp.IconPictureBox picPhone;
        private FontAwesome.Sharp.IconPictureBox picVideo;
        private System.Windows.Forms.ToolTip tt;
    }
}
