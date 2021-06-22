using Facebook.Common;
using Facebook.ControlCustom.Image;
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

namespace Facebook.Components.Profile
{
    public partial class InfoProfileImageItemUC : UserControl
    {
        private string path;

        public InfoProfileImageItemUC(string path)
        {
            InitializeComponent();

            this.path = path;

            Load();
        }

        int margin = 20;
        int border = 1;

        #region Methods

        new private void Load()
        {
            pnlWrap.Width = this.Width - 2 * margin + 2 * border;
            pnlWrap.Height = this.Height - 2 * margin + 2 * border;
            pnlWrap.Location = new Point(margin - border, margin - border);
            pnlWrap.BackColor = Constants.BORDER_IMAGE_COLOR;

            picImage.BackgroundImage = Image.FromFile(path);
            picImage.BackgroundImageLayout = ImageLayout.Stretch;
            picImage.Width = this.Width - 2 * margin;
            picImage.Height = this.Height - 2 * margin;
            picImage.Location = new Point(border, border);

            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(picImage, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);
        }

        #endregion

        #region Events

        private void picImage_Click(object sender, EventArgs e)
        {
            MyImage.Show(path);
        }


        #endregion
    }
}
