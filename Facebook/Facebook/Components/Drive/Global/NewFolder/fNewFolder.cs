using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Facebook.Components.Drive.Global.NewFolder
{
    public partial class fNewFolder : Form
    {
        public delegate void ClickClose();
        public delegate void ClickCreate(string name);
        public event ClickClose OnClickClose;
        public event ClickCreate OnClickCreate;

        private readonly IFolderDAO _folderDAO;

        public fNewFolder(IFolderDAO folderDAO)
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

            txtName.ForeColor = Constants.MAIN_FORE_COLOR;
            txtName.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            txtName.Left = this.Width / 2 - txtName.Width / 2;

            pnlBottom.BackColor = Constants.MAIN_FORE_COLOR;
            pnlBottom.Left = this.Width / 2 - pnlBottom.Width / 2;

            btnCreate.BackColor = Constants.MAIN_FORE_LINK_COLOR;
            btnCreate.FlatAppearance.BorderColor = Constants.MAIN_FORE_LINK_COLOR;
            btnCreate.ForeColor = Constants.MAIN_FORE_COLOR;

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

            if (string.Equals(name, "Nhập tên thư mục", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(name))
            {
                MyMessageBox.Show("Tên không hợp lệ!", MessageBoxType.Warning);
            }
            else
            {
                var folders = _folderDAO.GetByListID(StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID));
                var fd = folders.FirstOrDefault(f => string.Equals(name, f.Name));

                if (fd != null)
                {
                    MyMessageBox.Show("Tên thư mục đã tồn tại", MessageBoxType.Warning);
                }
                else
                {
                    OnClickCreate?.Invoke(name);
                }
            }
        }

        #endregion Events
    }
}