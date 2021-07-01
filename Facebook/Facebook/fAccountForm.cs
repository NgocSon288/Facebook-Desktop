using Autofac;
using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
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
        public fLogin fLogin;
        private fRegister fRegister;
        private fFogetPassword fFogetPassword;
        private fVerifyPassword fVerifyPassword;

        public fAccountForm()
        {
            InitializeComponent();

            Load();
        }

        public enum ACCOUNT_FORM
        {
            LOGIN,
            REGISTER,
            FORGET_PASSWORD,
            VERIFY_PASSWORD
        }

        #region Methods

        new private void Load()
        {
            Constants.AccountForm = this;

            // Thêm 3 form: login, register, forget vào form chính của account
            fLogin = new fLogin(AutofacFactory<IUserDAO>.Get(), AutofacFactory<IProfileDAO>.Get()) { Left = 0, Top = 0 };
            fRegister = new fRegister(AutofacFactory<IUserDAO>.Get()) { Left = 0, Top = 0, Visible = false };
            fFogetPassword = new fFogetPassword(AutofacFactory<IUserDAO>.Get()) { Left = 0, Top = 0, Visible = false };
            fVerifyPassword = new fVerifyPassword(AutofacFactory<IUserDAO>.Get()) { Left = 0, Top = 0, Visible = false };

            this.panelContent.Controls.Add(fLogin);
            this.panelContent.Controls.Add(fRegister);
            this.panelContent.Controls.Add(fFogetPassword);
            this.panelContent.Controls.Add(fVerifyPassword);
        }

        public void SwitchFormSwitchForm(ACCOUNT_FORM ACCOUNT_FORM)
        {
            switch (ACCOUNT_FORM)
            {
                case ACCOUNT_FORM.LOGIN:
                    fLogin.Visible = true;
                    fLogin.RestSetForm();
                    fRegister.Visible = false;
                    fFogetPassword.Visible = false;
                    fVerifyPassword.Visible = false;
                    break;
                case ACCOUNT_FORM.REGISTER:
                    fLogin.Visible = false;
                    fRegister.Visible = true;
                    fRegister.RestSetForm();
                    fFogetPassword.Visible = false;
                    fVerifyPassword.Visible = false;
                    break;
                case ACCOUNT_FORM.FORGET_PASSWORD:
                    fLogin.Visible = false;
                    fRegister.Visible = false;
                    fFogetPassword.Visible = true;
                    fFogetPassword.RestSetForm();
                    fVerifyPassword.Visible = false;
                    break;
                case ACCOUNT_FORM.VERIFY_PASSWORD:
                    fLogin.Visible = false;
                    fRegister.Visible = false;
                    fFogetPassword.Visible = false;
                    fVerifyPassword.Visible = true;
                    fVerifyPassword.RestSetForm();
                    break;
            }
        }

        #endregion

        #region Events

        #endregion
    }
}
