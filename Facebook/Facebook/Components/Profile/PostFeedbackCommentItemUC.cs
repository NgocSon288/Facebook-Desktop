using Facebook.Common;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostFeedbackCommentItemUC : UserControl
    {
        public delegate void ClickProfileFriend(User user);
        public event ClickProfileFriend OnClickProfileFriend;

        private readonly ICommentFeedbackDAO _commentFeedbackDAO;
        private CommentFeedback commentFeedback;

        private List<int> likes;    // danh sách các user like

        public PostFeedbackCommentItemUC(ICommentFeedbackDAO commentFeedbackDAO, CommentFeedback CommentFeedback)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this._commentFeedbackDAO = commentFeedbackDAO;
            this.commentFeedback = CommentFeedback;

            Load();
        }

        int ch = 50;

        #region Medthods

        new private void Load()
        {
            if (commentFeedback.Like != null)
            {
                likes = StringHelper.StringToStringList(commentFeedback.Like).Select(s => Convert.ToInt32(s)).ToList();
            }
            else
            {
                likes = new List<int>();
            }

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, commentFeedback.User);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = commentFeedback.User.Name;
            lblDescription.Text = commentFeedback.Description;
            lblDescription.Height = GetHeightTextBox(lblDescription.Text);
            pnlFeedbackComment.Height = lblDescription.Bottom + 10;

            lblTime.Text = GetTime(commentFeedback.CreatedAt);

            // Like count
            picLike.BackgroundImage = ImageHelper.FromFile("./../../Assets/Images/Comment/Facebook-Like.png");
            picLike.BackgroundImageLayout = ImageLayout.Stretch;
            lblLikeCount.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblLikeCount.Text = likes.Count.ToString();
            lblLikeCount.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            SetColor();
            UpdateHeight();
            SetColorLike();

            UIHelper.BorderRadius(pnlFeedbackComment, Constants.BORDER_RADIUS);

            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }


        private void SetColorLike()
        {
            var userID = Constants.UserSession.ID;
            var check = likes.Any(l => l == userID);

            lblLikeCount.Text = likes.Count.ToString();

            if (check)
            {
                lblLike.ForeColor = Constants.LIKED_FORECOLOR;
            }
            else
            {
                lblLike.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            }
        }


        public string GetTime(DateTime time)
        {
            var tp = DateTime.Now - time;
            var days = tp.Days;
            var hours = tp.Hours;
            var minutes = tp.Minutes;
            var seconds = tp.Seconds;

            if (days >= 1)
            {
                return days.ToString() + " ngày";
            }
            else if (hours >= 1)
            {
                return hours.ToString() + " giờ";
            }
            else if (minutes >= 1)
            {
                return minutes.ToString() + " phút";
            }
            else
            {
                return seconds.ToString() + " giây";
            }
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlFeedbackComment.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            lblName.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblDescription.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            lblDescription.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;

            lblLike.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblTime.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
        }

        private void UpdateHeight()
        {
            var marB = 7;
            // update des
            pnlMyCommentControl.Top = pnlFeedbackComment.Bottom + marB;
            var height = pnlFeedbackComment.Bottom + pnlMyCommentControl.Height;
            this.Height = height + marB;
        }

        private int GetHeightTextBox(string s)
        {
            var length = s.Length;

            if (length < ch)
            {
                return 38;
            }
            else if (length < 2 * ch)
            {
                return 67;
            }
            else if (length < 3 * ch)
            {
                return 96;
            }
            else if (length < 4 * ch)
            {
                return 135;
            }
            else
            {
                return 163;
            }
        }

        public void UpdateAvatar()
        {
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, commentFeedback.User);
        }

        #endregion

        #region Events



        #endregion

        private void lblLike_Click(object sender, EventArgs e)
        {
            var userID = Constants.UserSession.ID;
            var check = likes.Any(l => l == userID);

            if (check)
            {
                likes.Remove(userID);
            }
            else
            {
                likes.Add(userID);
            }

            SetColorLike();

            // Cập nhật db
            commentFeedback.Like = StringHelper.StringListToString(likes.Select(l => l.ToString()).ToList());
            _commentFeedbackDAO.SaveChanges();
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            OnClickProfileFriend?.Invoke(commentFeedback.User);
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            OnClickProfileFriend?.Invoke(commentFeedback.User);
        }
    }
}
