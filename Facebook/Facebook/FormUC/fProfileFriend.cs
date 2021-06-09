using Facebook.Common;
using Facebook.Components.Profile;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Facebook.FormUC
{
    public partial class fProfileFriend : UserControl
    {
        private User user;

        private readonly IUserDAO _userDAO;

        private Control content;

        public fProfileFriend(IUserDAO userDAO, User user, Control content)
        {
            InitializeComponent();

            this._userDAO = userDAO;
            this.user = user;
            this.content = content;

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

            var infoProfileIntroduceUC = new InfoProfileIntroduceUC(user);
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

            var infoProfileFriendsUC = new InfoProfileFriendsUC(user);
            pnlMainContent.Height = infoProfileFriendsUC.Height;
            infoProfileFriendsUC.Location = new Point(0, 0);

            pnlMainContent.Controls.Add(infoProfileFriendsUC);
            UpdateHeight();
        }

        private void LoadImages()
        {
            pnlMainContent.Controls.Clear();

            var infoProfileImagesUC = new InfoProfileImagesUC(user);
            pnlMainContent.Height = infoProfileImagesUC.Height;
            infoProfileImagesUC.Location = new Point(0, 0);

            pnlMainContent.Controls.Add(infoProfileImagesUC);
            UpdateHeight();
        }

        private void LoadHeader()
        {
            var f = new HeaderProfileUC(this._userDAO, user);
            f.Dock = DockStyle.Fill;

            pnlHead.Height = f.Height;
            pnlHead.Controls.Add(f);
        }

        /// <summary>
        /// Cần update lại thêm menu
        /// </summary>
        private void UpdateHeight()
        {
            pnlMainContent.Height = pnlMainContent.Controls[0].Height;
        }

        private void LoadProfileByUser(User user)
        {
            var fProfileFriend = new fProfileFriend(_userDAO, user, panelContent);

            UIHelper.ShowControl(fProfileFriend, panelContent);
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMainContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMenu.BackColor = Constants.MAIN_BACK_COLOR;
        }

        #endregion Methods

        #region SetUpUI

        private void SetUpUI()
        {
            // Set background color for form
            this.BackColor = Constants.MAIN_BACK_COLOR;

            // Set color for button control window
            btnBack.BackColor = Constants.MAIN_BACK_COLOR;
            btnBack.ForeColor = Constants.MAIN_FORE_COLOR;
            btnBack.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
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

        #endregion SetUpUI

        #region Events

        private void btnBack_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();

            content.SendToBack();
        }

        #endregion Events
    }
}