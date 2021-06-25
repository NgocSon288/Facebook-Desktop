using Facebook.Common;
using FontAwesome.Sharp;
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
    public partial class ControlsFolderUC : UserControl
    {
        public delegate void ClickSpace();
        public event ClickSpace OnClickSpace;

        private ControlsItemUC pasteCon;

        public ControlsFolderUC()
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
            // Get link folder
            var getLinkCon = new ControlsItemUC(IconChar.Link, "Lấy link chia sẻ");
            getLinkCon.OnClickControl += () =>
            {

            };

            // Share folder
            var shareCon = new ControlsItemUC(IconChar.ShareAltSquare, "Chia sẻ thư mục cho bạn bè");
            shareCon.OnClickControl += () =>
            {

            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Cut folder
            var moveCon = new ControlsItemUC(IconChar.PaperPlane, "Duy chuyển  thư mục");
            moveCon.OnClickControl += () =>
            {
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

            // Paste folder
            pasteCon = new ControlsItemUC(IconChar.Paste, "Paste");
            pasteCon.OnClickControl += () =>
            {

            };

            // Download folder
            var downloadCon = new ControlsItemUC(IconChar.Download, "Tải thư mục");
            downloadCon.OnClickControl += () =>
            {

            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Rename  folder
            var renameCon = new ControlsItemUC(IconChar.Edit, "Đổi tên thư mục");
            renameCon.OnClickControl += () =>
            {

            };

            // Color folder
            var colorCon = new ControlsItemUC(IconChar.Palette, "Thay đổi màu sắc");
            colorCon.OnClickControl += () =>
            {

            };

            // Delete folder
            var deleteCon = new ControlsItemUC(IconChar.Times, "Xóa thư mục");
            deleteCon.OnClickControl += () =>
            {

            };


            flpControls.Controls.AddRange(new Control[] { getLinkCon, shareCon, GetSeparator(), moveCon, pasteCon, downloadCon, GetSeparator(), renameCon, colorCon, deleteCon });

            CheckClipboard();
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
