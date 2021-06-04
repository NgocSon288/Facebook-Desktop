using Facebook.Common;
using Facebook.Components.Profile;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
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

        new public void Load()
        {
            // Load Header: Image, Avatar
            LoadHeader();

            /// Height của pnlMainContent = Max(heightLeft, heightRight);
            // Load thông tin bên trái
            LoadLeft();

            // Load các bài viết bên phải
            LoadRight();

            SetColor();
        }

        private void LoadHeader()
        {
            var f = new HeaderProfileUC(this._userDAO);
            pnlHead.Height = f.Height + 100;

            pnlHead.Controls.Add(f);
            f.Dock = DockStyle.Fill;
        }

        private void LoadLeft()
        {
            infoProfileUC = new InfoProfileUC(AutofacFactory<IProfileDAO>.Get());   // InfoUC có width bao nhiêu cũng được
            pnlMainContent.Height = infoProfileUC.Height;   // gán giá height của InfoUC cho pnl chứa nó, vì flp có thể scroll theo độ dày các con bên trong
            infoProfileUC.OnHeightChanged += () => UpdateHeight();

            pnlLeft.Controls.Add(infoProfileUC);
            infoProfileUC.Dock = DockStyle.Top;

        }

        private void LoadRight()
        {
            postListProfileUC = new PostListProfileUC();
            UpdateHeight();
            postListProfileUC.OnHeightChanged += () => UpdateHeight();

            pnlRight.Controls.Add(postListProfileUC);
            postListProfileUC.Dock = DockStyle.Top;
        }

        private void UpdateHeight()
        {
            pnlMainContent.Height = infoProfileUC.Height > postListProfileUC.Height ? infoProfileUC.Height : postListProfileUC.Height;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_COLOR;
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
