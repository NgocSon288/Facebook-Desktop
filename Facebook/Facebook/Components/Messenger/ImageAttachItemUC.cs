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

namespace Facebook.Components.Messenger
{
    public partial class ImageAttachItemUC : UserControl
    {
        public delegate void DeleteImage();
        public event DeleteImage OnDeleteImage;

        private string path;

        public ImageAttachItemUC(string path)
        {
            InitializeComponent();

            this.path = path;

            Load();
        }

        #region Methods

        new private void Load()
        {
            this.BackgroundImage = Image.FromFile(path);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            btnDelete.IconColor = Constants.ERROR_COLOR;

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
