using Facebook.Common;
using Facebook.Components.Drive.Files.ChangeColor;
using Facebook.Components.Drive.Files.Rename;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.ControlCustom.WrapperForm;
using Facebook.DAO;
using Facebook.Helper;
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
    public partial class ControlsFileUC : UserControl
    {
        public delegate void ClickSpace();
        public delegate void UpdateFileName(string fileName);
        public delegate void DeleteFile();
        public delegate void ChangeColorExtension();
        public event ClickSpace OnClickSpace;
        public event UpdateFileName OnUpdateFileName;
        public event DeleteFile OnDeleteFile;
        public event ChangeColorExtension OnChangeColorExtension;

        public ControlsFileUC()
        {
            InitializeComponent();

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
            // Get link file
            var getLinkCon = new ControlsItemUC(IconChar.Link, "Lấy link chia sẻ");
            getLinkCon.OnClickControl += () =>
            {

            };

            // Share file
            var shareCon = new ControlsItemUC(IconChar.ShareAltSquare, "Chia sẻ file cho bạn bè");
            shareCon.OnClickControl += () =>
            {

            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Cut file     => xong
            var moveCon = new ControlsItemUC(IconChar.PaperPlane, "Di chuyển file");
            moveCon.OnClickControl += () =>
            {
                var itemUC1 = Constants.CurrentCut as DriveFolderItemUC;
                var itemUC2 = Constants.CurrentCut as DriveFileItemUC;

                // đổi màu file, folder trước đó
                itemUC1?.UnCut();
                itemUC2?.UnCut();

                // kiểm tra nếu trùng file thì cập nhật null và ngừng
                if (Constants.CurrentCut == DriveFileItemUC.CurrentFileItemUCFocus)
                {
                    Constants.Clipboard = null;
                    Constants.CurrentCut = null;
                    DriveFileItemUC.CurrentFileItemUCFocus.SetColorAfterUnCut();

                    return;
                }

                // đưa vào clip board
                Constants.Clipboard = new Common.Clipboard()
                {
                    FileName = DriveFileItemUC.CurrentFileItemUCFocus.fileName,
                    Folder = null,
                    IsFolder = false,
                    ParentFolder = DriveLinkUC.CurrentFolder
                };

                Constants.CurrentCut = DriveFileItemUC.CurrentFileItemUCFocus;

                // đổi màu file cut
                DriveFileItemUC.CurrentFileItemUCFocus.Cut();
            };

            // Download file    => xong
            var downloadCon = new ControlsItemUC(IconChar.Download, "Tải file");
            downloadCon.OnClickControl += () =>
            {
                try
                {
                    var fileName = DriveFileItemUC.CurrentFileItemUCFocus.fileName;
                    var saveFile = new SaveFileDialog();
                    saveFile.Title = "Chọn nơi lưu file";
                    saveFile.FileName = fileName.Substring(9);
                    saveFile.Filter = $"Files (*{Path.GetExtension(fileName)})|*{Path.GetExtension(fileName)};)";
                    saveFile.DefaultExt = Path.GetExtension(fileName);

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy($"./../../Assets/Files/Drive/{fileName}", saveFile.FileName);

                        MyMessageBox.Show("Lưu file thành công", MessageBoxType.Success);
                    }
                }
                catch (Exception)
                {
                    MyMessageBox.Show("Lưu file thất bại", MessageBoxType.Error);
                }
            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Rename  file => xong
            var renameCon = new ControlsItemUC(IconChar.Edit, "Đổi tên file");
            renameCon.OnClickControl += () =>
            {
                var fnewFolder = new fRenameFile(AutofacFactory<IFolderDAO>.Get());
                var fparent = new fParentClickHidden(fnewFolder);
                var fName = "";

                // Close và không sửa tên file
                fnewFolder.OnClickClose += () =>
                {
                    fName = "";
                    fparent.FParentClickHidden_Click(null, null);
                };

                fnewFolder.OnClickUpdate += (fileName) =>
                {
                    fName = fileName;
                    fparent.FParentClickHidden_Click(null, null);
                };

                fparent.FormClosed += (s, o) =>
                {
                    if (!string.IsNullOrEmpty(fName.Trim()))
                    {
                        OnUpdateFileName?.Invoke(fName);
                    }
                };

                // Close và thực hiện sửa tên file

                fparent.ShowDialog();
            };

            // Color file 
            var colorCon = new ControlsItemUC(IconChar.Palette, "Đổi màu file");
            colorCon.OnClickControl += () =>
            {
                try
                {
                    var themUC = new fFileColor();
                    var fparent = new fParentClickHidden(themUC);

                    fparent.FormClosed += (s, o) =>
                    {
                        // thực hiện cập nhật khi được cập nhật
                        OnChangeColorExtension?.Invoke();
                    };

                    fparent.ShowDialog();
                }
                catch (Exception)
                {

                }
            };

            // Delete file  => xong
            var deleteCon = new ControlsItemUC(IconChar.Times, "Xóa file");
            deleteCon.OnClickControl += () =>
            {
                if (MyMessageBox.Show($"Bạn có muốn xóa file {DriveFileItemUC.CurrentFileItemUCFocus.fileName.Substring(9)}?", MessageBoxType.Question).Value == DialogResult.OK)
                {
                    // cập nhật files
                    var files = StringHelper.StringToStringList(DriveLinkUC.CurrentFolder.Files);

                    // Xóa file ra khỏi danh sách file global  
                    files.Remove(DriveFileItemUC.CurrentFileItemUCFocus.fileName);

                    // cập nhật lại file của global
                    DriveLinkUC.CurrentFolder.Files = StringHelper.StringListToString(files);

                    // Xóa file
                    try
                    {
                        File.Delete($"./../../Assets/Files/Drive/{DriveFileItemUC.CurrentFileItemUCFocus.fileName}");
                    }
                    catch (Exception) { }

                    // Cập nhật UI
                    OnDeleteFile?.Invoke();

                    // Kiểm  tra nếu file trong clipboard trùng tên file xóa thì xóa luôn clipboard
                    if (Constants.Clipboard != null && !Constants.Clipboard.IsFolder && Constants.Clipboard.FileName == DriveFileItemUC.CurrentFileItemUCFocus.fileName)
                    {
                        // cho FileFocus vào global

                        Constants.CurrentCut = null;
                        Constants.Clipboard = null;
                    }

                    // Xóa focus file trong ram
                    DriveFileItemUC.CurrentFileItemUCFocus = null;

                    MyMessageBox.Show("Xóa thành công!", MessageBoxType.Success);
                }
            };


            flpControls.Controls.AddRange(new Control[] { getLinkCon, shareCon, GetSeparator(), moveCon, downloadCon, GetSeparator(), renameCon, colorCon, deleteCon });
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

        private void ControlsFileUC_Click(object sender, EventArgs e)
        {
            OnClickSpace?.Invoke();
        }

        #endregion
    }
}
