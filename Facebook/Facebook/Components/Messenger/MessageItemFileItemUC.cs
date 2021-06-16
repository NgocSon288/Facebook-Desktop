using Facebook.Common;
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
    public partial class MessageItemFileItemUC : UserControl
    {
        private string fileName;

        public MessageItemFileItemUC(string fileName)
        {
            InitializeComponent();

            this.fileName = fileName;

            Load();
            UpdateHeight();
        }

        int margin = 10;

        #region Methods

        new private void Load()
        {
            lblName.Text = fileName.Substring(9);
            if (lblName.Text.Length > 20)
            {
                lblName.Text = "..." + lblName.Text.Substring(lblName.Text.Length - 20);
            }


            lblName.ForeColor = Constants.MAIN_FORE_COLOR;

            this.Width = lblName.Left + lblName.Width + 10;
            if (this.Width < 301)
            {
                this.Width = 301;
            }

            this.BackColor = Constants.MAIN_BACK_CONTENT_ENTER_COLOR;

            picFile.IconColor = Constants.MAIN_FORE_COLOR;
            picFile.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlWrapIcon.BackColor = Constants.MAIN_BACK_COLOR;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS_MESSAGE_TEXT);
            UIHelper.BorderRadius(pnlWrapIcon, Constants.BORDER_RADIUS_MESSAGE_TEXT);
        }

        private void UpdateHeight()
        {
        }

        #endregion

        private void pnlWrapIcon_Click(object sender, EventArgs e)
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
