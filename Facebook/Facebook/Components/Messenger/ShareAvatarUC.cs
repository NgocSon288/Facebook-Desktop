using Facebook.Common;
using Facebook.Helper;
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
    public partial class ShareAvatarUC : UserControl
    {
        public ShareAvatarUC()
        {
            InitializeComponent();

            Load();
        }

        #region Methods

        new private void Load()
        {
            var user = MessengerFriendItemUC.CurrentItem.user;

            this.BackColor = Constants.MAIN_BACK_COLOR;

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            picAvatar.Left = this.Width / 2 - picAvatar.Width / 2;

            lblName.Text = user.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblName.Left = this.Width / 2 - lblName.Width / 2;

        }

        #endregion
    }
}
