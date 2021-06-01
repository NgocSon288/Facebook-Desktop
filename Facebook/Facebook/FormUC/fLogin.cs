using Facebook.Common;
using Facebook.DAO;
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

namespace Facebook.FormUC
{
    public partial class fLogin : UserControl
    {
        private readonly IUserDAO _userDAO;

        public fLogin(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

            SetUpUI();
            Load();
        }

        private string USERNAME_COMPARE = "Tài khoản";
        private string PASSWORD_COMPARE = "Mật khẩu";

        #region Methods

        new private void Load()
        {
            // Setup hình ảnh social
            picFacebook.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-facebook.png");
            picTwitter.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-twitter.png");
            picGoogle.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-google.png");
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
            if (MessageBox.Show("Bạn có muốn thoát?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            Constants.AccountForm.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Events

        /// <summary>
        /// Đã có tài khoản, thực hiện truy xuất DB để đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var isLogin = true;
            // truy xuất db

            // Giả sử đã xử lý truy xuất db và thành công
            if (isLogin)
            {
                // chuyển vào trang fmain 
                Constants.AccountForm.Close();
                Constants.MainForm.Visible = true;
            }
        }

        /// <summary>
        /// Chưa có tài khoản, chuyền sang form đăng ký để tạo tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.REGISTER);
        }

        /// <summary>
        /// Quân mật khẩu, nhấn vào chuyển sang trang forget password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.FORGET_PASSWORD);
        }

        #endregion

        #region UI

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            var txt = txtUsername.Text;
            lblUsername.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, USERNAME_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtUsername.Text = "";

                // Cho label hiện lên
                lblUsername.Visible = true;
            }

            // Color
            txtUsername.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlBottomUsername.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            var txt = txtUsername.Text;
            lblUsername.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtUsername.Text = USERNAME_COMPARE;

                // Cho label ẩn đi
                lblUsername.Visible = false;
            }

            // Color
            txtUsername.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlBottomUsername.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            var txt = txtPassword.Text;
            lblPassword.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, PASSWORD_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtPassword.Text = "";

                // Cho label hiện lên
                lblPassword.Visible = true;
            }

            // Color
            txtPassword.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlBottomPassword.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            var txt = txtPassword.Text;
            lblPassword.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtPassword.Text = PASSWORD_COMPARE;
                txtPassword.UseSystemPasswordChar = false;

                // Cho label ẩn đi
                lblPassword.Visible = false;
            }

            // Color
            txtPassword.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlBottomPassword.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        #endregion 
    }
}
