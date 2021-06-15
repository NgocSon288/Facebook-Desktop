using Facebook.Common;
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

namespace Facebook.Components.Messenger
{
    public partial class FileAttachItemUC : UserControl
    {
        public delegate void DeleteImage();
        public event DeleteImage OnDeleteImage;

        private string path;

        public FileAttachItemUC(string path)
        {
            InitializeComponent();

            this.path = path;

            Load();
        }

        #region Methods

        new private void Load()
        {
            lblName.Text = Path.GetFileName(path);

            this.BackColor = Constants.FILE_BACKGROUND_COLOR;

            picFile.IconColor = Constants.MAIN_FORE_COLOR;
            picFile.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlWrapIcon.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnDelete.BackColor = Constants.FILE_BACKGROUND_COLOR;
            btnDelete.IconColor = Constants.ERROR_COLOR;


            tt.SetToolTip(lblName, lblName.Text);

            UIHelper.BorderRadius(pnlWrapIcon, Constants.BORDER_RADIUS_MESSAGE_TEXT);
            UIHelper.BorderRadius(btnDelete, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }

        #endregion

        #region Events

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteImage?.Invoke();
        }

        #endregion

    }
}
