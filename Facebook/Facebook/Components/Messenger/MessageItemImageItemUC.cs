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
    public partial class MessageItemImageItemUC : UserControl
    {
        private string path;
        Bitmap bitmap;

        public MessageItemImageItemUC(string path)
        {
            InitializeComponent();

            this.path = path;

            Load();
        }

        #region Methods

        new private void Load()
        {
            bitmap = new Bitmap($"./../../Assets/Images/Messenger/{path}");
            SetNewBitmap();
            this.BackgroundImage = bitmap;

            pnlWrap.BackColor = Color.FromArgb(100, 30, 30, 30);
            pnlWrap.Visible = true;

            this.BackgroundImageLayout = ImageLayout.Stretch;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }

        private void SetNewBitmap()
        {

        }

        #endregion

        private void cmsSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFile = new SaveFileDialog();
                saveFile.Title = "Chọn nơi lưu hình ảnh";
                saveFile.FileName = path.Substring(9);

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
    }
}
