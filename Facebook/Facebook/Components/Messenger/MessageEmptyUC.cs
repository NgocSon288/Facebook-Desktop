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
    public partial class MessageEmptyUC : UserControl
    {
        public MessageEmptyUC()
        {
            InitializeComponent();

            Load();
        }

        #region Methods

        new private void Load()
        {
            var currentUser = MessengerFriendItemUC.CurrentItem.user;

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, currentUser);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            picAvatar.Left = this.Width / 2 - picAvatar.Width / 2;

            lblName.Text = currentUser?.Name;
            SetUpLabel(lblName);
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            SetUpLabel(lbl1);
            SetUpLabel(lbl2);
            SetUpLabel(lbl3);
            SetUpLabel(lbl4);
        }

        private void SetUpLabel(Label lbl)
        {
            lbl.BackColor = Constants.MAIN_BACK_COLOR;
            lbl.ForeColor = Constants.MAIN_FORE_PARAGRAPH_NOT_ACTIVE_COLOR;
            lbl.Left = this.Width / 2 - lbl.Width / 2;
        }

        #endregion 
    }
}
