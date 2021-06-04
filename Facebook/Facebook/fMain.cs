using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
using Facebook.FormUC;
using Facebook.Helper;
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

namespace Facebook
{
    public partial class fMain : Form
    {

        private IconButton currentBtn;
        private Panel leftBorderBtn;

        private fHome fHome;

        public fMain()
        {
            InitializeComponent();

            Load();
        }

        #region Methods

        new private void Load()
        {
            Constants.MainForm = this;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 100);
            panelMenu.Controls.Add(leftBorderBtn);

            Reset();
            ShowAccountForm();
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();

                //Button transition
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = Constants.BORDER_MENU_LEFT_COLOR;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Constants.BORDER_MENU_LEFT_COLOR;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = Constants.BORDER_MENU_LEFT_COLOR;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            fHome = new fHome();
            UIHelper.ShowControl(fHome, panelContent);
        }

        private void ShowAccountForm()
        {
            fAccountForm fAccountForm = new fAccountForm();
            this.Visible = false;
            fAccountForm.fLogin.OnLoginSuccess += FLogin_OnLoginSuccess;
            fAccountForm.ShowDialog();
        }

        #endregion


        #region Events

        /// <summary>
        /// Hành động khi đăng nhập thành công
        /// </summary>
        private void FLogin_OnLoginSuccess()
        {
            fHome.Load();
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            var f = new fProfile(AutofacFactory<IUserDAO>.Get());
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            var f = new fFriend();
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnMessenger_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            var f = new fMessenger();
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            var f = new fAccount();
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session
            Constants.UserSession = null;

            ShowAccountForm();
        }

        #endregion
    }
}
