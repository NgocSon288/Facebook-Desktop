using Facebook.Common;
using Facebook.Components.Profile;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.FormUC
{
    public partial class fProfile : UserControl
    {
        public delegate void UpdatedAvatar();
        public event UpdatedAvatar OnUpdatedAvatar;

        private readonly IUserDAO _userDAO;

        private InfoProfileUC infoProfileUC;
        private PostListProfileUC postListProfileUC;

        public fProfile(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

            SetUpUI();
            Load();
        }

        #region Methods

        new private void Load()
        {
            // Load Header: Image, Avatar
            LoadHeader();

            // Load menu
            LoadMenu();

            // Tương tự load left right
            LoadIntroduce();

            SetColor();
        }

        private void LoadMenu()
        {
            // Sẽ  thay thế
            var menuProfileUC = new MenuProfileUC();
            menuProfileUC.OnClickButtonIntro += () => { LoadIntroduce(); };
            menuProfileUC.OnClickButtonFriends += () => { LoadFriends(); };
            menuProfileUC.OnClickButtonImages += () => { LoadImages(); };

            pnlMenu.Controls.Add(menuProfileUC);
            pnlMenu.Height = menuProfileUC.Height + 19;
        }

        private void LoadIntroduce()
        {
            pnlMainContent.Controls.Clear();

            var infoProfileIntroduceUC = new InfoProfileIntroduceUC(Constants.UserSession);
            pnlMainContent.Height = infoProfileIntroduceUC.Height;
            infoProfileIntroduceUC.Location = new Point(0, 0);
            infoProfileIntroduceUC.OnHeightChanged += UpdateHeight;
            infoProfileIntroduceUC.OnClickProfileFriend += LoadProfileByUser;

            pnlMainContent.Controls.Add(infoProfileIntroduceUC);
            UpdateHeight();
        }

        private void LoadFriends()
        {
            pnlMainContent.Controls.Clear();

            var infoProfileFriendsUC = new InfoProfileFriendsUC(AutofacFactory<IUserDAO>.Get(), Constants.UserSession, true);
            infoProfileFriendsUC.Location = new Point(0, 0);
            infoProfileFriendsUC.OnLinkToProfile += LoadProfileByUser;
            infoProfileFriendsUC.OnBlockUser += LoadFriends;
            infoProfileFriendsUC.OnDeleteFriend += LoadFriends;

            pnlMainContent.Height = infoProfileFriendsUC.Height;
            pnlMainContent.Controls.Add(infoProfileFriendsUC);
            UpdateHeight();
        }

        private void LoadImages()
        {
            pnlMainContent.Controls.Clear();

            var infoProfileImagesUC = new InfoProfileImagesUC(AutofacFactory<IPostDAO>.Get(), Constants.UserSession);
            infoProfileImagesUC.Location = new Point(0, 0);
            infoProfileImagesUC.OnHeightChanged += UpdateHeight;

            pnlMainContent.Height = infoProfileImagesUC.Height;
            pnlMainContent.Controls.Add(infoProfileImagesUC);
            UpdateHeight();
        }

        private void LoadHeader()
        {
            var f = new HeaderProfileUC(this._userDAO, Constants.UserSession);
            f.Dock = DockStyle.Fill;

            pnlHead.Height = f.Height;
            pnlHead.Controls.Add(f);
        }

        /// <summary>
        /// Goi các child update avatar
        /// </summary>
        private void F_OnUpdatedAvatar()
        {
            postListProfileUC.UpdateAvatar();
        }

        private void UpdateHeight()
        {
            try
            {
                pnlMainContent.Height = pnlMainContent.Controls[0].Height;
            }
            catch (Exception)
            {

            }
        }

        private void LoadProfileByUser(User user)
        {
            var fProfileFriend = new fProfileFriend(_userDAO, user, panelContent, PostListProfileUC.PAGE.PROFILE);

            UIHelper.ShowControl(fProfileFriend, panelContent);
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMainContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMenu.BackColor = Constants.MAIN_BACK_COLOR;
        }

        #endregion

        #region SetUpUI

        private void SetUpUI()
        {
            // Set background color for form
            this.BackColor = Constants.MAIN_BACK_COLOR;

            // Set color for button control window
            btnMinimize.BackColor = Constants.MAIN_BACK_COLOR;
            btnMinimize.ForeColor = Constants.MAIN_FORE_COLOR;
            btnMinimize.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
            btnClose.BackColor = Constants.MAIN_BACK_COLOR;
            btnClose.ForeColor = Constants.MAIN_FORE_COLOR;
            btnClose.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            if (MyMessageBox.Show("Bạn có muốn thoát?", MessageBoxType.Question).Value == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            Constants.MainForm.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Events


        #endregion
    }
}
