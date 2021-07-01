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
    public partial class fVerifyPassword : UserControl
    {
        private readonly IUserDAO _userDAO;

        public fVerifyPassword(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

            SetUpUI();
            Load();
        }

        private string EMAIL_COMPARE = "OTP";

        #region Methods

        new private void Load()
        {
            // Setup hình ảnh social
            picFacebook.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-facebook.png");
            picTwitter.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-twitter.png");
            picGoogle.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-google.png");

            SetColor();

            label2.Text = $"Vui lòng kiểm tra lại email {Constants.Email}";
            label2.Left = panel1.Width / 2 - label2.Width / 2;
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            label1.BackColor = label2.BackColor = label3.BackColor = Constants.MAIN_BACK_COLOR;
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

        public void RestSetForm()
        {
            txtOTP.Text = EMAIL_COMPARE;
            lblOTP.Visible = false;
        }

        private string ConvertStringUI(string input)
        {
            if (input == EMAIL_COMPARE)
            {
                return "";
            }

            return input;
        }

        private void SetColor()
        {
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            txtOTP.BackColor = Constants.MAIN_BACK_COLOR;

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
            Constants.CountIncorrect++;

            var otp = txtOTP.Text.Trim();

            if (string.IsNullOrEmpty(otp) || string.Equals(otp, "OTP") || otp != Constants.OTP)
            {
                if (Constants.CountIncorrect < 4)
                {
                    MyMessageBox.Show("OTP không hợp lệ, vui lòng kiểm tra lại email!", MessageBoxType.Error);
                }
                RestSetForm();

                // Nếu sai 4 lần là  cảnh báo
                if (Constants.CountIncorrect == 4)
                {
                    MyMessageBox.Show($"Bạn đã nhập sai {Constants.CountIncorrect} lần, nếu nhập sai 5 lần tài khoản của bạn sẽ bị khóa trong 14 ngày", MessageBoxType.Warning);
                }

                // Nếu 5 lần sai thì khóa tài khoản
                if (Constants.CountIncorrect == 5)
                {
                    // Code khòa tài khoản
                    _userDAO.BlockUser(Constants.Username);

                    // Gửi mail, tài khoản của bạn đã bị khóa
                    SendOTPToEmailToBlockUser();

                    MyMessageBox.Show($"Tài khoản {Constants.Username} đã bị khóa 14 ngày", MessageBoxType.Warning);

                    Constants.OTP = null;
                    Constants.NewPassword = null;
                    Constants.Username = null;
                    Constants.Email = null;
                    Constants.CountIncorrect = 0;

                    // Chuyển sang trang login
                    Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.LOGIN);
                }

                return;
            }

            // Đổi pass tại đây
            if (_userDAO.ChangePassword(Constants.Username, Constants.NewPassword))
            {
                Constants.CountIncorrect = 0;

                MyMessageBox.Show("Đổi thành công thành", MessageBoxType.Success);

                Constants.OTP = null;
                Constants.NewPassword = null;
                Constants.Username = null;

                Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.LOGIN);
            }
            else
            {
                MyMessageBox.Show("Đổi mật khẩu thất bại, vui lòng kiểm tra lại sau", MessageBoxType.Error);
            }
            RestSetForm();
        }

        private void btnResendOTP_Click(object sender, EventArgs e)
        {
            SendOTPToEmail();

            MyMessageBox.Show($"Chúng tôi đã gửi mã OTP qua email {Constants.Email}, vui lòng kiểm tra lại!", MessageBoxType.Infomation);
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
        private async void SendOTPToEmailToBlockUser()
        {
            await SendMailToBlockUser();
        }

        private async Task SendMailToBlockUser()
        {
            var content = File.ReadAllText("./../../Assets/Template/BlockAccount.html");

            var us = _userDAO.GetByUsername(Constants.Username);

            content = content.Replace("{{Name}}", us.Name);

            await MailHelper.SendMail(us.Email, "Khóa tài khoản FACEBOOK", content);
        }

        #endregion

        #region UI

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            var txt = txtOTP.Text;
            lblOTP.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, EMAIL_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtOTP.Text = "";

                // Cho label hiện lên
                lblOTP.Visible = true;
            }

            // Color
            txtOTP.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlOTP.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            var txt = txtOTP.Text;
            lblOTP.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtOTP.Text = EMAIL_COMPARE;

                // Cho label ẩn đi
                lblOTP.Visible = false;
            }

            // Color
            txtOTP.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlOTP.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
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
