using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
using Facebook.FormUC;
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

namespace Facebook
{
    public partial class fMain : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        private fHome fHome;
        private fProfile fProfile;
        private fFriend fFriend;
        private fMessenger fMessenger;

        private BUTTON CURRENT_BUTTON;

        private enum BUTTON
        {
            HOME,
            PROFILE,
            FRIEND,
            MESSENGER,
            ACCOUNT
        }

        public fMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);


            Load();
        }

        #region Methods

        new private void Load()
        {
            panelContent.BackColor = Constants.MAIN_BACK_COLOR;

            btnProfile.ForeColor = Constants.MAIN_FORE_COLOR;
            btnFriends.ForeColor = Constants.MAIN_FORE_COLOR;
            btnMessenger.ForeColor = Constants.MAIN_FORE_COLOR;
            btnDrive.ForeColor = Constants.MAIN_FORE_COLOR;

            Constants.MainForm = this;
            CURRENT_BUTTON = BUTTON.HOME;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 100);
            panelMenu.Controls.Add(leftBorderBtn);

            Reset();
            ShowAccountForm();

            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
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

        private void DisposeForm()
        {
            try { fHome?.Dispose(); } catch (Exception) { }
            try { fProfile?.Dispose(); } catch (Exception) { }
            try { fFriend?.Dispose(); } catch (Exception) { }
            try { fMessenger?.Dispose(); } catch (Exception) { }
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
            if (CURRENT_BUTTON == BUTTON.HOME)
            {
                return;
            }
            CURRENT_BUTTON = BUTTON.HOME;

            DisposeForm();

            Reset();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (CURRENT_BUTTON == BUTTON.PROFILE)
            {
                return;
            }
            CURRENT_BUTTON = BUTTON.PROFILE;

            DisposeForm();

            ActivateButton(sender);

            fProfile = new fProfile(AutofacFactory<IUserDAO>.Get());
            UIHelper.ShowControl(fProfile, panelContent);
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            if (CURRENT_BUTTON == BUTTON.FRIEND)
            {
                return;
            }
            CURRENT_BUTTON = BUTTON.FRIEND;

            DisposeForm();

            ActivateButton(sender);

            var f = new fFriend(AutofacFactory<IUserDAO>.Get());
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnMessenger_Click(object sender, EventArgs e)
        {
            if (CURRENT_BUTTON == BUTTON.MESSENGER)
            {
                return;
            }
            CURRENT_BUTTON = BUTTON.MESSENGER;

            DisposeForm();

            ActivateButton(sender);

            var f = new fMessenger(AutofacFactory<IMessageDAO>.Get(), AutofacFactory<IMessageQueueDAO>.Get(), AutofacFactory<IMessageSettingDAO>.Get());
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (CURRENT_BUTTON == BUTTON.ACCOUNT)
            {
                return;
            }
            CURRENT_BUTTON = BUTTON.ACCOUNT;

            ActivateButton(sender);

            var f = new fDrive(AutofacFactory<IFolderDAO>.Get());
            UIHelper.ShowControl(f, panelContent);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CURRENT_BUTTON = BUTTON.HOME;

            // Clear session
            Constants.UserSession = null;

            ShowAccountForm();
        }

        #endregion
    }
}
