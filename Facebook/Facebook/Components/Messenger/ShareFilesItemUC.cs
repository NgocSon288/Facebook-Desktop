using Facebook.Common;
using Facebook.ControlCustom.Message;
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
    public partial class ShareFilesItemUC : UserControl
    {
        private string fileName;

        public ShareFilesItemUC(string fileName)
        {
            InitializeComponent();

            this.fileName = fileName;

            Load();
        }

        #region Methods

        new private void Load()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;

            var text = fileName.Substring(9);

            if (text.Length > 30)
            {
                text = text.Substring(text.Length - 30).PadLeft(33, '.');
            }

            lblFileName.Text = text;
            lblFileName.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            lblFileName.BackColor = Constants.MAIN_BACK_COLOR;

            picIcon.IconColor = Constants.MAIN_FORE_COLOR;
            picIcon.BackColor = Constants.MAIN_BACK_COLOR;
            picIcon.Visible = false;
        }

        #endregion

        private void ShareFilesItemUC_MouseEnter(object sender, EventArgs e)
        {
            picIcon.Visible = true;
        }

        private void ShareFilesItemUC_MouseLeave(object sender, EventArgs e)
        {
            picIcon.Visible = false;
        }

        private void picIcon_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFile = new SaveFileDialog();
                saveFile.Title = "Chọn nơi lưu file";
                saveFile.FileName = fileName.Substring(9);
                saveFile.Filter = $"Files (*{Path.GetExtension(fileName)})|*{Path.GetExtension(fileName)};)";
                saveFile.DefaultExt = Path.GetExtension(fileName);

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    File.Copy($"./../../Assets/Files/Messenger/{fileName}", saveFile.FileName);

                    MyMessageBox.Show("Lưu file thành công", MessageBoxType.Success);
                }
            }
            catch (Exception)
            {
                MyMessageBox.Show("Lưu file thất bại", MessageBoxType.Error);
            }
        }
    }
}
