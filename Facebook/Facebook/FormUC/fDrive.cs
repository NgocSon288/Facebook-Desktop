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

        public fDrive(IFolderDAO folderDAO)
        {
            InitializeComponent();

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            this._folderDAO = folderDAO;

            root = _folderDAO.GetByUserID(Constants.UserSession.ID);

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
                    break;

                case CONTROL.FOLDER:
                    globalUC.Visible = false;
                    folderUC.Visible = true;
                    fileUC.Visible = false;
                    break;

                case CONTROL.FILE:
                    globalUC.Visible = false;
                    folderUC.Visible = false;
                    fileUC.Visible = true;
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
                        UserID = parentF.UserID
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

        #endregion Methods

        #region Controls Global

        private void LoadGlobalControls()
        {
            globalUC = new ControlsGlobalUC(AutofacFactory<IFolderDAO>.Get()) { Location = new Point(0, 0), Visible = false };
            globalUC.OnClickSpace += () =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                LoadControls(CONTROL.GLOBAL);
            };
            globalUC.OnCreateNewFolder += GlobalUC_OnCreateNewFolder;
            globalUC.OnUploadFolder += GlobalUC_OnUploadFolder;
            globalUC.OnUploadFile += GlobalUC_OnUploadFile;

            pnlControls.Controls.Add(globalUC);
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
                UserID = parentF.UserID
            };

            _folderDAO.Create(newF);

            // thêm id vào ChildID của thư mục hiện hành
            parentF.ChildrenID += Constants.SEPERATE_CHAR + newF.ID;

            // cập nhật UI
            driveContentUC.CreateOrUpdate();
        }



        #endregion Controls Global

        #region Controls Folder

        private void LoadFolderControls()
        {
            folderUC = new ControlsFolderUC() { Location = new Point(0, 0), Visible = false };
            folderUC.OnClickSpace += () =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                LoadControls(CONTROL.GLOBAL);
            };
            pnlControls.Controls.Add(folderUC);
        }

        #endregion Controls Folder

        #region Controls File

        private void LoadFileControls()
        {
            fileUC = new ControlsFileUC() { Location = new Point(0, 0), Visible = false };
            fileUC.OnClickSpace += () =>
            {
                DriveFileItemUC.CurrentFileItemUCFocus?.ResetColor();
                DriveFolderItemUC.CurrentFolderItemUCFocus?.ResetColor();

                LoadControls(CONTROL.GLOBAL);
            };

            pnlControls.Controls.Add(fileUC);
        }

        #endregion Controls File

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