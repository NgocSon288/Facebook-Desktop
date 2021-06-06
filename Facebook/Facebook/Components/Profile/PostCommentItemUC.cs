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
    public partial class PostCommentItemUC : UserControl
    {
        public delegate void HeightChanged();
        public event HeightChanged OnHeightChanged;

        private ICommentFeedbackDAO _commentFeedbackDAO;
        private Comment comment;

        private List<CommentFeedback> commentFeedbacks;

        public PostCommentItemUC(ICommentFeedbackDAO commentFeedbackDAO, Comment comment)
        {
            InitializeComponent();

            this._commentFeedbackDAO = commentFeedbackDAO;
            this.comment = comment;

            Load();
        }

        int ch = 60;
        string STRING_COMPARE = "Viết bình luận...";

        #region Methods

        new private void Load()
        {
            commentFeedbacks = _commentFeedbackDAO.GetByCommentID(comment.ID);
            pnlMyFeedbackComments.Visible = false;

            LoadMyComment();
            LoadFeedbackComment();

            SetColor();
            UpdateHeight();
        }

        private void LoadFeedbackComment()
        {
            if (commentFeedbacks != null && commentFeedbacks.Count > 0)
            {
                foreach (var item in commentFeedbacks)
                {
                    // Load PostFeedbackCommentItemUC
                    var cfItem = new PostFeedbackCommentItemUC(item);
                    cfItem.Margin = new Padding(0, 0, 0, 0);

                    flpFeedbackComment.Controls.Add(cfItem);
                }
            }
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


            // Control comment
            lblOwnMyCommentLike.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblOwnMyCommentFeedback.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblMyCommentTime.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            pnlMyCommentControl.Top = pnlMyComment.Top + pnlMyComment.Height;
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


        #endregion

        #region Events



        #endregion

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

    }
}
