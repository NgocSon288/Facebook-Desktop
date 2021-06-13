using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.Helper;
using Facebook.Model.Models;
using FontAwesome.Sharp;
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
    public partial class InfoProfileFriendItemUC : UserControl
    {
        public delegate void LinkToProfile();
        public delegate void BlockUser();
        public delegate void DeleteFriend();
        public event LinkToProfile OnLinkToProfile;
        public event BlockUser OnBlockUser;
        public event DeleteFriend OnDeleteFriend;

        private User user;
        private bool isProfile;

        public InfoProfileFriendItemUC(User user, bool isProfile)
        {
            InitializeComponent();

            this.user = user;
            this.isProfile = isProfile;

            Load();
        }

        #region Methods

        new private void Load()
        {
            btnBlock.Visible = isProfile;
            btnDelete.Visible = isProfile;

            if (!string.IsNullOrEmpty(user.Avatar))
            {
                picAvatar.BackgroundImage = Image.FromFile($"./../../Assets/Images/Profile/{user.Avatar}");
            }
            else
            {
                picAvatar.BackgroundImage = Image.FromFile($"./../../Assets/Images/Profile/avatar-default.jpg");
            }
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = user.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            lblFriendCommon.Text = "25 bạn chung";
            lblFriendCommon.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblFriendCommon.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnDelete.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnDelete.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnDelete.FlatAppearance.MouseDownBackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            btnDelete.FlatAppearance.MouseOverBackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;

            btnBlock.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnBlock.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnBlock.FlatAppearance.MouseDownBackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            btnBlock.FlatAppearance.MouseOverBackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;

            tt.SetToolTip(btnBlock, $"Chặn {user.Name}");
            tt.SetToolTip(btnDelete, $"Hủy kết bạn với {user.Name}");

            UIHelper.BorderRadius(picAvatar, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }


        #endregion

        /// <summary>
        /// Thông báo cho cha để chuyển sang profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picAvatar_Click(object sender, EventArgs e)
        {
            OnLinkToProfile?.Invoke();
        }

        private void btnBlock_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnBlock_MouseLeave(object sender, EventArgs e)
        {
        }

        private void picAvatar_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            lblFriendCommon.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            btnBlock.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            btnDelete.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            btnBlock.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnDelete.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            var btn = sender as IconButton;

            if (btn != null)
            {
                btn.IconColor = Constants.ERROR_COLOR;
            }
        }

        private void InfoProfileFriendItemUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblFriendCommon.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnBlock.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnDelete.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnBlock.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            btnDelete.IconColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.Show($"Nếu chặn {user.Name} thì các bạn sẽ không tìm thấy nhau trên Facebook", MessageBoxType.Warning).Value == DialogResult.OK)
            {
                OnBlockUser?.Invoke();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.Show($"Bạn có muốn hủy kết bạn với {user.Name}?", MessageBoxType.Question).Value == DialogResult.OK)
            {
                OnDeleteFriend?.Invoke();
            }
        }
    }
}
