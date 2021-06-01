using Facebook.Common;
using Facebook.FormUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook
{
    public partial class fAccountForm : Form
    {
        private fLogin fLogin;
        private fRegister fRegister;
        private fFogetPassword fFogetPassword;

        public fAccountForm()
        {
            InitializeComponent();

            Load();
        }

        public enum ACCOUNT_FORM
        {
            LOGIN,
            REGISTER,
            FORGET_PASSWORD
        }

        #region Methods

        new private void Load()
        {
            Constants.AccountForm = this;

            // Thêm 3 form: login, register, forget vào form chính của account
            fLogin = new fLogin() { Left = 0, Top = 0 };
            fRegister = new fRegister() { Left = 0, Top = 0, Visible = false };
            fFogetPassword = new fFogetPassword() { Left = 0, Top = 0, Visible = false };

            this.Controls.Add(fLogin);
            this.Controls.Add(fRegister);
            this.Controls.Add(fFogetPassword);
        }

        public void SwitchFormSwitchForm(ACCOUNT_FORM ACCOUNT_FORM)
        {
            switch (ACCOUNT_FORM)
            {
                case ACCOUNT_FORM.LOGIN:
                    fLogin.Visible = true;
                    fRegister.Visible = false;
                    fFogetPassword.Visible = false;
                    break;
                case ACCOUNT_FORM.REGISTER:
                    fLogin.Visible = false;
                    fRegister.Visible = true;
                    fFogetPassword.Visible = false;
                    break;
                case ACCOUNT_FORM.FORGET_PASSWORD:
                    fLogin.Visible = false;
                    fRegister.Visible = false;
                    fFogetPassword.Visible = true;
                    break;
            }
        }

        #endregion


        #region Events



        #endregion
    }
}
