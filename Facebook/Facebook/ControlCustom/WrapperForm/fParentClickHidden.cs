using Facebook.Common;
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
    public partial class fParentClickHidden : Form
    {
        private Form child;

        public fParentClickHidden(Form child)
        {
            InitializeComponent();

            this.Opacity = Constants.OPACITY;

            Control.CheckForIllegalCrossThreadCalls = false;

            this.child = child;

            var x = this.Width / 2 - child.Width / 2 + this.Left;
            var y = this.Height / 2 - child.Height / 2 + this.Top;

            child.Location = new Point(x, y);

            this.Click += FParentClickHidden_Click;
            this.DoubleClick += FParentClickHidden_Click;

            Thread thread = new Thread(() =>
            {
                child.ShowDialog();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            //thread.Join();
        }

        private void FParentClickHidden_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                child.Close();
            }));
            this.Close();
        }
    }
}
