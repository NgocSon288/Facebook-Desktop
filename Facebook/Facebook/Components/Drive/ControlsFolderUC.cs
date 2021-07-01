using Facebook.Common;
using Facebook.Components.Drive.Folders.ChangeColor;
using Facebook.Components.Drive.Folders.Rename;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.ControlCustom.WrapperForm;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using FontAwesome.Sharp;
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

namespace Facebook.Components.Drive
{
    public partial class ControlsFolderUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void Paste();
        public delegate void RenameFolder(string name);
        public delegate void DeleteFolder();
        public event ClickSpace OnClickSpace;
        public event Paste OnPaste;
        public event RenameFolder OnRenameFolder;
        public event DeleteFolder OnDeleteFolder;

        private readonly IFolderDAO _folderDAO;
        private readonly IUserDAO _userDAO;

        private ControlsItemUC pasteCon;

        public ControlsFolderUC(IFolderDAO folderDAO, IUserDAO userDAO)
        {
            InitializeComponent();

            this._folderDAO = folderDAO;
            this._userDAO = userDAO;

            Load();
        }

        private Label lblOwnName;

        #region Methods

        new private void Load()
        {
            LoadControls();

            pnlOwn.Controls.Add(GetSeparator());
            lblOwnName = new Label()
            {
                Text = "11111",
                ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR,
                BackColor = Constants.MAIN_BACK_COLOR,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(0, 0, 0, 0),
                Font = new Font("Consolas", 14)
            };
            lblOwnName.Top = pnlOwn.Height / 2 - lblOwnName.Height / 2 - 7;
            lblOwnName.Left = pnlOwn.Width / 2 - lblOwnName.Width / 2;

            pnlOwn.Controls.Add(lblOwnName);


            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        public void LoadOwn()
        {
            lblOwnName.Text = _userDAO.GetByID(DriveFolderItemUC.CurrentFolderItemUCFocus.folder.UserID).Name;
            lblOwnName.Left = pnlOwn.Width / 2 - lblOwnName.Width / 2;
        }

        private void LoadControls()
        {
            // Get link folder
            var getLinkCon = new ControlsItemUC(IconChar.Link, "Lấy link chia sẻ");
            getLinkCon.OnClickControl += () =>
            {

            };

            // Share folder 
            var shareCon = new ControlsItemUC(IconChar.ShareAltSquare, "Chia sẻ thư mục cho bạn bè");
            shareCon.OnClickControl += () =>
            {
                if (Constants.IsShareRoot)
                {
                    MyMessageBox.Show("Bạn không có quyền share thư mục này!", MessageBoxType.Warning);

                    return;
                }

                try
                {
                    var fUserShare = new Folders.Share.fUserShare();
                    var fparent = new fParentClickHidden(fUserShare);

                    fparent.ShowDialog();
                }
                catch (Exception)
                {

                }
            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Cut folder => xong
            var moveCon = new ControlsItemUC(IconChar.PaperPlane, "Di chuyển  thư mục");
            moveCon.OnClickControl += () =>
            {
                if (Constants.IsShareRoot)
                {
                    MyMessageBox.Show("Bạn không có quyền di chuyển thư mục này!", MessageBoxType.Warning);

                    return;
                }

                var itemUC1 = Constants.CurrentCut as DriveFolderItemUC;
                var itemUC2 = Constants.CurrentCut as DriveFileItemUC;

                // đổi màu folder, file trước đó
                itemUC1?.UnCut();
                itemUC2?.UnCut();

                // kiểm tra nếu trùng folder thì cập nhật null và ngừng
                if (Constants.CurrentCut == DriveFolderItemUC.CurrentFolderItemUCFocus)
                {
                    Constants.Clipboard = null;
                    Constants.CurrentCut = null;
                    DriveFolderItemUC.CurrentFolderItemUCFocus.SetColorAfterUnCut();

                    CheckClipboard();
                    return;
                }

                // đưa vào clip board
                Constants.Clipboard = new Common.Clipboard()
                {
                    FileName = null,
                    Folder = DriveFolderItemUC.CurrentFolderItemUCFocus.folder,
                    IsFolder = true,
                    ParentFolder = DriveLinkUC.CurrentFolder
                };

                Constants.CurrentCut = DriveFolderItemUC.CurrentFolderItemUCFocus;

                // đổi màu folder cut
                DriveFolderItemUC.CurrentFolderItemUCFocus.Cut();
                CheckClipboard();
            };

            // Paste folder = > xong
            pasteCon = new ControlsItemUC(IconChar.Paste, "Paste");
            pasteCon.OnClickControl += () =>
            {
                // Folder đang được focus, là folder sẽ paste clipboard vào
                var focusF = DriveFolderItemUC.CurrentFolderItemUCFocus.folder;

                var isOk = true;

                if (Constants.Clipboard.IsFolder)
                {
                    //Kiểm tra paste folder vào folder
                    // kiểm tra nếu folder đang copy == focusF
                    var err1 = focusF == Constants.Clipboard.Folder;

                    // kiểm tra nếu focusF là cha của folder copy
                    var err2 = focusF.ID == Constants.Clipboard.ParentFolder.ID;

                    // kiểm tra folder focus có phải là folder con cháu của folder copy
                    var err3 = false;
                    var tempF = focusF;

                    while (tempF.ParentID != null)
                    {
                        if (tempF.ParentID == Constants.Clipboard.Folder.ID)
                        {
                            err3 = true;
                            break;
                        }

                        tempF = _folderDAO.GetByID(tempF.ParentID.Value);
                    }

                    if (err1 || err2 || err3)
                    {
                        isOk = false;
                    }
                }
                else
                {
                    // Kiểm tra paste file vào folder
                    // kiểm tra nếu focusF là cha của file copy
                    var err = focusF.ID == Constants.Clipboard.ParentFolder.ID;

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
                    var focusFolder = DriveFolderItemUC.CurrentFolderItemUCFocus.folder;    // folder cha lúc sau

                    if (Constants.Clipboard.IsFolder)
                    {
                        // trường hợp folder
                        // Cập nhật lại parentID của folder được cut
                        cutFolder.ParentID = focusFolder.ID;

                        // cập nhật childID của folder parent lúc đầu   -
                        var idList1 = StringHelper.StringToIntList(parentFolder.ChildrenID);
                        idList1.Remove(cutFolder.ID);
                        parentFolder.ChildrenID = StringHelper.IntListToString(idList1);


                        // kiểm tra name folder được cut có trùng tên folder con của folder focus
                        var newName = cutFolder.Name;
                        var childList = _folderDAO.GetByListID(StringHelper.StringToIntList(focusFolder.ChildrenID));
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

                        // cập nhật childID của folder được focus       +
                        var idList2 = StringHelper.StringToIntList(focusFolder.ChildrenID);
                        idList2.Add(cutFolder.ID);
                        focusFolder.ChildrenID = StringHelper.IntListToString(idList2);

                        _folderDAO.SaveChanges();
                    }
                    else
                    {
                        // trường hợp là file
                        // cập nhật file của folder parent lúc đầu   -
                        var fileList1 = StringHelper.StringToStringList(parentFolder.Files);
                        fileList1.Remove(cutFile);
                        parentFolder.Files = StringHelper.StringListToString(fileList1);


                        // kiểm tra name file được cut có trùng tên file con của folder focus
                        var rand = cutFile.Substring(0, 9);
                        var name = cutFile.Substring(9, cutFile.LastIndexOf(".") - 9);
                        var ext = cutFile.Substring(cutFile.LastIndexOf("."));
                        var newName = name;
                        var fileList = StringHelper.StringToStringList(focusFolder.Files);
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
                        focusFolder.Files = StringHelper.StringListToString(fileList);

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
                DriveFolderItemUC.CurrentFolderItemUCFocus.SetColorAfterUnCut();
                CheckClipboard();


                // Luôn luôn thông báo thành công
                //MyMessageBox.Show($"Duy chuyển {mess} thành công!", MessageBoxType.Success);

            };

            // Download folder => xong
            var downloadCon = new ControlsItemUC(IconChar.Download, "Tải thư mục");
            downloadCon.OnClickControl += () =>
            {
                var dialog = new FolderBrowserDialog();
                dialog.Description = "Chọn một nơi để lưu trữ";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Folder folderSelected = DriveFolderItemUC.CurrentFolderItemUCFocus.folder;
                    string pathSelected = dialog.SelectedPath;  // Path cha
                    string name = folderSelected.Name;   // folder name
                    string path = $"{pathSelected}\\{name}";

                    if (Directory.Exists(path))
                    {
                        var i = 1;
                        // nếu đã tồn tại folder đó thì đổi tên folder đó
                        while (Directory.Exists(path))
                        {
                            path = $"{pathSelected}\\{name} ({i++})";
                        }
                    }

                    // Tạo folder cha bên trong folder được chọn
                    Directory.CreateDirectory(path);

                    // Lấy ra các files, folders
                    List<Folder> folders = _folderDAO.GetByListID(StringHelper.StringToIntList(folderSelected.ChildrenID));
                    List<string> files = StringHelper.StringToStringList(folderSelected.Files);

                    CopyFilesAndCreateNewFolder(path, folders, files);

                    MyMessageBox.Show("Lưu thư mục thành công", MessageBoxType.Success);
                }
            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Rename  folder   => xong
            var renameCon = new ControlsItemUC(IconChar.Edit, "Đổi tên thư mục");
            renameCon.OnClickControl += () =>
            {
                if (Constants.IsShareRoot)
                {
                    MyMessageBox.Show("Bạn không có quyền đổi tên thư mục này!", MessageBoxType.Warning);

                    return;
                }

                var fnewFolder = new fRenameFolder(AutofacFactory<IFolderDAO>.Get());
                var fparent = new fParentClickHidden(fnewFolder);
                var fName = "";

                // Close và không sửa tên  thư mục
                fnewFolder.OnClickClose += () =>
                        {
                            fName = "";
                            fparent.FParentClickHidden_Click(null, null);
                        };

                fnewFolder.OnClickUpdate += (folderName) =>
                        {
                            fName = folderName;
                            fparent.FParentClickHidden_Click(null, null);
                        };

                fparent.FormClosed += (s, o) =>
            {
                if (!string.IsNullOrEmpty(fName.Trim()))
                {
                    OnRenameFolder?.Invoke(fName);
                }
            };

                // Close và thực hiện sửa tên

                fparent.ShowDialog();
            };

            // Color folder     =>  xong
            var colorCon = new ControlsItemUC(IconChar.Palette, "Thay đổi màu sắc");
            colorCon.OnClickControl += () =>
            {
                try
                {
                    var nameColor = ""; // cần get name color từ folder focus
                    var themUC = new fFolderColor(nameColor);
                    var fparent = new fParentClickHidden(themUC);
                    var ischange = false;


                    themUC.OnUpdateThemeColor += (name) =>
                    {
                        ischange = true;
                        nameColor = name;

                        fparent.FParentClickHidden_Click(null, null);
                    };

                    themUC.OnResetColor += () =>
                    {

                        ischange = true;
                        nameColor = "";

                        fparent.FParentClickHidden_Click(null, null);
                    };

                    fparent.FormClosed += (s, o) =>
                    {
                        // thực hiện cập nhật khi được cập nhật
                        if (ischange)
                        {
                            // cập nhật màu folder focus
                            DriveFolderItemUC.CurrentFolderItemUCFocus.ChangedColorName(nameColor);

                            // cập nhật db
                            DriveFolderItemUC.CurrentFolderItemUCFocus.folder.ColorName = nameColor;
                            _folderDAO.SaveChanges();
                        }
                    };

                    fparent.ShowDialog();
                }
                catch (Exception)
                {

                }
            };

            // Delete folder    => xong
            var deleteCon = new ControlsItemUC(IconChar.Times, "Xóa thư mục");
            deleteCon.OnClickControl += () =>
            {
                if (Constants.IsShareRoot && DriveFolderItemUC.CurrentFolderItemUCFocus.folder.UserID != Constants.UserSession.ID)
                {
                    MyMessageBox.Show("Bạn không có quyền xóa thư mục này!", MessageBoxType.Warning);

                    return;
                }

                if (MyMessageBox.Show($"Bạn có muốn xóa folder {DriveFolderItemUC.CurrentFolderItemUCFocus.folder.Name}?", MessageBoxType.Question).Value == DialogResult.OK)
                {
                    // duyệt đệ quy,danh sách tất cả các node cần xóa
                    List<Folder> foldersDelete = new List<Folder>();

                    // Duyệt đệ quy, danh sách các file cần xóa
                    List<string> filesDelete = new List<string>();

                    var rootFolder = DriveFolderItemUC.CurrentFolderItemUCFocus.folder; //folder root cần xóa, folder được focus

                    GetFilesFolderDelete(rootFolder, foldersDelete, filesDelete);

                    // Xóa childID ra khỏi global
                    var childIDs = StringHelper.StringToIntList(DriveLinkUC.CurrentFolder.ChildrenID);
                    childIDs.Remove(rootFolder.ID);

                    DriveLinkUC.CurrentFolder.ChildrenID = StringHelper.IntListToString(childIDs);

                    _folderDAO.SaveChanges();

                    // xóa các folder, files
                    _folderDAO.DeleteRange(foldersDelete);

                    foreach (var item in filesDelete)
                    {
                        File.Delete($"./../../Assets/Files/Drive/{item}");
                    }

                    // Kiểm  tra nếu file trong clipboard trùng tên file xóa thì xóa luôn clipboard
                    if (Constants.Clipboard != null && Constants.Clipboard.IsFolder && Constants.Clipboard.Folder.ID == DriveFolderItemUC.CurrentFolderItemUCFocus.folder.ID)
                    {
                        // cho FileFocus vào global

                        Constants.CurrentCut = null;
                        Constants.Clipboard = null;
                    }

                    // Xóa focus file trong ram
                    DriveFolderItemUC.CurrentFolderItemUCFocus = null;

                    // Thông báo cập nhật UI
                    OnDeleteFolder?.Invoke();

                    MyMessageBox.Show("Xóa thành công!", MessageBoxType.Success);
                }
            };


            flpControls.Controls.AddRange(new Control[] { getLinkCon, shareCon, GetSeparator(), moveCon, pasteCon, downloadCon, GetSeparator(), renameCon, colorCon, deleteCon });

            CheckClipboard();
        }

        private void GetFilesFolderDelete(Folder root, List<Folder> fdsDelete, List<string> fisDelete)
        {
            fdsDelete.Add(root);
            fisDelete.AddRange(StringHelper.StringToStringList(root.Files));

            foreach (var item in _folderDAO.GetByListID(StringHelper.StringToIntList(root.ChildrenID)))
            {
                GetFilesFolderDelete(item, fdsDelete, fisDelete);
            }

        }

        /// <summary>
        /// Tạo các files và folders
        /// </summary>
        /// <param name="folders"></param>
        /// <param name="files"></param>
        private void CopyFilesAndCreateNewFolder(string folderPath, List<Folder> folders, List<string> files)
        {
            // save  các file vào folderPath + fileName
            foreach (var item in files)
            {
                var oldPath = $"./../../Assets/Files/Drive/{item}";
                var newPath = $"{folderPath}\\{item.Substring(9)}";
                File.Copy(oldPath, newPath);
            }

            foreach (var item in folders)
            {
                var childFolder = $"{folderPath}\\{item.Name}";
                Directory.CreateDirectory(childFolder);

                // Lấy ra các files, folders
                List<Folder> fds = _folderDAO.GetByListID(StringHelper.StringToIntList(item.ChildrenID));
                List<string> fis = StringHelper.StringToStringList(item.Files);

                CopyFilesAndCreateNewFolder(childFolder, fds, fis);
            }
        }

        public void CheckClipboard()
        {
            pasteCon.Visible = Constants.Clipboard != null;
        }

        private Panel GetSeparator()
        {
            return new Panel()
            {
                Width = 2,
                Height = flpControls.Height,
                BackColor = Constants.BORDER_BOX_COLOR
            };
        }

        #endregion

        #region Events

        private void flpControls_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        #endregion
    }
}
