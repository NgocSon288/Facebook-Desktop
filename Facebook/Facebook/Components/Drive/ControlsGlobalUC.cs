using Facebook.Common;
using Facebook.Components.Drive.Global.NewFolder;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.ControlCustom.WrapperForm;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using FontAwesome.Sharp;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Drive
{
    public partial class ControlsGlobalUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void CreateNewFolder(string folderName);
        public delegate void UploadFolder(List<string> foldersPath);
        public delegate void UploadFile(List<string> filesPath);
        public event ClickSpace OnClickSpace;
        public event CreateNewFolder OnCreateNewFolder;
        public event UploadFolder OnUploadFolder;
        public event UploadFile OnUploadFile;

        private readonly IFolderDAO _folderDAO;

        private ControlsItemUC pasteCon;

        public ControlsGlobalUC(IFolderDAO folderDAO)
        {
            InitializeComponent();

            this._folderDAO = folderDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            LoadControls();

            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void LoadControls()
        {
            // New
            var newCon = new ControlsItemUC(IconChar.FolderPlus, "Tạo mới thư mục");
            newCon.OnClickControl += () =>
            {
                var fnewFolder = new fNewFolder(AutofacFactory<IFolderDAO>.Get());
                var fparent = new fParentClickHidden(fnewFolder);
                var fName = "";

                // Close và không thêm thư mục mới
                fnewFolder.OnClickClose += () =>
                {
                    fName = "";
                    fparent.FParentClickHidden_Click(null, null);
                };

                fnewFolder.OnClickCreate += (folderName) =>
                {
                    fName = folderName;
                    fparent.FParentClickHidden_Click(null, null);
                };

                fparent.FormClosed += (s, o) =>
                {
                    if (!string.IsNullOrEmpty(fName.Trim()))
                    {
                        OnCreateNewFolder?.Invoke(fName);
                    }
                };

                // Close và thực hiện thêm thư mục

                fparent.ShowDialog();
            };

            // Upload folder
            var upFolderCon = new ControlsItemUC(IconChar.FolderOpen, "Upload thư mục từ máy tính");
            upFolderCon.OnClickControl += () =>
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                dialog.Multiselect = true;
                dialog.Title = "Chọn những thư mục bạn muốn upload";

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    // danh sách các folder được chọn
                    List<string> folderNames = dialog.FileNames.ToList();

                    // kiểm tra nếu có ít nhất một folder trùng tên thì hỏi có muốn ghi đè không
                    List<Folder> fds = _folderDAO.GetByListID(StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID));

                    var fExists = 0;

                    foreach (var item in folderNames)
                    {
                        if (fds.Any(f => string.Equals(f.Name, item.Substring(item.LastIndexOf("\\") + 1), StringComparison.OrdinalIgnoreCase)))
                        {
                            fExists++;
                        }
                    }

                    if (fExists > 0)
                    {
                        if (MyMessageBox.Show($"Có {fExists} thư mục đã tồn tại, bạn có muốn ghi đè?", MessageBoxType.Question).Value == DialogResult.OK)
                        {
                            OnUploadFolder?.Invoke(folderNames);
                        }
                    }
                    else
                    {
                        OnUploadFolder?.Invoke(folderNames);
                    }
                }
            };

            // Upload file
            var upFileCon = new ControlsItemUC(IconChar.FileUpload, "Upload file từ máy tính");
            upFileCon.OnClickControl += () =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Title = "Chọn những file bạn muốn upload";
                dialog.Filter = "All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OnUploadFile?.Invoke(dialog.FileNames.ToList());
                }
            };

            // Paste
            pasteCon = new ControlsItemUC(IconChar.Paste, "Paste");
            pasteCon.OnClickControl += () =>
            {

            };


            flpControls.Controls.AddRange(new Control[] { newCon, upFolderCon, upFileCon, pasteCon });

            CheckClipboard();
        }

        public void CheckClipboard()
        {
            pasteCon.Visible = Constants.Clipboard != null;
        }

        #endregion

        #region Events 

        private void ControlsGlobalUC_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        #endregion
    }
}
