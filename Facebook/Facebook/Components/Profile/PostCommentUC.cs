using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostCommentUC : UserControl
    {
        public delegate void HeightChanged();
        public delegate void ClickProfileFriend(User user);
        public event HeightChanged OnHeightChanged;
        public event ClickProfileFriend OnClickProfileFriend;

        private readonly IPostDAO _postDAO;
        private readonly ICommentDAO _commentDAO;
        private Post post;

        private List<Comment> comments;
        private List<int> likes; // danh sách các userID đã like bài viết
        private List<int> shares; // danh sách các userID đã share bài viết

        private bool isSubmit;

        public PostCommentUC(IPostDAO postDAO, ICommentDAO commentDAO, Post post)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this._postDAO = postDAO;
            this._commentDAO = commentDAO;
            this.post = post;

            Load();
        }

        private int margin = 10;
        private string STRING_COMPARE = "Viết bình luận...";
        #region Methods

        new private void Load()
        {
            comments = _commentDAO.GetByPostID(post.ID);

            pnlComment.Visible = false;

            LoadPanelHead();
            LoadCommentList();

            SetUpUI();
            SetColor();
            UpdateHeight();
            SetLike();

            UIHelper.SetBlur(this, () => this.ActiveControl = null);
            UIHelper.BorderRadius(pnlSectionLike, Constants.BORDER_RADIUS_SECTION_LIKE);
            UIHelper.BorderRadius(pnlSectionComment, Constants.BORDER_RADIUS_SECTION_LIKE);
            UIHelper.BorderRadius(pnlSectionShare, Constants.BORDER_RADIUS_SECTION_LIKE);
        }

        /// <summary>
        /// Like count, comment  count,  share count
        /// </summary>
        private void LoadPanelHead()
        {
            // Like count
            likes = new List<int>();
            if (post.Like != null)
            {
                likes = StringHelper.StringToStringList(post.Like).Select(i => Convert.ToInt32(i)).ToList();
            }

            lblLikeCount.Text = likes.Count.ToString();

            // Comment count
            lblCommentCount.Text = comments.Count.ToString() + " Comments";

            // Share count
            shares = new List<int>();
            if (post.Share != null)
            {
                shares = StringHelper.StringToStringList(post.Share).Select(i => Convert.ToInt32(i)).ToList();
            }

            lblShareCount.Text = shares.Count.ToString() + " Shares";

        }

        private void LoadCommentList()
        {
            if (comments != null && comments.Count > 0)
            {
                foreach (var item in comments)
                {
                    var commentItem = new PostCommentItemUC(AutofacFactory<ICommentFeedbackDAO>.Get(), item);
                    commentItem.Margin = new Padding(0, 0, 0, 0);
                    commentItem.OnHeightChanged += CommentItem_OnHeightChanged;
                    commentItem.OnClickProfileFriend += (u) => OnClickProfileFriend?.Invoke(u);

                    flpComment.Controls.Add(commentItem);
                }
            }
        }

        private void SetUpUI()
        {
            try
            {
                picLike.BackgroundImage = ImageHelper.FromFile("./../../Assets/Images/Comment/Facebook-Like.png");
                picLike.BackgroundImageLayout = ImageLayout.Stretch;
                picLike.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
                pnlWrapDescription.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
                UIHelper.BorderRadius(pnlWrapDescription, Constants.BORDER_RADIUS);
            }
            catch (Exception)
            {

            }
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

        /// <summary>
        /// Set color dựa vào likes
        /// Set lblLikeCount trên head
        /// </summary>
        private void SetLike()
        {
            // Nếu UserSession ID mà tồn tại trong Like comment thì màu xanh
            var userID = Constants.UserSession.ID;
            var check = likes.Any(l => l == userID);

            if (check)
            {
                btnLike.IconColor = Constants.LIKED_FORECOLOR;
                lblLike.ForeColor = Constants.LIKED_FORECOLOR;
            }
            else
            {
                btnLike.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
                lblLike.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            }

            lblLikeCount.Text = likes.Count.ToString();
        }

        public void UpdateAvatar()
        {
            picMyCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, Constants.UserSession);

            foreach (PostCommentItemUC item in flpComment.Controls)
            {
                item.UpdateAvatar();
            }
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

        #region Events

        /// <summary>
        /// Lúc đầu chưa có comment nào, khi click vào thì hiện lên tất cả các comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSectionComment_Click(object sender, EventArgs e)
        {
            pnlComment.Visible = !pnlComment.Visible;

            txtMyCommentDescription.Text = "Viết bình luận...";

            UpdateHeight();
            OnHeightChanged?.Invoke();

        }

        private void CommentItem_OnHeightChanged()
        {
            UpdateHeight();
            OnHeightChanged?.Invoke();
        }

        private void txtMyFeedbackComment_Enter(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var text = txt.Text;
            txt.ForeColor = Constants.MAIN_FORE_COLOR;

            if (string.Equals(text.Trim(), STRING_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txt.Text = "";
            }
        }

        private void txtMyFeedbackComment_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var text = txt.Text;
            txt.ForeColor = Constants.PLACEHOLDER_FORECOLOR;

            if (text.Trim() == "")
            {
                txt.Text = STRING_COMPARE;
            }
        }

        /// <summary>
        /// Nếu đã like thì unlike
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLike_Click(object sender, EventArgs e)
        {
            var check = likes.Any(l => l == Constants.UserSession.ID);

            if (check)
            {
                likes.Remove(Constants.UserSession.ID);
            }
            else
            {
                likes.Add(Constants.UserSession.ID);
            }

            SetLike();

            // Cập  nhật DB
            post.Like = StringHelper.StringListToString(likes.Select(l => l.ToString()).ToList());
            _postDAO.SaveChanges();
        }

        /// <summary>
        /// Nếu bài viết là của chủ thì không share
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSectionShare_Click(object sender, EventArgs e)
        {
            if (post.User.ID == Constants.UserSession.ID)
            {
                MyMessageBox.Show("Không thể share!", MessageBoxType.Warning);
            }
        }

        private void txtMyCommentDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                isSubmit = true;
                txtMyCommentDescription_TextChanged(null, null);
            }
        }

        private void txtMyCommentDescription_TextChanged(object sender, EventArgs e)
        {
            if (isSubmit)
            {
                isSubmit = false;
                var text = txtMyCommentDescription.Text;
                txtMyCommentDescription.Text = "";
                if (string.IsNullOrEmpty(text.Trim()))
                {

                    return;
                }

                var cmt = new Comment()
                {
                    Description = text,
                    CreatedAt = DateTime.Now,
                    Like = null,
                    PostID = post.ID,
                    User = Constants.UserSession
                };
                // add vào comments của ui
                comments.Add(cmt);

                // Cập nhật lblCommentCount
                lblCommentCount.Text = $"{comments.Count} Comments";

                // add vào List ui 
                var commentItem = new PostCommentItemUC(AutofacFactory<ICommentFeedbackDAO>.Get(), cmt);
                commentItem.Margin = new Padding(0, 0, 0, 0);
                commentItem.OnHeightChanged += CommentItem_OnHeightChanged;

                flpComment.Controls.Add(commentItem);

                // Save db
                _commentDAO.Create(cmt);

                UpdateHeight();
                OnHeightChanged?.Invoke();
            }
        }

        #endregion

        private void picMyCommentAvatar_Click(object sender, EventArgs e)
        {
            OnClickProfileFriend?.Invoke(post.User);
        }
    }
}