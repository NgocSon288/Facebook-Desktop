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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Facebook.Components.Profile.PostListProfileUC;

namespace Facebook.FormUC
{
    public partial class fHome : UserControl
    {

        private PostListProfileUC postListProfileUC;

        public fHome()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            SetUpUI();
            Load();
        }


        #region Methods

        new public void Load()
        {
            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
            postListProfileUC = new PostListProfileUC(AutofacFactory<IPostDAO>.Get(), Constants.UserSession, PAGE.HOME);
            postListProfileUC.OnHeightChanged += () => UpdateHeight();
            postListProfileUC.OnClickProfileFriend += LoadProfileByUser;

            pnlPostList.Controls.Add(postListProfileUC);
            postListProfileUC.Dock = DockStyle.Top;

            UpdateHeight();

        }

        /// <summary>
        /// Show profile friend
        /// </summary>
        /// <param name="user"></param>
        private void LoadProfileByUser(User user)
        {
            var fProfileFriend = new fProfileFriend(AutofacFactory<IUserDAO>.Get(), user, panelContent, PAGE.PROFILE);

            UIHelper.ShowControl(fProfileFriend, panelContent);
        }

        private void UpdateHeight()
        {
            pnlPostList.Height = postListProfileUC.Height;
            pnlMainContent.Height = postListProfileUC.Height;

            UIHelper.BorderRadius(postListProfileUC, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlPostList, Constants.BORDER_RADIUS);
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

        private void pnlMainContent_Click(object sender, EventArgs e)
        { 
        }
    }
}
