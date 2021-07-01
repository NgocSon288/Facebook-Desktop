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

namespace Facebook.Components.Drive.Folders.Share
{
    public partial class UserShareItemUC : UserControl
    {
        public delegate void ClickShareOrUnShare(bool isShare);
        public event ClickShareOrUnShare OnClickShareOrUnShare;

        public User user;
        public bool isShared;

        public UserShareItemUC(User user, bool isShared)
        {
            InitializeComponent();

            this.user = user;
            this.isShared = isShared;

            Load();
        }

        #region Methods

        new private void Load()
        {
            rdbShared.Checked = isShared;
            rdbShared.Visible = isShared;

            pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;

            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = user.Name;
            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_COLOR;

            this.BackColor = Constants.MAIN_BACK_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        #endregion

        private void pnlWrap_MouseEnter(object sender, EventArgs e)
        {
            rdbShared.Visible = true;

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_CONTENT_ENTER_COLOR, user);
            lblName.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void pnlWrap_MouseLeave(object sender, EventArgs e)
        {
            rdbShared.Visible = isShared;

            pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, user);
            lblName.BackColor = Constants.MAIN_BACK_COLOR;
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            isShared = !rdbShared.Checked;
            rdbShared.Checked = isShared;

            this.ActiveControl = lblName;
            OnClickShareOrUnShare?.Invoke(isShared);
        }

        private void rdbStatus_OnChange(object sender, EventArgs e)
        {

        }
    }
}
