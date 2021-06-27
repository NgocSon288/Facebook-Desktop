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
        public delegate void Paste();
        public event ClickSpace OnClickSpace;
        public event CreateNewFolder OnCreateNewFolder;
        public event UploadFolder OnUploadFolder;
        public event UploadFile OnUploadFile;
        public event Paste OnPaste;

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
            // New  => xong
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

            // Upload folder    => xong
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

            // Upload file      => xong
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
                // Folder đang được focus, là folder sẽ paste clipboard vào   
                var isOk = true;

                if (Constants.Clipboard.IsFolder)
                {
                    //Kiểm tra paste folder vào global
                    // kiểm tra nếu folder đang copy có parent trùng với currentFolder
                    var err1 = DriveLinkUC.CurrentFolder.ID == Constants.Clipboard.ParentFolder.ID; // idglobal = idparent cũ

                    // kiểm tra nếu folder copy trùng với currentFolder
                    var err2 = Constants.Clipboard.Folder.ID == DriveLinkUC.CurrentFolder.ID;   // idcopy = idglobal

                    // kiểm tra folder global có phải là folder con cháu của folder copy
                    var err3 = false;
                    var tempF = DriveLinkUC.CurrentFolder;

                    while (tempF != null)
                    {
                        if (tempF.ID == Constants.Clipboard.Folder.ID)
                        {
                            err3 = true;
                            break;
                        }

                        if (tempF.ParentID != null)
                            tempF = _folderDAO.GetByID(tempF.ParentID.Value);
                        else
                        {
                            break;
                        }
                    }

                    if (err1 || err2 || err3)
                    {
                        isOk = false;
                    }
                }
                else
                {
                    // Kiểm tra paste file vào folder global
                    // kiểm tra file đang được copy có parent trùng với globalFolder
                    var err = Constants.Clipboard.ParentFolder.ID == DriveLinkUC.CurrentFolder.ID;

                    if (err)
                    {
                        isOk = false;
                    }
                }

                // Nếu ok thì mới thực hiện di chuyển file, folder 
                if (isOk)
                {
                    // duy chuyển file
                    var cutFolder = Constants.Clipboard.Folder; // folder được cut
                    var cutFile = Constants.Clipboard.FileName; // file được cut
                    var parentFolder = Constants.Clipboard.ParentFolder; // folder cha lúc đầu
                    var globalFolder = DriveLinkUC.CurrentFolder;    // folder cha lúc sau

                    if (Constants.Clipboard.IsFolder)
                    {
                        // trường hợp folder
                        // Cập nhật lại parentID của folder được cut
                        cutFolder.ParentID = globalFolder.ID;

                        // cập nhật childID của folder parent lúc đầu   -
                        var idList1 = StringHelper.StringToIntList(parentFolder.ChildrenID);
                        idList1.Remove(cutFolder.ID);
                        parentFolder.ChildrenID = StringHelper.IntListToString(idList1);


                        // kiểm tra name folder được cut có trùng tên folder con của folder global không 
                        var newName = cutFolder.Name;
                        var childList = _folderDAO.GetByListID(StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID));
                        if (childList.Any(c => string.Equals(c.Name, cutFolder.Name, StringComparison.OrdinalIgnoreCase)))
                        {
                            var i = 1;
                            newName = $"{cutFolder.Name} ({i++})";

                            while (childList.Any(c => string.Equals(c.Name, newName, StringComparison.OrdinalIgnoreCase)))
                            {
                                newName = $"{cutFolder.Name} ({i++})";
                            }
                        }

                        cutFolder.Name = newName;

                        // cập nhật childID của folder global       +
                        var idList2 = StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID);
                        idList2.Add(cutFolder.ID);
                        DriveLinkUC.CurrentFolder.ChildrenID = StringHelper.IntListToString(idList2);

                        _folderDAO.SaveChanges();
                    }
                    else
                    {
                        // trường hợp là file
                        // cập nhật file của folder parent lúc đầu   -
                        var fileList1 = StringHelper.StringToStringList(parentFolder.Files);
                        fileList1.Remove(cutFile);
                        parentFolder.Files = StringHelper.StringListToString(fileList1);


                        // kiểm tra name file được cut có trùng tên file con của folder global
                        var rand = cutFile.Substring(0, 9);
                        var name = cutFile.Substring(9, cutFile.LastIndexOf(".") - 9);
                        var ext = cutFile.Substring(cutFile.LastIndexOf("."));
                        var newName = name;
                        var fileList = StringHelper.StringToStringList(globalFolder.Files);
                        if (fileList.Any(c => string.Equals(c.Substring(9, c.LastIndexOf(".") - 9), newName, StringComparison.OrdinalIgnoreCase)))
                        {
                            var i = 1;
                            newName = $"{name} ({i++})";

                            while (fileList.Any(c => string.Equals(c.Substring(9, c.LastIndexOf(".") - 9), newName, StringComparison.OrdinalIgnoreCase)))
                            {
                                newName = $"{name} ({i++})";
                            }
                        }

                        fileList.Add(rand + newName + ext);
                        globalFolder.Files = StringHelper.StringListToString(fileList);

                        _folderDAO.SaveChanges();
                    }


                    OnPaste?.Invoke();
                }

                var mess = Constants.Clipboard.IsFolder ? "thư mục" : "file";

                // xóa cut, đổi màu folder, file trước đó
                var itemUC1 = Constants.CurrentCut as DriveFolderItemUC;
                var itemUC2 = Constants.CurrentCut as DriveFileItemUC;

                itemUC1?.UnCut();
                itemUC2?.UnCut();


                // Xóa clipboard, current cut
                Constants.Clipboard = null;
                Constants.CurrentCut = null;
                DriveFolderItemUC.CurrentFolderItemUCFocus?.SetColorAfterUnCut();
                CheckClipboard();


                // Luôn luôn thông báo thành công
                //MyMessageBox.Show($"Duy chuyển {mess} thành công!", MessageBoxType.Success);
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
