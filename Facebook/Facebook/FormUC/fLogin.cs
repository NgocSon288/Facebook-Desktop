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
        }

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
    }
}
