
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostCommentItemUC));
            this.picOwnCommentAvatar = new System.Windows.Forms.PictureBox();
            this.lblOwnCommentName = new System.Windows.Forms.Label();
            this.pnlMyComment = new System.Windows.Forms.Panel();
            this.lblOwnCommentDesctiption = new System.Windows.Forms.Label();
            this.lblOwnMyCommentLike = new System.Windows.Forms.Label();
            this.lblOwnMyCommentFeedback = new System.Windows.Forms.Label();
            this.lblMyCommentTime = new System.Windows.Forms.Label();
            this.pnlMyCommentControl = new System.Windows.Forms.Panel();
            this.lblLikeCount = new System.Windows.Forms.Label();
            this.picLike = new System.Windows.Forms.PictureBox();
            this.flpFeedbackComment = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBackgroundDescription = new System.Windows.Forms.Panel();
            this.txtMyFeedbackComment = new System.Windows.Forms.TextBox();
            this.pnlMyFeedbackComments = new System.Windows.Forms.Panel();
            this.picOwnFeedbackCommentAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOwnCommentAvatar)).BeginInit();
            this.pnlMyComment.SuspendLayout();
            this.pnlMyCommentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLike)).BeginInit();
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
            this.picOwnCommentAvatar.Click += new System.EventHandler(this.picOwnCommentAvatar_Click);
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
            this.lblOwnCommentName.Click += new System.EventHandler(this.lblOwnCommentName_Click);
            // 
            // pnlMyComment
            // 
            this.pnlMyComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlMyComment.Controls.Add(this.lblOwnCommentDesctiption);
            this.pnlMyComment.Controls.Add(this.lblOwnCommentName);
            this.pnlMyComment.Location = new System.Drawing.Point(63, 10);
            this.pnlMyComment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyComment.Name = "pnlMyComment";
            this.pnlMyComment.Size = new System.Drawing.Size(378, 71);
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
            this.lblOwnMyCommentLike.Click += new System.EventHandler(this.lblOwnMyCommentLike_Click);
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
            this.pnlMyCommentControl.Controls.Add(this.lblLikeCount);
            this.pnlMyCommentControl.Controls.Add(this.picLike);
            this.pnlMyCommentControl.Controls.Add(this.lblOwnMyCommentLike);
            this.pnlMyCommentControl.Controls.Add(this.lblMyCommentTime);
            this.pnlMyCommentControl.Controls.Add(this.lblOwnMyCommentFeedback);
            this.pnlMyCommentControl.Location = new System.Drawing.Point(63, 80);
            this.pnlMyCommentControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyCommentControl.Name = "pnlMyCommentControl";
            this.pnlMyCommentControl.Size = new System.Drawing.Size(375, 22);
            this.pnlMyCommentControl.TabIndex = 7;
            // 
            // lblLikeCount
            // 
            this.lblLikeCount.AutoSize = true;
            this.lblLikeCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLikeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLikeCount.Location = new System.Drawing.Point(353, 0);
            this.lblLikeCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblLikeCount.Name = "lblLikeCount";
            this.lblLikeCount.Size = new System.Drawing.Size(32, 16);
            this.lblLikeCount.TabIndex = 7;
            this.lblLikeCount.Text = "100";
            // 
            // picLike
            // 
            this.picLike.Location = new System.Drawing.Point(334, 0);
            this.picLike.Margin = new System.Windows.Forms.Padding(0);
            this.picLike.Name = "picLike";
            this.picLike.Size = new System.Drawing.Size(15, 15);
            this.picLike.TabIndex = 4;
            this.picLike.TabStop = false;
            // 
            // flpFeedbackComment
            // 
            this.flpFeedbackComment.Location = new System.Drawing.Point(65, 102);
            this.flpFeedbackComment.Margin = new System.Windows.Forms.Padding(0);
            this.flpFeedbackComment.Name = "flpFeedbackComment";
            this.flpFeedbackComment.Size = new System.Drawing.Size(377, 58);
            this.flpFeedbackComment.TabIndex = 8;
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
            this.txtMyFeedbackComment.Font = new System.Drawing.Font("Consolas", 21.75F);
            this.txtMyFeedbackComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.txtMyFeedbackComment.Location = new System.Drawing.Point(11, 9);
            this.txtMyFeedbackComment.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.txtMyFeedbackComment.Name = "txtMyFeedbackComment";
            this.txtMyFeedbackComment.Size = new System.Drawing.Size(299, 34);
            this.txtMyFeedbackComment.TabIndex = 60;
            this.txtMyFeedbackComment.Text = "Viết bình luận...";
            this.txtMyFeedbackComment.TextChanged += new System.EventHandler(this.txtMyCommentDescription_TextChanged);
            this.txtMyFeedbackComment.Enter += new System.EventHandler(this.txtMyFeedbackComment_Enter);
            this.txtMyFeedbackComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMyCommentDescription_KeyPress);
            this.txtMyFeedbackComment.Leave += new System.EventHandler(this.txtMyFeedbackComment_Leave);
            // 
            // pnlMyFeedbackComments
            // 
            this.pnlMyFeedbackComments.Controls.Add(this.picOwnFeedbackCommentAvatar);
            this.pnlMyFeedbackComments.Controls.Add(this.pnlBackgroundDescription);
            this.pnlMyFeedbackComments.Location = new System.Drawing.Point(63, 160);
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
            this.picOwnFeedbackCommentAvatar.Click += new System.EventHandler(this.picOwnFeedbackCommentAvatar_Click);
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
            this.Size = new System.Drawing.Size(444, 219);
            ((System.ComponentModel.ISupportInitialize)(this.picOwnCommentAvatar)).EndInit();
            this.pnlMyComment.ResumeLayout(false);
            this.pnlMyComment.PerformLayout();
            this.pnlMyCommentControl.ResumeLayout(false);
            this.pnlMyCommentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLike)).EndInit();
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
        private System.Windows.Forms.Label lblOwnMyCommentLike;
        private System.Windows.Forms.Label lblOwnMyCommentFeedback;
        private System.Windows.Forms.Label lblMyCommentTime;
        private System.Windows.Forms.Panel pnlMyCommentControl;
        private System.Windows.Forms.FlowLayoutPanel flpFeedbackComment;
        private System.Windows.Forms.Panel pnlMyFeedbackComments;
        private System.Windows.Forms.PictureBox picOwnFeedbackCommentAvatar;
        private System.Windows.Forms.Panel pnlBackgroundDescription;
        private System.Windows.Forms.TextBox txtMyFeedbackComment;
        private System.Windows.Forms.PictureBox picLike;
        private System.Windows.Forms.Label lblLikeCount;
    }
}
