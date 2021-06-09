using Facebook.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.ControlCustom.Image
{
    public partial class fImageShow : Form
    {
        private string path;

        public fImageShow(string path)
        {
            InitializeComponent();

            this.path = path;

            Load();
        }

        private int margin = 5;
        private int MIN_WIDTH = 1000;
        private int MAX_WIDTH = 1600;

        #region Methods

        new private void Load()
        {
            var image = new Bitmap(path);
            var height = image.Height;
            var width = image.Width;

            // min width
            if (width < MIN_WIDTH)
            {
                height = MIN_WIDTH * height / width;
                width = MIN_WIDTH;
            }

            if (width > MAX_WIDTH)
            {
                height = MAX_WIDTH * height / width;
                width = MAX_WIDTH;
            }



            picImage.BackgroundImage = image;
            picImage.BackgroundImageLayout = ImageLayout.Stretch;
            picImage.Height = height;
            picImage.Width = width;
            picImage.Left = margin;
            picImage.Top = margin;

            this.Height = height + margin * 2;
            this.Width = width + margin * 2;
            this.BackColor = Constants.ERROR_COLOR;
        }

        #endregion

        #region Events



        #endregion
    }
}
