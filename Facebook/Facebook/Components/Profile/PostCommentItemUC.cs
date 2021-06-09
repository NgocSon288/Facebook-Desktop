using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class PostCommentItemUC : UserControl
    {
        public delegate void HeightChanged();
        public delegate void ClickProfileFriend(User user);
        public event HeightChanged OnHeightChanged;
        public event ClickProfileFriend OnClickProfileFriend;

        private ICommentFeedbackDAO _commentFeedbackDAO;
        private Comment comment;

        private List<CommentFeedback> commentFeedbacks;
        private List<int> likes;    // danh sách các user like

        private bool isSubmit;

        public PostCommentItemUC(ICommentFeedbackDAO commentFeedbackDAO, Comment comment)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this._commentFeedbackDAO = commentFeedbackDAO;
            this.comment = comment;

            Load();
        }

        int ch = 60;
        string STRING_COMPARE = "Viết bình luận...";

        #region Methods

        new private async Task Load()
        {
            if (comment.Like != null)
            {
                likes = StringHelper.StringToStringList(comment.Like).Select(s => Convert.ToInt32(s)).ToList();
            }
            else
            {
                likes = new List<int>();
            }
            commentFeedbacks = _commentFeedbackDAO.GetByCommentID(comment.ID);
            pnlMyFeedbackComments.Visible = false;

            LoadMyComment();
            await LoadFeedbackComment();

            SetColor();
            UpdateHeight();
            SetColorLike();

            UIHelper.BorderRadius(pnlMyComment, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlBackgroundDescription, Constants.BORDER_RADIUS);

            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }


        private async Task LoadFeedbackComment()
        {
            Task task = new Task(() =>
            {
                if (commentFeedbacks != null && commentFeedbacks.Count > 0)
                {
                    foreach (var item in commentFeedbacks)
                    {
                        // Load PostFeedbackCommentItemUC
                        var cfItem = new PostFeedbackCommentItemUC(AutofacFactory<ICommentFeedbackDAO>.Get(), item);
                        cfItem.Margin = new Padding(0, 0, 0, 0);
                        cfItem.OnClickProfileFriend += (u) => OnClickProfileFriend(u);

                        flpFeedbackComment.Controls.Add(cfItem);

                        UpdateHeight();

                        UIHelper.BorderRadius(pnlBackgroundDescription, Constants.BORDER_RADIUS);
                    }
                }
            });

            task.Start();
        }

        private void LoadMyComment()
        {
            // MyComment
            picOwnCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, comment.User);
            picOwnCommentAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            lblOwnCommentName.Text = comment.User.Name;
            lblOwnCommentDesctiption.Text = comment.Description;
            lblOwnCommentDesctiption.Height = GetHeightTextBox(comment.Description);

            pnlMyComment.Height = lblOwnCommentDesctiption.Top + lblOwnCommentDesctiption.Height + 10;

            // Like count



            picLike.BackgroundImage = ImageHelper.FromFile("./../../Assets/Images/Comment/Facebook-Like.png");
            picLike.BackgroundImageLayout = ImageLayout.Stretch;
            lblLikeCount.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblLikeCount.Text = likes.Count.ToString();
            lblLikeCount.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;


            // Control comment 
            lblOwnMyCommentFeedback.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblMyCommentTime.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblMyCommentTime.Text = GetTime(comment.CreatedAt);

            pnlMyCommentControl.Top = pnlMyComment.Top + pnlMyComment.Height;
        }



        private void SetColorLike()
        {
            var userID = Constants.UserSession.ID;
            var check = likes.Any(l => l == userID);

            lblLikeCount.Text = likes.Count.ToString();

            if (check)
            {
                lblOwnMyCommentLike.ForeColor = Constants.LIKED_FORECOLOR;
            }
            else
            {
                lblOwnMyCommentLike.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
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
            lblOwnCommentName.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            lblOwnCommentName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblOwnCommentDesctiption.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
            lblOwnCommentDesctiption.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            pnlMyComment.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;

            flpFeedbackComment.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            flpFeedbackComment.Top = pnlMyCommentControl.Bottom;

            // MyFeedbackComment 
            picOwnFeedbackCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR);
            picOwnFeedbackCommentAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            pnlBackgroundDescription.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            txtMyFeedbackComment.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            txtMyFeedbackComment.ForeColor = Constants.PLACEHOLDER_FORECOLOR;
        }

        /// <summary>
        /// Tương đối
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int GetHeightTextBox(string s)
        {
            var length = s.Length;

            if (length < ch)
            {
                return 42;
            }
            else if (length < 2 * ch)
            {
                return 77;
            }
            else if (length < 3 * ch)
            {
                return 96;
            }
            else if (length < 4 * ch)
            {
                return 129;
            }
            else
            {
                return 163;
            }
        }

        private void UpdateHeight()
        {
            var marFb = 15;
            var height = pnlMyComment.Top + pnlMyComment.Height;
            var heightMyFeedbackComment = 0;
            height += pnlMyCommentControl.Height;

            var heightFBC = 0;
            foreach (Control item in flpFeedbackComment.Controls)
            {
                heightFBC += item.Height;
            }

            if (pnlMyFeedbackComments.Visible)
            {
                heightMyFeedbackComment = pnlMyFeedbackComments.Height;
            }

            //flpFeedbackComment.Top += marFb;
            flpFeedbackComment.Height = heightFBC;
            this.Height = height + heightFBC + marFb + heightMyFeedbackComment;
            pnlMyFeedbackComments.Top = this.Height - pnlMyFeedbackComments.Height;

        }

        public void UpdateAvatar()
        {
            picOwnCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, comment.User);
            picOwnFeedbackCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR);

            foreach (PostFeedbackCommentItemUC item in flpFeedbackComment.Controls)
            {
                item.UpdateAvatar();
            }
        }

        #endregion

        #region Events

        private void lblOwnMyCommentFeedback_Click(object sender, EventArgs e)
        {

            //if (!pnlMyFeedbackComments.Visible)
            {

                pnlMyFeedbackComments.Visible = !pnlMyFeedbackComments.Visible;

                UpdateHeight();
                OnHeightChanged?.Invoke();
            }
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

        private void lblOwnMyCommentLike_Click(object sender, EventArgs e)
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
            comment.Like = StringHelper.StringListToString(likes.Select(l => l.ToString()).ToList());
            _commentFeedbackDAO.SaveChanges();
        }

        private void txtMyCommentDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                isSubmit = true;
                txtMyCommentDescription_TextChanged(null, null);
                this.ActiveControl = lblLikeCount;
            }
        }

        private void txtMyCommentDescription_TextChanged(object sender, EventArgs e)
        {
            if (isSubmit)
            {
                isSubmit = false;
                var text = txtMyFeedbackComment.Text;
                txtMyFeedbackComment.Text = "";
                if (string.IsNullOrEmpty(text.Trim()))
                {
                    return;
                }

                var cmt = new CommentFeedback()
                {
                    Description = text,
                    CreatedAt = DateTime.Now,
                    Like = null,
                    CommentID = comment.ID,
                    User = Constants.UserSession
                };
                // add vào comments của ui
                commentFeedbacks.Add(cmt);

                // add vào List ui 
                // Load PostFeedbackCommentItemUC
                var cfItem = new PostFeedbackCommentItemUC(AutofacFactory<ICommentFeedbackDAO>.Get(), cmt);
                cfItem.Margin = new Padding(0, 0, 0, 0);

                flpFeedbackComment.Controls.Add(cfItem);

                // Save db
                _commentFeedbackDAO.Create(cmt);

                UpdateHeight();
                OnHeightChanged?.Invoke();
            }
        }



        #endregion

        private void picOwnCommentAvatar_Click(object sender, EventArgs e)
        {
            OnClickProfileFriend?.Invoke(comment.User);
        }

        private void lblOwnCommentName_Click(object sender, EventArgs e)
        {
            OnClickProfileFriend?.Invoke(comment.User);
        }

        private void picOwnFeedbackCommentAvatar_Click(object sender, EventArgs e)
        {
            OnClickProfileFriend?.Invoke(comment.User);
        }
    }
}
