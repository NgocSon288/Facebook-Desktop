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

namespace Facebook.Components.Messenger
{
    public partial class MessengerHeaderMessageUC : UserControl
    {
        private User user;

        public MessengerHeaderMessageUC(User user)
        {
            InitializeComponent();

            this.user = user;

            Load();
            SetColor();
        }

        #region Methods

        new public void Load(User userT = null)
        {
            if (userT != null)
            {
                this.user = userT;
            }

            this.BackColor = Constants.MAIN_BACK_COLOR;

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = user.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void SetColor()
        {
            picPhone.IconColor = Constants.THEME_COLOR;
            picVideo.IconColor = Constants.THEME_COLOR;

            tt.SetToolTip(picPhone, "Bắt đầu gọi thoại");
            tt.SetToolTip(picVideo, "Bắt đầu gọi video");
        }

        public void SetThemeColor()
        {
            picPhone.IconColor = Constants.THEME_COLOR;
            picVideo.IconColor = Constants.THEME_COLOR;
        }

        #endregion
    }
}
