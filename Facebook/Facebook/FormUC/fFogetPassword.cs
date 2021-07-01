using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
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
    public partial class fFogetPassword : UserControl
    {
        public delegate void VerifyOTPEmail();
        public event VerifyOTPEmail OnVerifyOTPEmail;

        private readonly IUserDAO _userDAO;

        public fFogetPassword(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

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
            // test
            txtUsername.Text = "son";
            txtNewPassword.Text = "123";
            txtConfirmPassword.Text = "123";
            txtEmail.Text = "18521694@gm.uit.edu.vn";

            // Setup hình ảnh social
            picFacebook.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-facebook.png");
            picTwitter.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-twitter.png");
            picGoogle.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-google.png");

            SetColor();
        }

        private async void SendOTPToEmail()
        {
            // tạo OTP
            Constants.OTP = GetOTP();

            // Gửi OTP qua email 
            await SendMail();
        }

        private async Task SendMail()
        {
            var content = File.ReadAllText("./../../Assets/Template/VerifyOTP.html");

            var us = _userDAO.GetByUsername(Constants.Username);

            content = content.Replace("{{Name}}", us.Name);
            content = content.Replace("{{OTP}}", Constants.OTP);

            await MailHelper.SendMail(us.Email, "Xác nhận mật khẩu từ FACEBOOK", content);
        }

        public void RestSetForm()
        {
            txtUsername.Text = USERNAME_COMPARE;
            txtNewPassword.Text = NEW_PASSWORD_COMPARE;
            txtConfirmPassword.Text = CONFIRM_PASSWORD_COMPARE;
            txtEmail.Text = EMAIL_COMPARE;

            txtNewPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.UseSystemPasswordChar = false;

            lblUsername.Visible = false;
            lblNewPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            lblEmail.Visible = false;
        }

        private string ConvertStringUI(string input)
        {
            if (input == USERNAME_COMPARE || input == NEW_PASSWORD_COMPARE || input == CONFIRM_PASSWORD_COMPARE || input == EMAIL_COMPARE)
            {
                return "";
            }

            return input;
        }

        private void SetColor()
        {
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;

            txtUsername.BackColor = Constants.MAIN_BACK_COLOR;
            txtNewPassword.BackColor = Constants.MAIN_BACK_COLOR;
            txtConfirmPassword.BackColor = Constants.MAIN_BACK_COLOR;
            txtEmail.BackColor = Constants.MAIN_BACK_COLOR;

            picFacebook.BackColor = Constants.MAIN_BACK_COLOR;
            picTwitter.BackColor = Constants.MAIN_BACK_COLOR;
            picGoogle.BackColor = Constants.MAIN_BACK_COLOR;
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
            Constants.AccountForm.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Events

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
            var username = ConvertStringUI(txtUsername.Text);
            var newPassword = ConvertStringUI(txtNewPassword.Text);
            var confirmPassword = ConvertStringUI(txtConfirmPassword.Text);
            var email = ConvertStringUI(txtEmail.Text);

            if (string.IsNullOrEmpty(username.Trim()) || string.IsNullOrEmpty(newPassword.Trim()) || string.IsNullOrEmpty(confirmPassword.Trim()) || string.IsNullOrEmpty(email))
            {
                MyMessageBox.Show("Thông tin tài khoản mật khẩu không hợp lệ", MessageBoxType.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MyMessageBox.Show("Xác nhận mật khẩu không hợp lệ", MessageBoxType.Error);
                return;
            }

            var check = _userDAO.CheckForgetPassword(username, email);

            if (check == -1)
            {
                MyMessageBox.Show("Tài khoản không hợp lệ", MessageBoxType.Error);
                return;
            }
            else if (check == -3)
            {
                MyMessageBox.Show($"Tài khoản {username} đã bị khóa", MessageBoxType.Error);
                return;
            }
            else if (check == -2)
            {
                MyMessageBox.Show("Email không hợp lệ", MessageBoxType.Error);
                return;
            }
            else if (check == 0)
            {
                MyMessageBox.Show("Lỗi trong quá trình đổi mật khẩu", MessageBoxType.Error);
                return;
            }

            Constants.Email = email;
            Constants.Username = username;
            Constants.NewPassword = newPassword;
            Constants.OTP = GetOTP();
            Constants.CountIncorrect = 0;

            SendOTPToEmail();

            // Chuyển qua trang nhập OTP
            Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.VERIFY_PASSWORD);

            MyMessageBox.Show($"Chúng tôi đã gửi mã OTP qua email {email}, vui lòng kiểm tra lại!", MessageBoxType.Infomation);

            RestSetForm();
        }

        private string GetOTP(int len = 8)
        {
            var rand = new Random();
            var s = "";
            var i = 0;
            var c = 0;
            while (i < len)
            {
                c = rand.Next(0, 3);

                if (c == 0)
                {
                    s += rand.Next(0, 10).ToString();
                }
                else if (c == 1)
                {
                    s += (char)rand.Next(65, 91);
                }
                else
                {
                    s += (char)rand.Next(97, 123);
                }

                i++;
            }

            return s;
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
                btnSubmit_Click(null, new EventArgs());
            }
        }

        #endregion 
    }
}
