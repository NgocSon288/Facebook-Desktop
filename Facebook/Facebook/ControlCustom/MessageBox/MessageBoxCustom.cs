using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.ControlCustom.Message
{
    public partial class MessageBoxCustom : Form
    {
        MessageBoxChild child;
        MyDialogResult result;

        public MessageBoxCustom(string message, string title, MessageBoxType type, MyDialogResult result)
        {
            InitializeComponent();

            this.result = result;


            Thread thread = new Thread(() =>
            {
                child = new MessageBoxChild(message, title, type, this);
                child.Name = "child";
                child.OnClickOk += Child_OnClickOk;
                child.OnClickCancel += Child_OnClickCancel;
                child.ShowDialog();
            });

            thread.Start();

            this.GotFocus += MessageBoxCustom_GotFocus;
        }

        private void MessageBoxCustom_GotFocus(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Application.OpenForms["child"]?.Activate();
            }));
        }

        private void Child_OnClickCancel()
        {
            Invoke(new Action(() =>
            {
                this.result.Value = DialogResult.Cancel;
                this.Close();
            }));
        }

        private void Child_OnClickOk()
        {
            Invoke(new Action(() =>
            {
                this.result.Value = DialogResult.OK;
                this.Close();
            }));
        }

        private void MessageBoxCustom_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Application.OpenForms["child"].Activate();
            }));
        }

    }
}
