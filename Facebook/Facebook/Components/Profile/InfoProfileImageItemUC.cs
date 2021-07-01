using Facebook.Common;
using Facebook.ControlCustom.Image;
using Facebook.DTO;
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
        private MetadataImage metadata;
        private Image image;

        public InfoProfileImageItemUC(MetadataImage metadata)
        {
            InitializeComponent();

            this.metadata = metadata;

            Load();
        }

        int margin = 20;
        int border = 1;

        #region Methods

        new private void Load()
        {
            image = Image.FromFile(metadata.Path);

            pnlWrap.Width = this.Width - 2 * margin + 2 * border;
            pnlWrap.Height = this.Height - 2 * margin + 2 * border;
            pnlWrap.Location = new Point(margin - border, margin - border);
            pnlWrap.BackColor = Constants.BORDER_IMAGE_COLOR;

            picImage.BackgroundImage = image;
            picImage.BackgroundImageLayout = ImageLayout.Stretch;
            picImage.Width = this.Width - 2 * margin;
            picImage.Height = this.Height - 2 * margin;
            picImage.Location = new Point(border, border);

            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            UIHelper.BorderRadius(picImage, Constants.BORDER_RADIUS);
            UIHelper.BorderRadius(pnlWrap, Constants.BORDER_RADIUS);

            // Tên hình ảnh
            // Thời gian tạo
            // Chủ nhân
            // kích thước

            var name = metadata.Path.Substring(metadata.Path.LastIndexOf('/') + 1).Substring(9);
            var time = metadata.CreatedAt.ToString();
            var own = metadata.Own;
            var size = $"{image.Width} x {image.Height} px";

            var mess = $"{"Name:",-15}{name}\n{"Created at:",-14}{time}\n{"Owner:",-15}{own}\n{"Size:",-18}{size}";
            if (!string.IsNullOrEmpty(metadata.FromPost))
            {
                var des = metadata.FromPost.Length > 30 ? metadata.FromPost.Substring(0, 27) + "..." : metadata.FromPost;
                mess = $"{"Name:",-15}{name}\n{"Created at:",-14}{time}\n{"Owner:",-15}{own}\n{"Size:",-18}{size}\n{"From:",-16}{des}";
            }
            tt.SetToolTip(picImage, mess);
        }

        #endregion

        #region Events

        private void picImage_Click(object sender, EventArgs e)
        {
            MyImage.Show(metadata.Path);
        }


        #endregion
    }
}
