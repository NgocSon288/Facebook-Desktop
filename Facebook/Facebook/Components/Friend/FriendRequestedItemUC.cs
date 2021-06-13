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

namespace Facebook.Components.Friend
{
    public partial class FriendRequestedItemUC : UserControl
    {
        public delegate void ClickSection();
        public delegate void ClickDelete();
        public delegate void ClickAccept();
        public event ClickSection OnClickSection;
        public event ClickDelete OnClickDelete;
        public event ClickAccept OnClickAccept;

        public User user;

        public FriendRequestedItemUC(User user)
        {
            InitializeComponent();

            this.user = user;

            Load();
            SetUpUI();
        }

        #region Methods

        new private void Load()
        {
        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = user.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            btnAccept.BackColor = Constants.MAIN_FORE_LINK2_COLOR;
            btnAccept.ForeColor = Constants.MAIN_FORE_COLOR;

            btnDelete.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            btnDelete.ForeColor = Constants.MAIN_FORE_COLOR;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(btnAccept, 10);
            UIHelper.BorderRadius(btnDelete, 10);
        }

        #endregion

        #region Events

        private void FriendRequestedItemUC_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_ENTER_COLOR, user);
        }

        private void FriendRequestedItemUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, user);
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            OnClickSection?.Invoke();
        }


        #endregion

        /// <summary>
        /// Thông bào cho cha là xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnClickDelete?.Invoke();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            OnClickAccept?.Invoke();
        }
    }
}
