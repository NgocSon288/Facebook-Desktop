using Facebook.Common;
using Facebook.Components.Drive;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.FormUC
{
    public partial class fDrive : UserControl
    {
        private readonly IFolderDAO _folderDAO;

        //  Controls
        private ControlsGlobalUC globalUC;

        private ControlsFolderUC folderUC;
        private ControlsFileUC fileUC;

        private DriveLinkUC driveLinkUC;
        private DriveContentUC driveContentUC;

        private Folder root;

        private Dictionary<string, string> filesCopy;   // oldPath, newPath

        // Load file
        private BackgroundWorker worker = new BackgroundWorker();

        private Random rand = new Random();
        private bool isError = false;

        private Label lbl;

        public fDrive(IFolderDAO folderDAO)
        {
            InitializeComponent();

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            this._folderDAO = folderDAO;

            root = _folderDAO.GetRootByUserID(Constants.UserSession.ID);

            SetUpUI();
            Load();
        }

        private enum CONTROL
        {
            GLOBAL,
            FOLDER,
            FILE
        }

        #region Methods

        new private void Load()
        {
            LoadGlobalControls();
            LoadFolderControls();
            LoadFileControls();

            LoadHead();
            LoadContent();
            LoadControls(CONTROL.GLOBAL);
        }

        private void LoadHead()
        {
            pnlHead.Controls.Clear();
            // Cần có node root
            driveLinkUC = new DriveLinkUC(new List<Folder>() { root });
            driveLinkUC.OnClickLinkItem += () => LoadContent();
            driveLinkUC.OnClickSpace += () =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                LoadControls(CONTROL.GLOBAL);
            };

            pnlHead.Controls.Add(driveLinkUC);

            // Load separator
            pnlSeparator1.Height = pnlSeparator2.Height = pnlSeparator3.Height = 2;
            var pnl = new Panel()
            {
                Width = pnlSeparator1.Height,
                Height = pnlHead.Height,
                Margin = new Padding(0, 0, 0, 0),
                Left = driveLinkUC.Width + 30,
                Top = 0,
                BackColor = Constants.BORDER_BOX_COLOR
            };

            pnlHead.Controls.Add(pnl);

            // Load lbl share with me
            if (lbl == null)
            {
                lbl = new Label()
                {
                    Text = "Share with me",
                    Font = new Font("Consolas", 14),
                    ForeColor = Constants.MAIN_FORE_COLOR,
                    BackColor = Constants.MAIN_BACK_COLOR,
                    AutoSize = true,
                    Cursor = Cursors.Hand
                };

                lbl.Top = pnlHead.Height / 2 - lbl.Height / 2 - 7;
                lbl.Left = (pnlHead.Right - pnl.Right) / 2 - lbl.Width / 2 + pnl.Right - 98;

                lbl.Click += (o, s) =>
                {
                    lbl.Text = "";
                    Constants.IsShareRoot = !Constants.IsShareRoot;

                    if (Constants.IsShareRoot)
                    {
                        lbl.Text = "My Drive";
                        root = _folderDAO.GetRootByUserID(Constants.UserSession.ID, true);
                    }
                    else
                    {
                        lbl.Text = "Share with me";
                        root = _folderDAO.GetRootByUserID(Constants.UserSession.ID);
                    }

                    lbl.Left = (pnlHead.Right - pnl.Right) / 2 - lbl.Width / 2 + pnl.Right;

                    Load();
                };
            }
            pnlHead.Controls.Add(lbl);

            // Load get code (get code để lấy folder share)
        }

        /// <summary>
        /// Thay đổi Controls khi click vào vị trí nào đó hoặc load
        /// </summary>
        /// <param name="con"></param>
        private void LoadControls(CONTROL con)
        {
            globalUC.CheckClipboard();
            folderUC.CheckClipboard();

            switch (con)
            {
                case CONTROL.GLOBAL:
                    globalUC.Visible = true;
                    folderUC.Visible = false;
                    fileUC.Visible = false;

                    globalUC.LoadOwn();
                    break;

                case CONTROL.FOLDER:
                    globalUC.Visible = false;
                    folderUC.Visible = true;
                    fileUC.Visible = false;

                    folderUC.LoadOwn();
                    break;

                case CONTROL.FILE:
                    globalUC.Visible = false;
                    folderUC.Visible = false;
                    fileUC.Visible = true;

                    fileUC.LoadOwn();
                    break;
            }
        }

        private void LoadContent()
        {
            pnlContent.Controls.Clear();

            driveContentUC = new DriveContentUC();
            driveContentUC.Top = 0;
            driveContentUC.Left = 2;
            driveContentUC.OnTwoClickFolder += (focusFolder) =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                // Add link
                driveLinkUC.AddFolder(focusFolder);

                // Update content
                LoadContent();
            };
            driveContentUC.OnOneClickFolder += (focusFolder) =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();

                // Khi click vào folder,  hiện các controls folder
                LoadControls(CONTROL.FOLDER);
            };
            driveContentUC.OnOneClickFile += (filFocuse) =>
            {
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                // Khi click vào file,  hiện các controls file
                LoadControls(CONTROL.FILE);
            };
            driveContentUC.OnClickSpace += () =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                LoadControls(CONTROL.GLOBAL);
            };

            pnlContent.Controls.Add(driveContentUC);
            LoadControls(CONTROL.GLOBAL);
        }

        private async Task CopyFile(string source, string des)
        {
            Task task = new Task(() =>
            {
                try
                {
                    FileStream fsOut = new FileStream(des, FileMode.Create);
                    FileStream fsIn = new FileStream(source, FileMode.Open, FileAccess.ReadWrite);
                    byte[] bt = new byte[1048756];
                    int readByte;

                    while ((readByte = fsIn.Read(bt, 0, bt.Length)) > 0)
                    {
                        fsOut.Write(bt, 0, readByte);
                        //worker.ReportProgress((int)(fsIn.Position * 100 / fsIn.Length));
                    }

                    fsIn.Close();
                    fsOut.Close();
                }
                catch (Exception error)
                {
                    isError = true;
                }
            });

            task.Start();

            await task;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            //label1.Text = progressBar1.Value.ToString() + "%";
        }

        private async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // [Key, value] == [oldPath, newPath]
            foreach (var item in filesCopy)
            {
                try
                {
                    await CopyFile(item.Key, $@"..\..\Assets\Files\Drive\{item.Value}");
                }
                catch (Exception error)
                {
                    isError = true;
                }
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Cập nhật lại giao diện
            pnlContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrapContent.BackColor = Constants.MAIN_BACK_COLOR;
            driveContentUC.DragLeave();

            // Thực hiện cập nhật UI
            driveContentUC.CreateOrUpdate();

            if (!isError)
            {
                MyMessageBox.Show("Upload thành công!", MessageBoxType.Success);
            }
            else
            {
                MyMessageBox.Show("Có lỗi trong quá trình Upload, vui lòng kiểm tra lại file Upload!", MessageBoxType.Warning);
            }
        }

        /// <summary>
        /// Thực hiện dệ quy  để tìm tạo ra các Folder, và tìm ra các file copy
        /// </summary>
        /// <param name="parentF"></param>
        /// <param name="folders"></param>
        private void CreateFileFolder(Folder parentF, List<string> folders)
        {
            var fds = _folderDAO.GetByListID(StringHelper.StringToIntList(parentF.ChildrenID));
            var fdsName = fds.Select(f => f.Name).ToList();

            foreach (var item in folders)
            {
                // tìm ra các files trong folder đó để add file con vào
                string[] fileEntries = Directory.GetFiles(item);
                var folderName = item.Substring(item.LastIndexOf("\\") + 1);
                var fd = fds.FirstOrDefault(f => string.Equals(f.Name, folderName, StringComparison.OrdinalIgnoreCase));

                // Nếu thư mục chưa tồn tại
                if (fd == null)
                {
                    // tạo ra Folder và add folderID vào parent
                    fd = new Folder()
                    {
                        Name = folderName,
                        ChildrenID = "",
                        Files = "",
                        ParentID = parentF.ID,
                        IsPublic = false,
                        ShareList = "",
                        UserID = Constants.UserSession.ID
                    };

                    // save lại,
                    _folderDAO.Create(fd);

                    // add id vừa tạo vào parent
                    parentF.ChildrenID = string.IsNullOrEmpty(parentF.ChildrenID) ? fd.ID.ToString() : parentF.ChildrenID + Constants.SEPERATE_CHAR + fd.ID;
                }
                else
                {
                }

                // Thêm các file vào folder con, và copyList
                // Do thêm file vào thư mục có thể trùng nên cần kiểm tra
                fd.Files = StringHelper.StringListToString(GetFilesNameAndAddFileToCopyList(fd, fileEntries.ToList()));

                // tìm ra các folders trong folder đó để gọi lại hàm này
                string[] subdirectoryEntries = Directory.GetDirectories(item);
                CreateFileFolder(fd, subdirectoryEntries.ToList());
            }
        }

        private List<string> GetFilesNameAndAddFileToCopyList(Folder folder, List<string> files)
        {
            List<string> fa = StringHelper.StringToStringList(folder.Files); // danh sach các file đã có
            List<string> faWithoutRandom = fa.Select(f => f.Substring(9)).ToList();

            // kiểm tra các file được truyền đã tồn tại trong fa chưa, nếu chưa thì add, có rồi thì thêm hậu tố
            foreach (var item in files)
            {
                var fileName = Path.GetFileName(item);
                var textRand = rand.Next(111111111, 999999999).ToString();

                if (faWithoutRandom.Contains(fileName))
                {
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(item);
                    var ext = Path.GetExtension(item);
                    var i = 1;
                    var newPath = $"{fileNameWithoutExt} ({i}){ext}";

                    while (faWithoutRandom.Contains(newPath))
                    {
                        i++;
                        newPath = $"{fileNameWithoutExt} ({i}){ext}";
                    }

                    fa.Add(textRand + newPath);
                    filesCopy.Add(item, textRand + newPath);
                }
                else
                {
                    fa.Add(textRand + fileName);
                    filesCopy.Add(item, textRand + fileName);
                }
            }

            return fa;
        }

        /// <summary>
        /// Kiểm tra nếu là parent share root thì không cho
        /// </summary>
        /// <returns></returns>
        private bool IsDragOk()
        {
            var f = DriveLinkUC.CurrentFolder;
            return f.ParentID != null || !f.IsShareRoot;
        }

        #endregion 

        #region Controls Global

        private void LoadGlobalControls()
        {
            var check = false;
            foreach (var item in pnlControls.Controls)
            {
                if (item is ControlsGlobalUC)
                {
                    check = true;
                }
            }

            if (check)
                return;

            globalUC = new ControlsGlobalUC(AutofacFactory<IFolderDAO>.Get(), AutofacFactory<IUserDAO>.Get()) { Location = new Point(0, 0), Visible = false };
            globalUC.OnClickSpace += GlobalUC_OnClickSpace;
            globalUC.OnCreateNewFolder += GlobalUC_OnCreateNewFolder;
            globalUC.OnUploadFolder += GlobalUC_OnUploadFolder;
            globalUC.OnUploadFile += GlobalUC_OnUploadFile;
            globalUC.OnPaste += GlobalUC_OnPaste;

            pnlControls.Controls.Add(globalUC);
        }

        /// <summary>
        /// Paste folder hoặc file vào global
        /// </summary>
        private void GlobalUC_OnPaste()
        {
            driveContentUC.CreateOrUpdate();
        }

        /// <summary>
        /// Click vào space
        /// </summary>
        private void GlobalUC_OnClickSpace()
        {
            DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
            DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

            LoadControls(CONTROL.GLOBAL);
        }

        /// <summary>
        /// Upload files
        /// </summary>
        /// <param name="filesPath"></param>
        private void GlobalUC_OnUploadFile(List<string> filesPath)
        {
            filesCopy = new Dictionary<string, string>();

            DriveLinkUC.CurrentFolder.Files = StringHelper.StringListToString(GetFilesNameAndAddFileToCopyList(DriveLinkUC.CurrentFolder, filesPath));

            // duyệt qua các folder
            CreateFileFolder(DriveLinkUC.CurrentFolder, new List<string>());

            _folderDAO.SaveChanges();

            // Thực hiện save với các  file trong fileCopy
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Upload folders
        /// </summary>
        /// <param name="foldersPath"></param>
        private void GlobalUC_OnUploadFolder(List<string> foldersPath)
        {
            filesCopy = new Dictionary<string, string>();

            // duyệt qua các folder
            CreateFileFolder(DriveLinkUC.CurrentFolder, foldersPath);

            _folderDAO.SaveChanges();

            // Thực hiện save với các  file trong fileCopy
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Thêm mới folder vào thư mục hiện tại
        /// </summary>
        /// <param name="folderName"></param>
        private void GlobalUC_OnCreateNewFolder(string folderName)
        {
            var parentF = DriveLinkUC.CurrentFolder;
            // tạo thư mục mới có tên truyền vào
            var newF = new Folder()
            {
                Name = folderName,
                ChildrenID = "",
                Files = "",
                IsPublic = false,
                ParentID = parentF.ID,
                ShareList = "",
                UserID = Constants.UserSession.ID
            };

            _folderDAO.Create(newF);

            // thêm id vào ChildID của thư mục hiện hành
            parentF.ChildrenID += Constants.SEPERATE_CHAR + newF.ID;

            // cập nhật UI
            driveContentUC.CreateOrUpdate();
        }


        #endregion

        #region Controls Folder

        private void LoadFolderControls()
        {
            var check = false;
            foreach (var item in pnlControls.Controls)
            {
                if (item is ControlsFolderUC)
                {
                    check = true;
                }
            }

            if (check)
                return;

            folderUC = new ControlsFolderUC(AutofacFactory<IFolderDAO>.Get(), AutofacFactory<IUserDAO>.Get()) { Location = new Point(0, 0), Visible = false };
            folderUC.OnClickSpace += FolderUC_OnClickSpace;
            folderUC.OnPaste += FolderUC_OnPaste;
            folderUC.OnRenameFolder += FolderUC_OnRenameFolder;
            folderUC.OnDeleteFolder += FolderUC_OnDeleteFolder;

            pnlControls.Controls.Add(folderUC);
        }

        private void FolderUC_OnDeleteFolder()
        {
            // cập nhật ui
            driveContentUC.CreateOrUpdate();

            // Load controls
            LoadControls(CONTROL.GLOBAL);
        }

        /// <summary>
        /// Đổi tên folder
        /// </summary>
        /// <param name="name"></param>
        private void FolderUC_OnRenameFolder(string name)
        {
            DriveFolderItemUC.CurrentFolderItemUCFocus.folder.Name = name;
            _folderDAO.SaveChanges();

            DriveFolderItemUC.CurrentFolderItemUCFocus.Rename(name);
        }

        /// <summary>
        /// Paste folde file vào folder
        /// </summary>
        private void FolderUC_OnPaste()
        {
            driveContentUC.PasteFileOrFolder();
        }

        /// <summary>
        /// Click vào  space
        /// </summary>
        private void FolderUC_OnClickSpace()
        {
            DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
            DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

            LoadControls(CONTROL.GLOBAL);
        }

        #endregion

        #region Controls File

        private void LoadFileControls()
        {
            var check = false;
            foreach (var item in pnlControls.Controls)
            {
                if (item is ControlsFileUC)
                {
                    check = true;
                }
            }

            if (check)
                return;

            fileUC = new ControlsFileUC(AutofacFactory<IUserDAO>.Get()) { Location = new Point(0, 0), Visible = false };
            fileUC.OnClickSpace += () =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                LoadControls(CONTROL.GLOBAL);
            };
            fileUC.OnUpdateFileName += FileUC_OnUpdateFileName;
            fileUC.OnDeleteFile += FileUC_OnDeleteFile;
            fileUC.OnChangeColorExtension += FileUC_OnChangeColorExtension;

            pnlControls.Controls.Add(fileUC);
        }

        /// <summary>
        /// Đổi màu đại trà file
        /// </summary>
        private void FileUC_OnChangeColorExtension()
        {
            driveContentUC.ChangeColorExtension();
        }

        private void FileUC_OnDeleteFile()
        {
            // vì trong kia chưa save
            _folderDAO.SaveChanges();

            // cập nhật ui
            driveContentUC.CreateOrUpdate();

            // Load controls
            LoadControls(CONTROL.GLOBAL);
        }

        /// <summary>
        /// Đổi tên file
        /// </summary>
        /// <param name="fileName"></param>
        private void FileUC_OnUpdateFileName(string fileName)
        {
            var oldName = DriveFileItemUC.CurrentFileItemUCFocus.fileName;
            var rand = oldName.Substring(0, 9);
            var ext = oldName.Substring(oldName.IndexOf("."));
            fileName = rand + fileName + ext;

            DriveFileItemUC.CurrentFileItemUCFocus.fileName = fileName;
            DriveFileItemUC.CurrentFileItemUCFocus.RenameFile();

            // thay đổi tên file trong folder global
            var fileNames = StringHelper.StringToStringList(DriveLinkUC.CurrentFolder.Files);

            fileNames.Remove(oldName);
            fileNames.Add(fileName);

            DriveLinkUC.CurrentFolder.Files = StringHelper.StringListToString(fileNames);

            _folderDAO.SaveChanges();

            File.Move($"./../../Assets/Files/Drive/{oldName}", $"./../../Assets/Files/Drive/{fileName}");
        }

        #endregion

        #region SetUpUI

        private void SetUpUI()
        {
            var mar = 5;
            pnlContent.Width = pnlWrapContent.Width - 2 * mar;
            pnlContent.Height = pnlWrapContent.Height - 2 * mar;
            pnlContent.Location = new Point(mar, mar);

            pnlSeparator1.BackColor = pnlSeparator2.BackColor = pnlSeparator3.BackColor = Constants.BORDER_BOX_COLOR;
            pnlHead.BackColor = Constants.MAIN_BACK_COLOR;

            // Set background color for form
            this.BackColor = Constants.MAIN_BACK_COLOR;

            // Set color for button control window
            btnMinimize.BackColor = Constants.MAIN_BACK_COLOR;
            btnMinimize.ForeColor = Constants.MAIN_FORE_COLOR;
            btnMinimize.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
            btnClose.BackColor = Constants.MAIN_BACK_COLOR;
            btnClose.ForeColor = Constants.MAIN_FORE_COLOR;
            btnClose.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            if (MyMessageBox.Show("Bạn có muốn thoát?", MessageBoxType.Question).Value == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            Constants.MainForm.WindowState = FormWindowState.Minimized;
        }

        #endregion SetUpUI

        #region Draf file, folder,  Events

        private void pnlContent_DragDrop(object sender, DragEventArgs e)
        {
            if (!IsDragOk())
            {
                driveContentUC.DragLeave();
                pnlContent.BackColor = Constants.MAIN_BACK_COLOR;
                pnlWrapContent.BackColor = Constants.MAIN_BACK_COLOR;

                MyMessageBox.Show("Bạn không thể Upload file hoặc thư mục vào thư mục này!", MessageBoxType.Warning);

                return;
            }

            isError = false;
            filesCopy = new Dictionary<string, string>();
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            List<string> files = new List<string>();    // chứa danh sách các file của folder, CurrentFolder là cha
            List<string> folders = new List<string>();  // chứa danh sách các folder con của CurrentFolder

            foreach (var file in droppedFiles)
            {
                if (File.Exists(file))
                {
                    files.Add(file);
                }
                else
                {
                    folders.Add(file);
                }
            }

            // Thêm các file đó vào CurrentFolder: get ra các file name để add vào parent
            // Cần kiểm tra file đó đã tồn tại chưa
            DriveLinkUC.CurrentFolder.Files = StringHelper.StringListToString(GetFilesNameAndAddFileToCopyList(DriveLinkUC.CurrentFolder, files));

            // duyệt qua các folder
            CreateFileFolder(DriveLinkUC.CurrentFolder, folders);

            _folderDAO.SaveChanges();

            // Thực hiện save với các  file trong fileCopy
            worker.RunWorkerAsync();
        }

        private void pnlContent_DragEnter(object sender, DragEventArgs e)
        {

            driveContentUC.DragEnter();
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void pnlContent_DragLeave(object sender, EventArgs e)
        {
            driveContentUC.DragLeave();
            pnlContent.BackColor = Constants.MAIN_BACK_COLOR;
            pnlWrapContent.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void pnlContent_DragOver(object sender, DragEventArgs e)
        {
            driveContentUC.DragEnter();
            pnlContent.BackColor = Constants.FOLDER_BACKGROUND_DRAG_ENTER_COLOR;
            pnlWrapContent.BackColor = Constants.MAIN_FORE_LINK2_COLOR;
        }

        private void pnlHead_Click(object sender, EventArgs e)
        {
            LoadControls(CONTROL.GLOBAL);
        }

        private void fDrive_Click(object sender, EventArgs e)
        {
            LoadControls(CONTROL.GLOBAL);
        }

        #endregion Draf file, folder,  Events
    }
}