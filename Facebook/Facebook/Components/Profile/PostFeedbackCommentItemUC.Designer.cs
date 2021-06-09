
namespace Facebook.Components.Profile
{
    partial class PostFeedbackCommentItemUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostFeedbackCommentItemUC));
            this.pnlFeedbackComment = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlMyCommentControl = new System.Windows.Forms.Panel();
            this.lblLikeCount = new System.Windows.Forms.Label();
            this.picLike = new System.Windows.Forms.PictureBox();
            this.lblLike = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlFeedbackComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlMyCommentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLike)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFeedbackComment
            // 
            this.pnlFeedbackComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlFeedbackComment.Controls.Add(this.lblDescription);
            this.pnlFeedbackComment.Controls.Add(this.lblName);
            this.pnlFeedbackComment.Location = new System.Drawing.Point(54, 0);
            this.pnlFeedbackComment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFeedbackComment.Name = "pnlFeedbackComment";
            this.pnlFeedbackComment.Size = new System.Drawing.Size(322, 133);
            this.pnlFeedbackComment.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(6, 26);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(309, 85);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Huỳnh Ngọc Sơn";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(0, 0);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(40, 40);
            this.picAvatar.TabIndex = 4;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // pnlMyCommentControl
            // 
            this.pnlMyCommentControl.Controls.Add(this.lblLikeCount);
            this.pnlMyCommentControl.Controls.Add(this.picLike);
            this.pnlMyCommentControl.Controls.Add(this.lblLike);
            this.pnlMyCommentControl.Controls.Add(this.lblTime);
            this.pnlMyCommentControl.Location = new System.Drawing.Point(54, 144);
            this.pnlMyCommentControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyCommentControl.Name = "pnlMyCommentControl";
            this.pnlMyCommentControl.Size = new System.Drawing.Size(318, 22);
            this.pnlMyCommentControl.TabIndex = 8;
            // 
            // lblLikeCount
            // 
            this.lblLikeCount.AutoSize = true;
            this.lblLikeCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLikeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLikeCount.Location = new System.Drawing.Point(297, 0);
            this.lblLikeCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblLikeCount.Name = "lblLikeCount";
            this.lblLikeCount.Size = new System.Drawing.Size(32, 16);
            this.lblLikeCount.TabIndex = 9;
            this.lblLikeCount.Text = "100";
            // 
            // picLike
            // 
            this.picLike.Location = new System.Drawing.Point(278, 0);
            this.picLike.Margin = new System.Windows.Forms.Padding(0);
            this.picLike.Name = "picLike";
            this.picLike.Size = new System.Drawing.Size(15, 15);
            this.picLike.TabIndex = 8;
            this.picLike.TabStop = false;
            // 
            // lblLike
            // 
            this.lblLike.AutoSize = true;
            this.lblLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLike.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLike.Location = new System.Drawing.Point(6, -2);
            this.lblLike.Name = "lblLike";
            this.lblLike.Size = new System.Drawing.Size(46, 16);
            this.lblLike.TabIndex = 4;
            this.lblLike.Text = "Thích";
            this.lblLike.Click += new System.EventHandler(this.lblLike_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(69, -2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(37, 16);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "7 giờ";
            // 
            // PostFeedbackCommentItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.pnlMyCommentControl);
            this.Controls.Add(this.pnlFeedbackComment);
            this.Controls.Add(this.picAvatar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PostFeedbackCommentItemUC";
            this.Size = new System.Drawing.Size(375, 188);
            this.pnlFeedbackComment.ResumeLayout(false);
            this.pnlFeedbackComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlMyCommentControl.ResumeLayout(false);
            this.pnlMyCommentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLike)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFeedbackComment;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlMyCommentControl;
        private System.Windows.Forms.Label lblLike;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblLikeCount;
        private System.Windows.Forms.PictureBox picLike;
    }
}
