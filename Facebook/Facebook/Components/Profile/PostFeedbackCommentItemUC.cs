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

        private CommentFeedback CommentFeedback;

        public PostFeedbackCommentItemUC(CommentFeedback CommentFeedback)
        {
            InitializeComponent();

            this.CommentFeedback = CommentFeedback;

            Load();
        }

        int ch = 50;

        #region Medthods

        new private void Load()
        {
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, CommentFeedback.User);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = CommentFeedback.User.Name;
            lblDescription.Text = CommentFeedback.Description;
            lblDescription.Height = GetHeightTextBox(lblDescription.Text);
            pnlFeedbackComment.Height = lblDescription.Bottom + 10;

            SetColor();
            UpdateHeight();
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

        #endregion

        #region Events



        #endregion
    }
}
