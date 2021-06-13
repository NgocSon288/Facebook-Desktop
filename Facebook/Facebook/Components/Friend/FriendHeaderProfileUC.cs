using Facebook.Common;
using Facebook.ControlCustom.Image;
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
    public partial class FriendHeaderProfileUC : UserControl
    {
        private User user;

        public FriendHeaderProfileUC(User user)
        {
            InitializeComponent();

            this.user = user;

            Load();
            SetUpUI();
            SetColor();
        }

        int margin = 20;

        #region Methods

        new private void Load()
        {
            pnlWrap.Location = new Point(margin, margin);
            pnlWrap.Width = this.Width - 2 * margin;
            pnlWrap.Height = this.Height - 2 * margin;


            pnlWrapImage.BackColor = Constants.BORDER_IMAGE_COLOR;
            pnlWrapImage.Left = pnlWrap.Width / 2 - pnlWrapImage.Width / 2;

            // Image
            picAvatar.Left = pnlWrap.Width / 2 - picAvatar.Width / 2;
            picImage.BackgroundImage = ImageHelper.GetImageByUser(user);
            picImage.BackgroundImageLayout = ImageLayout.Stretch;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            // Name 
            lblName.Text = user?.Name;
            lblName.Left = pnlWrap.Width / 2 - lblName.Width / 2;
            lblName.Top = pnlWrap.Height - pnlBottom.Height - lblName.Height - margin;

            // Border bottom
            pnlBottom.Width = 300;
            pnlBottom.Height = 5;
            pnlBottom.BackColor = Color.Gray;
            pnlBottom.Left = pnlWrap.Width / 2 - pnlBottom.Width / 2;
            pnlBottom.Top = pnlWrap.Height - pnlBottom.Height - margin;

            UIHelper.BorderRadius(picImage, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlWrapImage, Constants.BORDER_RADIUS);
        }

        private void SetUpUI()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            pnlBottom.BackColor = Constants.MAIN_FORE_COLOR;
        }

        #endregion

        #region Events



        #endregion

        private void picImage_Click(object sender, EventArgs e)
        {
            if (user.Image != null)
                MyImage.Show($"./../../Assets/Images/Profile/{user.Image}");
            else
            {
                MyImage.Show("./../../Assets/Images/Profile/image-default.jpg");
            }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            if (user.Avatar != null)
                MyImage.Show($"./../../Assets/Images/Profile/{user.Avatar}");
            else
            {
                MyImage.Show("./../../Assets/Images/Profile/avatar-default.jpg");
            }
        }
    }
}
