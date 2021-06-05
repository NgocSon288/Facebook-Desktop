
namespace Facebook.Components.Profile
{
    partial class PostCommentItemUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.picOwnCommentAvatar = new System.Windows.Forms.PictureBox();
            this.lblOwnCommentName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOwnCommentAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trong comment cũng có thể có feedback comment";
            // 
            // picOwnCommentAvatar
            // 
            this.picOwnCommentAvatar.Location = new System.Drawing.Point(11, 12);
            this.picOwnCommentAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picOwnCommentAvatar.Name = "picOwnCommentAvatar";
            this.picOwnCommentAvatar.Size = new System.Drawing.Size(40, 40);
            this.picOwnCommentAvatar.TabIndex = 1;
            this.picOwnCommentAvatar.TabStop = false;
            // 
            // lblOwnCommentName
            // 
            this.lblOwnCommentName.AutoSize = true;
            this.lblOwnCommentName.Location = new System.Drawing.Point(72, 12);
            this.lblOwnCommentName.Name = "lblOwnCommentName";
            this.lblOwnCommentName.Size = new System.Drawing.Size(250, 13);
            this.lblOwnCommentName.TabIndex = 2;
            this.lblOwnCommentName.Text = "Trong comment cũng có thể có feedback comment";
            // 
            // PostCommentItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.lblOwnCommentName);
            this.Controls.Add(this.picOwnCommentAvatar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.Name = "PostCommentItemUC";
            this.Size = new System.Drawing.Size(444, 116);
            ((System.ComponentModel.ISupportInitialize)(this.picOwnCommentAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOwnCommentAvatar;
        private System.Windows.Forms.Label lblOwnCommentName;
    }
}
