using Facebook.Common;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostCommentUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private readonly ICommentDAO _commentDAO;
        private Post post;

        private List<Comment> comments;

        public PostCommentUC(ICommentDAO commentDAO, Post post)
        {
            InitializeComponent();

            this._commentDAO = commentDAO;
            this.post = post;

            Load();
        }

        private int margin = 10;

        #region Methods

        new private void Load()
        {
            comments = _commentDAO.GetByPostID(post.ID);

            pnlComment.Visible = false;

            LoadCommentList();

            SetUpUI();
            SetColor();
            UpdateHeight();
        }

        private void LoadCommentList()
        {
            if (comments != null && comments.Count > 0)
            {
                foreach (var item in comments)
                {
                    var commentItem = new PostCommentItemUC(item);

                    flpComment.Controls.Add(commentItem);
                }
            }
        }

        private void SetUpUI()
        {
            picLike.BackgroundImage = Image.FromFile("./../../Assets/Images/Comment/Facebook-Like.png");
            picLike.BackgroundImageLayout = ImageLayout.Stretch;
            picLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            picTextBox.BackgroundImage = Image.FromFile("./../../Assets/Images/Comment/textbox-blank.jpg");     // Cần cắt hình ảnh và chèn vào
            picTextBox.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            // Head
            lblLikeCount.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblLikeCount.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            lblCommentCount.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblCommentCount.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            lblShareCount.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblShareCount.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            // Middle
            btnLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnLike.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblLike.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            btnComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnComment.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblComment.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            btnShare.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnShare.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblShare.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblShare.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            // MyComment
            picMyCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, Constants.UserSession);
            picMyCommentAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            txtMyCommentDescription.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            picTextBox.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            // Separator
            pnlSeparator1.Height = pnlSeparator2.Height = 1;
            pnlSeparator1.BackColor = Constants.BORDER_BOX_COLOR;
            pnlSeparator2.BackColor = Constants.BORDER_BOX_COLOR;
        }

        private void UpdateHeight()
        {
            var mar = margin * 2;
            var heightHead = pnlHead.Height;
            var heightSeparator = pnlSeparator1.Height;
            var heightMiddle = pnlMiddle.Height;
            var heightMyComment = 0;
            var heightItems = 0;

            if (pnlComment.Visible)
            {
                heightMyComment = pnlMyComment.Height;
                heightSeparator += pnlSeparator2.Height;

                foreach (Control item in flpComment.Controls)
                {
                    heightItems += item.Height + item.Margin.Bottom;
                }

            }

            this.Height = mar + heightHead + heightSeparator + heightMiddle + heightMyComment + heightItems;
            pnlWrap.Height = this.Height - mar;
        }



        #endregion Methods

        #region UI

        private void btnLike_MouseEnter(object sender, EventArgs e)
        {
            pnlSectionLike.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            btnLike.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            lblLike.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
        }

        private void btnComment_MouseEnter(object sender, EventArgs e)
        {
            pnlSectionComment.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            btnComment.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            lblComment.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
        }

        private void btnShare_MouseEnter(object sender, EventArgs e)
        {
            pnlSectionShare.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            btnShare.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
            lblShare.BackColor = Constants.BACKGROUND_POSTSTATUS_HOVER_COLOR;
        }

        private void pnlSectionLike_MouseLeave(object sender, EventArgs e)
        {
            pnlSectionLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void pnlSectionComment_MouseLeave(object sender, EventArgs e)
        {
            pnlSectionComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void pnlSectionShare_MouseLeave(object sender, EventArgs e)
        {
            pnlSectionShare.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnShare.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblShare.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        #endregion UI

        /// <summary>
        /// Lúc đầu chưa có comment nào, khi click vào thì hiện lên tất cả các comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSectionComment_Click(object sender, EventArgs e)
        {
            pnlComment.Visible = !pnlComment.Visible;

            UpdateHeight();
            OnHeightChanged?.Invoke();
        }
    }
}