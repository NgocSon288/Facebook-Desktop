using Facebook.Common;
using Facebook.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Drive
{
    public partial class DriveContentEmptyUC : UserControl
    {
        public DriveContentEmptyUC()
        {
            InitializeComponent();

            Load();
        }

        new private void Load()
        {
            picImage.BackgroundImage = Image.FromFile("./../../Assets/Images/Drive/drive-empty.png");
            picImage.BackgroundImageLayout = ImageLayout.Stretch;

            lbl1.ForeColor = lbl2.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;

            pnlWrap.Left = this.Width / 2 - pnlWrap.Width / 2;
            pnlWrap.Top = this.Height / 2 - pnlWrap.Height / 2;

            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(pnlWrap, pnlWrap.Width);
        }

        new public void DragEnter()
        {
            this.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
        }

        new public void DragLeave()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
        }
    }
}
