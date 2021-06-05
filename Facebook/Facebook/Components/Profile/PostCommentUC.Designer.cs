
namespace Facebook.Components.Profile
{
    partial class PostCommentUC
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
            this.pnlWrap = new System.Windows.Forms.Panel();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.pnlSeparator1 = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlSeparator2 = new System.Windows.Forms.Panel();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.picLike = new System.Windows.Forms.PictureBox();
            this.lblLikeCount = new System.Windows.Forms.Label();
            this.lblCommentCount = new System.Windows.Forms.Label();
            this.lblShareCount = new System.Windows.Forms.Label();
            this.btnLike = new FontAwesome.Sharp.IconPictureBox();
            this.lblLike = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnComment = new FontAwesome.Sharp.IconPictureBox();
            this.lblShare = new System.Windows.Forms.Label();
            this.btnShare = new FontAwesome.Sharp.IconPictureBox();
            this.pnlMyComment = new System.Windows.Forms.Panel();
            this.picMyCommentAvatar = new System.Windows.Forms.PictureBox();
            this.picTextBox = new System.Windows.Forms.PictureBox();
            this.txtMyCommentDescription = new System.Windows.Forms.TextBox();
            this.pnlSectionLike = new System.Windows.Forms.Panel();
            this.pnlSectionComment = new System.Windows.Forms.Panel();
            this.pnlSectionShare = new System.Windows.Forms.Panel();
            this.flpComment = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlWrap.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShare)).BeginInit();
            this.pnlMyComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMyCommentAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTextBox)).BeginInit();
            this.pnlSectionLike.SuspendLayout();
            this.pnlSectionComment.SuspendLayout();
            this.pnlSectionShare.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWrap
            // 
            this.pnlWrap.Controls.Add(this.pnlComment);
            this.pnlWrap.Controls.Add(this.pnlSeparator2);
            this.pnlWrap.Controls.Add(this.pnlMiddle);
            this.pnlWrap.Controls.Add(this.pnlSeparator1);
            this.pnlWrap.Controls.Add(this.pnlHead);
            this.pnlWrap.Location = new System.Drawing.Point(10, 10);
            this.pnlWrap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWrap.Name = "pnlWrap";
            this.pnlWrap.Size = new System.Drawing.Size(444, 342);
            this.pnlWrap.TabIndex = 0;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.lblShareCount);
            this.pnlHead.Controls.Add(this.lblCommentCount);
            this.pnlHead.Controls.Add(this.lblLikeCount);
            this.pnlHead.Controls.Add(this.picLike);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(444, 50);
            this.pnlHead.TabIndex = 0;
            // 
            // pnlSeparator1
            // 
            this.pnlSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator1.Location = new System.Drawing.Point(0, 50);
            this.pnlSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeparator1.Name = "pnlSeparator1";
            this.pnlSeparator1.Size = new System.Drawing.Size(444, 5);
            this.pnlSeparator1.TabIndex = 1;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlSectionShare);
            this.pnlMiddle.Controls.Add(this.pnlSectionComment);
            this.pnlMiddle.Controls.Add(this.pnlSectionLike);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 55);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(444, 50);
            this.pnlMiddle.TabIndex = 2;
            // 
            // pnlSeparator2
            // 
            this.pnlSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator2.Location = new System.Drawing.Point(0, 105);
            this.pnlSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeparator2.Name = "pnlSeparator2";
            this.pnlSeparator2.Size = new System.Drawing.Size(444, 5);
            this.pnlSeparator2.TabIndex = 3;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.flpComment);
            this.pnlComment.Controls.Add(this.pnlMyComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComment.Location = new System.Drawing.Point(0, 110);
            this.pnlComment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(444, 232);
            this.pnlComment.TabIndex = 4;
            // 
            // picLike
            // 
            this.picLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLike.Location = new System.Drawing.Point(16, 16);
            this.picLike.Margin = new System.Windows.Forms.Padding(0);
            this.picLike.Name = "picLike";
            this.picLike.Size = new System.Drawing.Size(23, 23);
            this.picLike.TabIndex = 0;
            this.picLike.TabStop = false;
            // 
            // lblLikeCount
            // 
            this.lblLikeCount.AutoSize = true;
            this.lblLikeCount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblLikeCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLikeCount.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLikeCount.Location = new System.Drawing.Point(45, 20);
            this.lblLikeCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblLikeCount.Name = "lblLikeCount";
            this.lblLikeCount.Size = new System.Drawing.Size(56, 15);
            this.lblLikeCount.TabIndex = 65;
            this.lblLikeCount.Text = "376.063";
            // 
            // lblCommentCount
            // 
            this.lblCommentCount.AutoSize = true;
            this.lblCommentCount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblCommentCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCommentCount.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentCount.Location = new System.Drawing.Point(208, 20);
            this.lblCommentCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCommentCount.Name = "lblCommentCount";
            this.lblCommentCount.Size = new System.Drawing.Size(112, 15);
            this.lblCommentCount.TabIndex = 66;
            this.lblCommentCount.Text = "94.330 Comments";
            // 
            // lblShareCount
            // 
            this.lblShareCount.AutoSize = true;
            this.lblShareCount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblShareCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShareCount.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShareCount.Location = new System.Drawing.Point(342, 20);
            this.lblShareCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblShareCount.Name = "lblShareCount";
            this.lblShareCount.Size = new System.Drawing.Size(98, 15);
            this.lblShareCount.TabIndex = 67;
            this.lblShareCount.Text = "11.813 Shares";
            // 
            // btnLike
            // 
            this.btnLike.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLike.IconChar = FontAwesome.Sharp.IconChar.HandPointLeft;
            this.btnLike.IconColor = System.Drawing.SystemColors.ControlText;
            this.btnLike.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLike.IconSize = 30;
            this.btnLike.Location = new System.Drawing.Point(40, 8);
            this.btnLike.Margin = new System.Windows.Forms.Padding(0);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(30, 30);
            this.btnLike.TabIndex = 0;
            this.btnLike.TabStop = false;
            this.btnLike.MouseEnter += new System.EventHandler(this.btnLike_MouseEnter);
            // 
            // lblLike
            // 
            this.lblLike.AutoSize = true;
            this.lblLike.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLike.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLike.Location = new System.Drawing.Point(72, 15);
            this.lblLike.Margin = new System.Windows.Forms.Padding(0);
            this.lblLike.Name = "lblLike";
            this.lblLike.Size = new System.Drawing.Size(35, 15);
            this.lblLike.TabIndex = 67;
            this.lblLike.Text = "Like";
            this.lblLike.MouseEnter += new System.EventHandler(this.btnLike_MouseEnter);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblComment.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(66, 15);
            this.lblComment.Margin = new System.Windows.Forms.Padding(0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(56, 15);
            this.lblComment.TabIndex = 69;
            this.lblComment.Text = "Comment";
            this.lblComment.Click += new System.EventHandler(this.pnlSectionComment_Click);
            this.lblComment.MouseEnter += new System.EventHandler(this.btnComment_MouseEnter);
            // 
            // btnComment
            // 
            this.btnComment.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnComment.IconChar = FontAwesome.Sharp.IconChar.Comment;
            this.btnComment.IconColor = System.Drawing.SystemColors.ControlText;
            this.btnComment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnComment.IconSize = 30;
            this.btnComment.Location = new System.Drawing.Point(34, 8);
            this.btnComment.Margin = new System.Windows.Forms.Padding(0);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(30, 30);
            this.btnComment.TabIndex = 68;
            this.btnComment.TabStop = false;
            this.btnComment.Click += new System.EventHandler(this.pnlSectionComment_Click);
            this.btnComment.MouseEnter += new System.EventHandler(this.btnComment_MouseEnter);
            // 
            // lblShare
            // 
            this.lblShare.AutoSize = true;
            this.lblShare.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShare.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShare.Location = new System.Drawing.Point(69, 15);
            this.lblShare.Margin = new System.Windows.Forms.Padding(0);
            this.lblShare.Name = "lblShare";
            this.lblShare.Size = new System.Drawing.Size(42, 15);
            this.lblShare.TabIndex = 71;
            this.lblShare.Text = "Share";
            this.lblShare.MouseEnter += new System.EventHandler(this.btnShare_MouseEnter);
            // 
            // btnShare
            // 
            this.btnShare.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShare.IconChar = FontAwesome.Sharp.IconChar.Share;
            this.btnShare.IconColor = System.Drawing.SystemColors.ControlText;
            this.btnShare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShare.IconSize = 30;
            this.btnShare.Location = new System.Drawing.Point(37, 8);
            this.btnShare.Margin = new System.Windows.Forms.Padding(0);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(30, 30);
            this.btnShare.TabIndex = 70;
            this.btnShare.TabStop = false;
            this.btnShare.MouseEnter += new System.EventHandler(this.btnShare_MouseEnter);
            // 
            // pnlMyComment
            // 
            this.pnlMyComment.Controls.Add(this.txtMyCommentDescription);
            this.pnlMyComment.Controls.Add(this.picTextBox);
            this.pnlMyComment.Controls.Add(this.picMyCommentAvatar);
            this.pnlMyComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMyComment.Location = new System.Drawing.Point(0, 0);
            this.pnlMyComment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMyComment.Name = "pnlMyComment";
            this.pnlMyComment.Size = new System.Drawing.Size(444, 50);
            this.pnlMyComment.TabIndex = 0;
            // 
            // picMyCommentAvatar
            // 
            this.picMyCommentAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMyCommentAvatar.Location = new System.Drawing.Point(9, 5);
            this.picMyCommentAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.picMyCommentAvatar.Name = "picMyCommentAvatar";
            this.picMyCommentAvatar.Size = new System.Drawing.Size(40, 40);
            this.picMyCommentAvatar.TabIndex = 0;
            this.picMyCommentAvatar.TabStop = false;
            // 
            // picTextBox
            // 
            this.picTextBox.Location = new System.Drawing.Point(63, 5);
            this.picTextBox.Name = "picTextBox";
            this.picTextBox.Size = new System.Drawing.Size(377, 41);
            this.picTextBox.TabIndex = 1;
            this.picTextBox.TabStop = false;
            // 
            // txtMyCommentDescription
            // 
            this.txtMyCommentDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(229)))));
            this.txtMyCommentDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMyCommentDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMyCommentDescription.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyCommentDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.txtMyCommentDescription.Location = new System.Drawing.Point(72, 18);
            this.txtMyCommentDescription.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.txtMyCommentDescription.Name = "txtMyCommentDescription";
            this.txtMyCommentDescription.Size = new System.Drawing.Size(360, 34);
            this.txtMyCommentDescription.TabIndex = 60;
            this.txtMyCommentDescription.Text = "Viết bình luận...";
            // 
            // pnlSectionLike
            // 
            this.pnlSectionLike.Controls.Add(this.btnLike);
            this.pnlSectionLike.Controls.Add(this.lblLike);
            this.pnlSectionLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSectionLike.Location = new System.Drawing.Point(3, 3);
            this.pnlSectionLike.Name = "pnlSectionLike";
            this.pnlSectionLike.Size = new System.Drawing.Size(145, 44);
            this.pnlSectionLike.TabIndex = 0;
            this.pnlSectionLike.MouseEnter += new System.EventHandler(this.btnLike_MouseEnter);
            this.pnlSectionLike.MouseLeave += new System.EventHandler(this.pnlSectionLike_MouseLeave);
            // 
            // pnlSectionComment
            // 
            this.pnlSectionComment.Controls.Add(this.btnComment);
            this.pnlSectionComment.Controls.Add(this.lblComment);
            this.pnlSectionComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSectionComment.Location = new System.Drawing.Point(149, 3);
            this.pnlSectionComment.Name = "pnlSectionComment";
            this.pnlSectionComment.Size = new System.Drawing.Size(145, 44);
            this.pnlSectionComment.TabIndex = 1;
            this.pnlSectionComment.Click += new System.EventHandler(this.pnlSectionComment_Click);
            this.pnlSectionComment.MouseEnter += new System.EventHandler(this.btnComment_MouseEnter);
            this.pnlSectionComment.MouseLeave += new System.EventHandler(this.pnlSectionComment_MouseLeave);
            // 
            // pnlSectionShare
            // 
            this.pnlSectionShare.Controls.Add(this.lblShare);
            this.pnlSectionShare.Controls.Add(this.btnShare);
            this.pnlSectionShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSectionShare.Location = new System.Drawing.Point(295, 3);
            this.pnlSectionShare.Name = "pnlSectionShare";
            this.pnlSectionShare.Size = new System.Drawing.Size(145, 44);
            this.pnlSectionShare.TabIndex = 1;
            this.pnlSectionShare.MouseEnter += new System.EventHandler(this.btnShare_MouseEnter);
            this.pnlSectionShare.MouseLeave += new System.EventHandler(this.pnlSectionShare_MouseLeave);
            // 
            // flpComment
            // 
            this.flpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpComment.Location = new System.Drawing.Point(0, 50);
            this.flpComment.Margin = new System.Windows.Forms.Padding(0);
            this.flpComment.Name = "flpComment";
            this.flpComment.Size = new System.Drawing.Size(444, 182);
            this.flpComment.TabIndex = 1;
            // 
            // PostCommentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.pnlWrap);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PostCommentUC";
            this.Size = new System.Drawing.Size(464, 366);
            this.pnlWrap.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShare)).EndInit();
            this.pnlMyComment.ResumeLayout(false);
            this.pnlMyComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMyCommentAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTextBox)).EndInit();
            this.pnlSectionLike.ResumeLayout(false);
            this.pnlSectionLike.PerformLayout();
            this.pnlSectionComment.ResumeLayout(false);
            this.pnlSectionComment.PerformLayout();
            this.pnlSectionShare.ResumeLayout(false);
            this.pnlSectionShare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrap;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlSeparator1;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlSeparator2;
        private System.Windows.Forms.Panel pnlComment;
        private System.Windows.Forms.PictureBox picLike;
        private System.Windows.Forms.Label lblLikeCount;
        private System.Windows.Forms.Label lblCommentCount;
        private System.Windows.Forms.Label lblShareCount;
        private System.Windows.Forms.Label lblLike;
        private FontAwesome.Sharp.IconPictureBox btnLike;
        private System.Windows.Forms.Label lblShare;
        private FontAwesome.Sharp.IconPictureBox btnShare;
        private System.Windows.Forms.Label lblComment;
        private FontAwesome.Sharp.IconPictureBox btnComment;
        private System.Windows.Forms.Panel pnlMyComment;
        private System.Windows.Forms.PictureBox picMyCommentAvatar;
        private System.Windows.Forms.PictureBox picTextBox;
        private System.Windows.Forms.TextBox txtMyCommentDescription;
        private System.Windows.Forms.Panel pnlSectionShare;
        private System.Windows.Forms.Panel pnlSectionComment;
        private System.Windows.Forms.Panel pnlSectionLike;
        private System.Windows.Forms.FlowLayoutPanel flpComment;
    }
}
