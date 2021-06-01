using Facebook.Common;
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
    public partial class fFogetPassword : UserControl
    {
        public fFogetPassword()
        {
            InitializeComponent();

            SetUpUI();
            Load();
        }

        private string USERNAME_COMPARE = "Tài khoản";
        private string NEW_PASSWORD_COMPARE = "Mật khẩu mới";
        private string CONFIRM_PASSWORD_COMPARE = "Nhập lại mật khẩu";
        private string EMAIL_COMPARE = "Email";

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

        #region Evetns

        /// <summary>
        /// Chuyển sang trang đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.LOGIN);
        }

        /// <summary>
        /// Chuyển sang trang đăng ký
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.REGISTER);
        }

        /// <summary>
        /// Thực hiện đổi mật khẩu và chuyển sang trang fmain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đổi mật khẩu thành công");

            // chuyển vào trang fmain 
            Constants.AccountForm.Close();
            Constants.MainForm.Visible = true;
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
            pnlUsername.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
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
            pnlUsername.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            var txt = txtNewPassword.Text;
            lblNewPassword.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, NEW_PASSWORD_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtNewPassword.Text = "";

                // Cho label hiện lên
                lblNewPassword.Visible = true;
            }

            // Color
            txtNewPassword.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlNewPassword.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            txtNewPassword.UseSystemPasswordChar = true;
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            var txt = txtNewPassword.Text;
            lblNewPassword.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtNewPassword.Text = NEW_PASSWORD_COMPARE;
                txtNewPassword.UseSystemPasswordChar = false;

                // Cho label ẩn đi
                lblNewPassword.Visible = false;
            }

            // Color
            txtNewPassword.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlNewPassword.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            var txt = txtConfirmPassword.Text;
            lblConfirmPassword.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, CONFIRM_PASSWORD_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtConfirmPassword.Text = "";

                // Cho label hiện lên
                lblConfirmPassword.Visible = true;
            }

            // Color
            txtConfirmPassword.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlConfirmPassword.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            var txt = txtConfirmPassword.Text;
            lblConfirmPassword.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtConfirmPassword.Text = CONFIRM_PASSWORD_COMPARE;
                txtConfirmPassword.UseSystemPasswordChar = false;

                // Cho label ẩn đi
                lblConfirmPassword.Visible = false;
            }

            // Color
            txtConfirmPassword.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlConfirmPassword.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            var txt = txtEmail.Text;
            lblEmail.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, EMAIL_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtEmail.Text = "";

                // Cho label hiện lên
                lblEmail.Visible = true;
            }

            // Color
            txtEmail.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlEmail.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            var txt = txtEmail.Text;
            lblEmail.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtEmail.Text = EMAIL_COMPARE;

                // Cho label ẩn đi
                lblEmail.Visible = false;
            }

            // Color
            txtEmail.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlEmail.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        #endregion
    }
}
