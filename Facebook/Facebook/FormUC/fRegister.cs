using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
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
    public partial class fRegister : UserControl
    {
        private readonly IUserDAO _userDAO;

        public fRegister(IUserDAO userDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;

            SetUpUI();
            Load();
        }

        private string NAME_COMPARE = "Tên đại diện";
        private string USERNAME_COMPARE = "Tài khoản";
        private string PASSWORD_COMPARE = "Mật khẩu";
        private string CONFIRM_PASSWORD_COMPARE = "Nhập lại mật khẩu";
        private string EMAIL_COMPARE = "Email";

        #region Methods

        new private void Load()
        {
            // Setup hình ảnh social
            picFacebook.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-facebook.png");
            picTwitter.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-twitter.png");
            picGoogle.BackgroundImage = new Bitmap("./../../Assets/Images/btn-social-google.png");

            SetColor();
        }

        private string ConvertStringUI(string input)
        {
            if (input == NAME_COMPARE || input == USERNAME_COMPARE || input == PASSWORD_COMPARE || input == CONFIRM_PASSWORD_COMPARE || input == EMAIL_COMPARE)
            {
                return "";
            }

            return input;
        }

        public void RestSetForm()
        {
            txtName.Text = NAME_COMPARE;
            txtUsername.Text = USERNAME_COMPARE;
            txtPassword.Text = PASSWORD_COMPARE;
            txtConfirmPassword.Text = CONFIRM_PASSWORD_COMPARE;
            txtEmail.Text = EMAIL_COMPARE;

            txtPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.UseSystemPasswordChar = false;

            lblName.Visible = false;
            lblUsername.Visible = false;
            lblPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            lblEmail.Visible = false;
        }

        private void SetColor()
        {
            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;

            txtName.BackColor = Constants.MAIN_BACK_COLOR;
            txtUsername.BackColor = Constants.MAIN_BACK_COLOR;
            txtPassword.BackColor = Constants.MAIN_BACK_COLOR;
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
        /// Tạo tài khoản mới và chuyển vào trang fmain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var name = ConvertStringUI(txtName.Text);
            var username = ConvertStringUI(txtUsername.Text);
            var password = ConvertStringUI(txtPassword.Text);
            var confirmPassword = ConvertStringUI(txtConfirmPassword.Text);
            var email = ConvertStringUI(txtEmail.Text);

            if (string.IsNullOrEmpty(name.Trim()) || string.IsNullOrEmpty(username.Trim()) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MyMessageBox.Show("Thông tin đăng ký không hợp lệ", MessageBoxType.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MyMessageBox.Show("Xác nhận mật khẩu không hợp lệ", MessageBoxType.Error);
                return;
            }

            var check = await _userDAO.Register(name, username, password, email);

            if (check == -1)
            {
                MyMessageBox.Show("Email không hợp lệ", MessageBoxType.Error);
                return;
            }
            else if (check == -2)
            {
                MyMessageBox.Show("Tài khoản đã có người sử dụng", MessageBoxType.Warning);
                return;
            }
            else if (check == 0)
            {
                MyMessageBox.Show("Lỗi trong quá trình đăng ký, vui lòng thử lại", MessageBoxType.Error);
                return;
            }

            MyMessageBox.Show("Tạo tài khoản thành công", MessageBoxType.Success);

            // Chuyển qua trang đăng nhập
            btnLogin_Click(null, new EventArgs());

            //// Đăng ký thành công
            //// Đưa user vào session
            //Constants.UserSession = _userDAO.GetByUsername(username);

            //// chuyển vào trang fmain 
            //Constants.AccountForm.Close();
            //Constants.MainForm.Visible = true;
        }

        /// <summary>
        /// Chuyển sang trang đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Constants.AccountForm.SwitchFormSwitchForm(fAccountForm.ACCOUNT_FORM.LOGIN);
        }

        #endregion

        #region UI

        private void txtName_Enter(object sender, EventArgs e)
        {
            var txt = txtName.Text;
            lblName.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;

            // Text
            if (string.Equals(txt, NAME_COMPARE, StringComparison.OrdinalIgnoreCase))
            {
                txtName.Text = "";

                // Cho label hiện lên
                lblName.Visible = true;
            }

            // Color
            txtName.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlName.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            var txt = txtName.Text;
            lblName.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;

            // Text
            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
            {
                txtName.Text = NAME_COMPARE;

                // Cho label ẩn đi
                lblName.Visible = false;
            }

            // Color
            txtName.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlName.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

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
            pnlPassword.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
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
            pnlPassword.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
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
                btnRegister_Click(null, new EventArgs());
            }
        }

        #endregion
    }
}
