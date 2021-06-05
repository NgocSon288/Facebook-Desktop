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

namespace Facebook.ControlCustom.WrapperForm
{
    public partial class fParent : Form
    {

        private Form child;

        public fParent(Form child)
        {
            InitializeComponent();

            this.child = child;
            child.Name = "child";
            child.FormClosed += Child_FormClosed;

            Thread thread = new Thread(() =>
            {
                child.ShowDialog();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Gíup focus vào  childForm
            this.GotFocus += FParent_GotFocus;
            this.Click += FParent_Click;
            this.DoubleClick += FParent_Click;
        }

        #region Parent events, methods

        private void FParent_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Application.OpenForms["child"].Activate();
            }));
        }

        private void FParent_GotFocus(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Application.OpenForms["child"]?.Activate();
            }));
        }

        #endregion

        #region Child events methods

        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            //Invoke(new Action(() =>
            //{
            //})); 
        }

        #endregion
    }
}
