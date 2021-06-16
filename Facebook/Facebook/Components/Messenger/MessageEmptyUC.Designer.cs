
namespace Facebook.Components.Messenger
{
    partial class MessageEmptyUC
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
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(163, 174);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Empty";
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(147, 61);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(165, 207);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(63, 15);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Facebook";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(89, 230);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(224, 15);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Các bạn là bạn bè trên Facebook";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(89, 251);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(217, 15);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Sống tại Thành phố Hồ Chí Minh";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(50, 614);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(322, 15);
            this.lbl4.TabIndex = 5;
            this.lbl4.Text = "Các bạn hiện đã  được kết nối  trên Messenger";
            // 
            // MessageEmptyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MessageEmptyUC";
            this.Size = new System.Drawing.Size(400, 645);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
    }
}
