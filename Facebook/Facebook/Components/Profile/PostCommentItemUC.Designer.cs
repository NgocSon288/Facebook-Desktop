
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostCommentItemUC));
            this.picOwnCommentAvatar = new System.Windows.Forms.PictureBox();
            this.lblOwnCommentName = new System.Windows.Forms.Label();
            this.pnlMyComment = new System.Windows.Forms.Panel();
            this.lblOwnCommentDesctiption = new System.Windows.Forms.Label();
            this.beMyComment = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblOwnMyCommentLike = new System.Windows.Forms.Label();
            this.lblOwnMyCommentFeedback = new System.Windows.Forms.Label();
            this.lblMyCommentTime = new System.Windows.Forms.Label();
            this.pnlMyCommentControl = new System.Windows.Forms.Panel();
            this.flpFeedbackComment = new System.Windows.Forms.FlowLayoutPanel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlBackgroundDescription = new System.Windows.Forms.Panel();
            this.txtMyFeedbackComment = new System.Windows.Forms.TextBox();
            this.pnlMyFeedbackComments = new System.Windows.Forms.Panel();
            this.picOwnFeedbackCommentAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOwnCommentAvatar)).BeginInit();
            this.pnlMyComment.SuspendLayout();
            this.pnlMyCommentControl.SuspendLayout();
            this.pnlBackgroundDescription.SuspendLayout();
            this.pnlMyFeedbackComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOwnFeedbackCommentAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picOwnCommentAvatar
            // 
            this.picOwnCommentAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOwnCommentAvatar.Location = new System.Drawing.Point(8, 10);
            this.picOwnCommentAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picOwnCommentAvatar.Name = "picOwnCommentAvatar";
            this.picOwnCommentAvatar.Size = new System.Drawing.Size(40, 40);
            this.picOwnCommentAvatar.TabIndex = 1;
            this.picOwnCommentAvatar.TabStop = false;
            // 
            // lblOwnCommentName
            // 
            this.lblOwnCommentName.AutoSize = true;
            this.lblOwnCommentName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOwnCommentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnCommentName.Location = new System.Drawing.Point(6, 6);
            this.lblOwnCommentName.Name = "lblOwnCommentName";
            this.lblOwnCommentName.Size = new System.Drawing.Size(109, 16);
            this.lblOwnCommentName.TabIndex = 2;
            this.lblOwnCommentName.Text = "Huỳnh Ngọc Sơn";
            // 
            // pnlMyComment
            // 
            this.pnlMyComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlMyComment.Controls.Add(this.lblOwnCommentDesctiption);
            this.pnlMyComment.Controls.Add(this.lblOwnCommentName);
            this.pnlMyComment.Location = new System.Drawing.Point(63, 10);
            this.pnlMyComment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyComment.Name = "pnlMyComment";
            this.pnlMyComment.Size = new System.Drawing.Size(378, 57);
            this.pnlMyComment.TabIndex = 3;
            // 
            // lblOwnCommentDesctiption
            // 
            this.lblOwnCommentDesctiption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnCommentDesctiption.Location = new System.Drawing.Point(6, 25);
            this.lblOwnCommentDesctiption.Name = "lblOwnCommentDesctiption";
            this.lblOwnCommentDesctiption.Size = new System.Drawing.Size(369, 25);
            this.lblOwnCommentDesctiption.TabIndex = 3;
            this.lblOwnCommentDesctiption.Text = resources.GetString("lblOwnCommentDesctiption.Text");
            // 
            // beMyComment
            // 
            this.beMyComment.ElipseRadius = 26;
            this.beMyComment.TargetControl = this.pnlMyComment;
            // 
            // lblOwnMyCommentLike
            // 
            this.lblOwnMyCommentLike.AutoSize = true;
            this.lblOwnMyCommentLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOwnMyCommentLike.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnMyCommentLike.Location = new System.Drawing.Point(6, 1);
            this.lblOwnMyCommentLike.Name = "lblOwnMyCommentLike";
            this.lblOwnMyCommentLike.Size = new System.Drawing.Size(46, 16);
            this.lblOwnMyCommentLike.TabIndex = 4;
            this.lblOwnMyCommentLike.Text = "Thích";
            // 
            // lblOwnMyCommentFeedback
            // 
            this.lblOwnMyCommentFeedback.AutoSize = true;
            this.lblOwnMyCommentFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOwnMyCommentFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnMyCommentFeedback.Location = new System.Drawing.Point(58, 1);
            this.lblOwnMyCommentFeedback.Name = "lblOwnMyCommentFeedback";
            this.lblOwnMyCommentFeedback.Size = new System.Drawing.Size(53, 16);
            this.lblOwnMyCommentFeedback.TabIndex = 5;
            this.lblOwnMyCommentFeedback.Text = "Trả lời";
            this.lblOwnMyCommentFeedback.Click += new System.EventHandler(this.lblOwnMyCommentFeedback_Click);
            // 
            // lblMyCommentTime
            // 
            this.lblMyCommentTime.AutoSize = true;
            this.lblMyCommentTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMyCommentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyCommentTime.Location = new System.Drawing.Point(123, 1);
            this.lblMyCommentTime.Name = "lblMyCommentTime";
            this.lblMyCommentTime.Size = new System.Drawing.Size(37, 16);
            this.lblMyCommentTime.TabIndex = 6;
            this.lblMyCommentTime.Text = "7 giờ";
            // 
            // pnlMyCommentControl
            // 
            this.pnlMyCommentControl.Controls.Add(this.lblOwnMyCommentLike);
            this.pnlMyCommentControl.Controls.Add(this.lblMyCommentTime);
            this.pnlMyCommentControl.Controls.Add(this.lblOwnMyCommentFeedback);
            this.pnlMyCommentControl.Location = new System.Drawing.Point(63, 70);
            this.pnlMyCommentControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyCommentControl.Name = "pnlMyCommentControl";
            this.pnlMyCommentControl.Size = new System.Drawing.Size(375, 22);
            this.pnlMyCommentControl.TabIndex = 7;
            // 
            // flpFeedbackComment
            // 
            this.flpFeedbackComment.Location = new System.Drawing.Point(65, 92);
            this.flpFeedbackComment.Margin = new System.Windows.Forms.Padding(0);
            this.flpFeedbackComment.Name = "flpFeedbackComment";
            this.flpFeedbackComment.Size = new System.Drawing.Size(377, 58);
            this.flpFeedbackComment.TabIndex = 8;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this.pnlBackgroundDescription;
            // 
            // pnlBackgroundDescription
            // 
            this.pnlBackgroundDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlBackgroundDescription.Controls.Add(this.txtMyFeedbackComment);
            this.pnlBackgroundDescription.Location = new System.Drawing.Point(54, 2);
            this.pnlBackgroundDescription.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBackgroundDescription.Name = "pnlBackgroundDescription";
            this.pnlBackgroundDescription.Size = new System.Drawing.Size(323, 37);
            this.pnlBackgroundDescription.TabIndex = 12;
            // 
            // txtMyFeedbackComment
            // 
            this.txtMyFeedbackComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.txtMyFeedbackComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMyFeedbackComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMyFeedbackComment.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyFeedbackComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.txtMyFeedbackComment.Location = new System.Drawing.Point(11, 7);
            this.txtMyFeedbackComment.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.txtMyFeedbackComment.Name = "txtMyFeedbackComment";
            this.txtMyFeedbackComment.Size = new System.Drawing.Size(299, 41);
            this.txtMyFeedbackComment.TabIndex = 60;
            this.txtMyFeedbackComment.Text = "Viết bình luận...";
            this.txtMyFeedbackComment.Enter += new System.EventHandler(this.txtMyFeedbackComment_Enter);
            this.txtMyFeedbackComment.Leave += new System.EventHandler(this.txtMyFeedbackComment_Leave);
            // 
            // pnlMyFeedbackComments
            // 
            this.pnlMyFeedbackComments.Controls.Add(this.picOwnFeedbackCommentAvatar);
            this.pnlMyFeedbackComments.Controls.Add(this.pnlBackgroundDescription);
            this.pnlMyFeedbackComments.Location = new System.Drawing.Point(63, 150);
            this.pnlMyFeedbackComments.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyFeedbackComments.Name = "pnlMyFeedbackComments";
            this.pnlMyFeedbackComments.Size = new System.Drawing.Size(377, 44);
            this.pnlMyFeedbackComments.TabIndex = 9;
            // 
            // picOwnFeedbackCommentAvatar
            // 
            this.picOwnFeedbackCommentAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOwnFeedbackCommentAvatar.Location = new System.Drawing.Point(0, 0);
            this.picOwnFeedbackCommentAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picOwnFeedbackCommentAvatar.Name = "picOwnFeedbackCommentAvatar";
            this.picOwnFeedbackCommentAvatar.Size = new System.Drawing.Size(40, 40);
            this.picOwnFeedbackCommentAvatar.TabIndex = 11;
            this.picOwnFeedbackCommentAvatar.TabStop = false;
            // 
            // PostCommentItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.pnlMyFeedbackComments);
            this.Controls.Add(this.flpFeedbackComment);
            this.Controls.Add(this.pnlMyCommentControl);
            this.Controls.Add(this.pnlMyComment);
            this.Controls.Add(this.picOwnCommentAvatar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PostCommentItemUC";
            this.Size = new System.Drawing.Size(444, 196);
            ((System.ComponentModel.ISupportInitialize)(this.picOwnCommentAvatar)).EndInit();
            this.pnlMyComment.ResumeLayout(false);
            this.pnlMyComment.PerformLayout();
            this.pnlMyCommentControl.ResumeLayout(false);
            this.pnlMyCommentControl.PerformLayout();
            this.pnlBackgroundDescription.ResumeLayout(false);
            this.pnlBackgroundDescription.PerformLayout();
            this.pnlMyFeedbackComments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOwnFeedbackCommentAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picOwnCommentAvatar;
        private System.Windows.Forms.Label lblOwnCommentName;
        private System.Windows.Forms.Panel pnlMyComment;
        private System.Windows.Forms.Label lblOwnCommentDesctiption;
        private Bunifu.Framework.UI.BunifuElipse beMyComment;
        private System.Windows.Forms.Label lblOwnMyCommentLike;
        private System.Windows.Forms.Label lblOwnMyCommentFeedback;
        private System.Windows.Forms.Label lblMyCommentTime;
        private System.Windows.Forms.Panel pnlMyCommentControl;
        private System.Windows.Forms.FlowLayoutPanel flpFeedbackComment;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnlMyFeedbackComments;
        private System.Windows.Forms.PictureBox picOwnFeedbackCommentAvatar;
        private System.Windows.Forms.Panel pnlBackgroundDescription;
        private System.Windows.Forms.TextBox txtMyFeedbackComment;
    }
}
