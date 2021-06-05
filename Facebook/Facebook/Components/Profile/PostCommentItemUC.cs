using Facebook.Common;
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

        private Comment comment;

        public PostCommentItemUC(Comment comment)
        {
            InitializeComponent();

            this.comment = comment;

            Load();
        }

        #region Methods

        new private void Load()
        {
            picOwnCommentAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, comment.User);
            picOwnCommentAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            lblOwnCommentName.Text = comment.User.Name;

            SetColor();
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblOwnCommentName.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblOwnCommentName.ForeColor = Constants.MAIN_FORE_COLOR;
        }




        #endregion



        #region Events



        #endregion
    }
}
