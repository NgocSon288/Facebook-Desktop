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
    public partial class MessengerContentMessageUC : UserControl
    {
        public delegate void SendMessage(string description, List<string> fileNames, List<string> imagePaths);
        public delegate void HeightChanged();
        public event SendMessage OnSendMessage;
        public event HeightChanged OnHeightChanged;

        private int txtHeightOld; // lưu trữ height cũ, nếu nó khác thì mới cập nhật lại
        private List<string> fileNames;    // Có  thể có 1 trong 2
        private List<string> imagePaths;

        private ImageAttachListUC imageAttachListUC;
        private FileAttachListUC fileAttachListUC;

        public MessengerContentMessageUC()
        {
            InitializeComponent();

            SetColor();
            Load();
            UIHelper.SetBlur(this, () => this.ActiveControl = pnlContent);
        }

        int marginAttach = 10;

        #region Methods

        new private void Load()
        {
            fileNames = new List<string>();
            imagePaths = new List<string>();
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            pnlContent.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;

            btnAttach.BackColor = Constants.MAIN_BACK_COLOR;
            btnAttach.IconColor = Constants.THEME_COLOR;
            btnAttach.FlatAppearance.MouseDownBackColor = Constants.MAIN_BACK_COLOR;
            btnAttach.FlatAppearance.MouseOverBackColor = Constants.MAIN_BACK_COLOR;

            btnSend.BackColor = Constants.MAIN_BACK_COLOR;
            btnSend.IconColor = Constants.THEME_COLOR;
            btnSend.FlatAppearance.MouseDownBackColor = Constants.MAIN_BACK_COLOR;
            btnSend.FlatAppearance.MouseOverBackColor = Constants.MAIN_BACK_COLOR;

            // Main
            txtDescription.BackColor = Constants.BACKGROUND_TEXTBOX_MYCOMMENT;
            txtDescription.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Height = 37;

            UIHelper.BorderRadius(pnlContent, Constants.BORDER_RADIUS * 2);
        }

        public void SetThemeColor()
        {
            btnAttach.IconColor = Constants.THEME_COLOR;
            btnSend.IconColor = Constants.THEME_COLOR;
        }

        private void UpdateHeightText()
        {
            if (txtHeightOld != txtDescription.Height)
            {
                UpdateHeight();
            }
        }

        private void UpdateWithAttachFile()
        {
            var check = IsAttachFileOrImage();

            // Có file
            if (check)
            {
                // Gỉa sử có image, từ từ  có file
                if (imagePaths.Count > 0)
                {
                    pnlContent.Controls.Remove(imageAttachListUC);
                    imageAttachListUC = new ImageAttachListUC(imagePaths);
                    imageAttachListUC.OnHeightChanged += UpdateHeight;

                    pnlContent.Controls.Add(imageAttachListUC);
                }

                if (fileNames.Count > 0)
                {
                    pnlContent.Controls.Remove(fileAttachListUC);
                    fileAttachListUC = new FileAttachListUC(fileNames);
                    fileAttachListUC.OnHeightChanged += UpdateHeight;

                    pnlContent.Controls.Add(fileAttachListUC);
                }

                UpdateHeight();

            }
        }

        private void UpdateHeight()
        {
            if (imageAttachListUC == null)
            {
                imageAttachListUC = new ImageAttachListUC(imagePaths);
            }
            if (fileAttachListUC == null)
            {
                fileAttachListUC = new FileAttachListUC(fileNames);
            }

            txtHeightOld = txtDescription.Height;
            var imgHeight = imageAttachListUC.Height;
            var fileHeight = fileAttachListUC.Height;

            pnlContent.Height = txtDescription.Height + 30 + imgHeight + fileHeight;
            imageAttachListUC.Top = 13;
            fileAttachListUC.Top = imageAttachListUC.Bottom;
            txtDescription.Top = fileAttachListUC.Bottom;

            this.Height = pnlContent.Height + 48;

            UIHelper.BorderRadius(pnlContent, Constants.BORDER_RADIUS * 2);
            OnHeightChanged?.Invoke();
        }

        private bool IsAttachFileOrImage()
        {
            return fileNames.Count > 0 || imagePaths.Count > 0;
        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            var text = txtDescription.Text;

            if ((text == "Aa" || text == "") && fileNames.Count <= 0 && imagePaths.Count <= 0)
            {
                return;
            }


            // Thông báo cho cha các dữ liệu
            OnSendMessage?.Invoke(text == "Aa" ? "" : text, imagePaths, fileNames);

            txtDescription.Text = "Aa";
            fileNames.Clear();
            imagePaths.Clear();
            imageAttachListUC.Controls.Clear();
            fileAttachListUC.Controls.Clear();

            imageAttachListUC.UpdateHeight();
            fileAttachListUC.UpdateHeight();

            UpdateHeight();
            OnHeightChanged?.Invoke();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            UIHelper.SetSizeTextBox(txtDescription);

            UpdateHeightText();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSend_Click(null, null);
                e.Handled = true;
            }

        }

        private void txtDescription_MouseEnter(object sender, EventArgs e)
        {
            txtDescription.ForeColor = Constants.MAIN_FORE_COLOR;
            var text = txtDescription.Text;

            if (text == "Aa")
            {
                txtDescription.Text = "";
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtDescription.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            var text = txtDescription.Text;

            if (text == "")
            {
                txtDescription.Text = "Aa";
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in open.FileNames)
                {
                    var extension = Path.GetExtension(file);
                    if (".jpg; .jpeg; .gif; .bmp; .jfif; .png".Contains(extension))
                    {
                        // lọc các file là  image
                        if (!imagePaths.Contains(file))
                        {
                            imagePaths.Add(file);
                        }
                    }
                    else
                    {
                        // lọc các file không là image
                        if (!fileNames.Contains(file))
                        {
                            fileNames.Add(file);
                        }
                    }
                }
            }

            UpdateWithAttachFile();
        }
    }
}
