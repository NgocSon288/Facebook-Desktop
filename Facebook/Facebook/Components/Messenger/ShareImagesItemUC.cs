using Facebook.Common;
using Facebook.ControlCustom.Image;
using Facebook.ControlCustom.Message;
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
    public partial class ShareImagesItemUC : UserControl
    {
        private string path;

        public ShareImagesItemUC(string path)
        {
            InitializeComponent();

            this.path = path;

            Load();
        }

        #region Methods

        new private void Load()
        {
            this.BackgroundImage = Image.FromFile($"./../../Assets/Images/Messenger/{path}");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            pnlWrap.BackColor = Color.FromArgb(100, 30, 30, 30);
            pnlWrap.Visible = true;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }

        private void cmsSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFile = new SaveFileDialog();
                saveFile.Title = "Chọn nơi lưu hình ảnh";
                saveFile.FileName = path.Substring(9);
                saveFile.Filter = $"Image (*{Path.GetExtension(path)})|*{Path.GetExtension(path)};)";
                saveFile.DefaultExt = Path.GetExtension(path);

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    File.Copy($"./../../Assets/Images/Messenger/{path}", saveFile.FileName);

                    MyMessageBox.Show("Lưu hình ảnh thành công", MessageBoxType.Success);
                }
            }
            catch (Exception)
            {
                MyMessageBox.Show("Lưu hình ảnh thất bại", MessageBoxType.Error);
            }
        }

        private void pnlWrap_MouseEnter(object sender, EventArgs e)
        {
            pnlWrap.Visible = false;
        }

        private void MessageItemImageItemUC_MouseLeave(object sender, EventArgs e)
        {
            pnlWrap.Visible = true;
        }

        private void MessageItemImageItemUC_Click(object sender, EventArgs e)
        {
            MyImage.Show($"./../../Assets/Images/Messenger/{path}");
        }

        #endregion
    }
}
