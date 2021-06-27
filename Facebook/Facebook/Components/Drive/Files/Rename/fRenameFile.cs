using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Facebook.Components.Drive.Files.Rename
{
    public partial class fRenameFile : Form
    {
        public delegate void ClickClose();
        public delegate void ClickUpdate(string name);
        public event ClickClose OnClickClose;
        public event ClickUpdate OnClickUpdate;

        private readonly IFolderDAO _folderDAO;

        private string oldName;

        public fRenameFile(IFolderDAO folderDAO)
        {
            InitializeComponent();

            this._folderDAO = folderDAO;

            Load();
        }

        private int margin = 2;

        #region Methods

        new private void Load()
        {
            pnlWrap.Width = this.Width - 2 * margin;
            pnlWrap.Height = this.Height - 2 * margin;
            pnlWrap.Left = margin;
            pnlWrap.Top = margin;

            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            lblTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            lblTitle.Left = this.Width / 2 - lblTitle.Width / 2;

            oldName = DriveFileItemUC.CurrentFileItemUCFocus.fileName;
            oldName = oldName.Substring(9, oldName.IndexOf(".") - 9);
            txtName.Text = oldName;
            txtName.ForeColor = Constants.MAIN_FORE_COLOR;
            txtName.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            txtName.Left = this.Width / 2 - txtName.Width / 2;

            pnlBottom.BackColor = Constants.MAIN_FORE_COLOR;
            pnlBottom.Left = this.Width / 2 - pnlBottom.Width / 2;

            btnUpdate.BackColor = Constants.MAIN_FORE_LINK_COLOR;
            btnUpdate.FlatAppearance.BorderColor = Constants.MAIN_FORE_LINK_COLOR;
            btnUpdate.ForeColor = Constants.MAIN_FORE_COLOR;

            pnlWrap.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            this.BackColor = Constants.BORDER_BOX_COLOR;

            UIHelper.BorderRadius(pnlWrap, 5);
            UIHelper.BorderRadius(this, 5);
        }

        #endregion Methods

        #region Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnClickClose?.Invoke();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MyMessageBox.Show("Tên không hợp lệ!", MessageBoxType.Warning);
            }
            else
            {
                // kiểm tra tên file có trùng tên với các file của global folder
                var files = StringHelper.StringToStringList(DriveLinkUC.CurrentFolder.Files).Select(f => f.Substring(9, f.LastIndexOf(".") - 9));

                if (files.Contains(name) && !string.Equals(oldName, name, StringComparison.OrdinalIgnoreCase))
                {
                    MyMessageBox.Show("Tên thư mục đã tồn tại", MessageBoxType.Warning);
                }
                else if (files.Contains(name) && string.Equals(oldName, name, StringComparison.OrdinalIgnoreCase))
                {
                    OnClickClose?.Invoke();
                }
                else
                {
                    OnClickUpdate?.Invoke(name);
                }
            }
        }

        #endregion Events
    }
}