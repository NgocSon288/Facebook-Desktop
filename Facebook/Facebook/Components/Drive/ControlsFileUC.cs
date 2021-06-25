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
    public partial class ControlsFileUC : UserControl
    {
        public delegate void ClickSpace();
        public event ClickSpace OnClickSpace;

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
            var shareCon = new ControlsItemUC(IconChar.ShareAltSquare, "Chia sẻ thư mục cho bạn bè");
            shareCon.OnClickControl += () =>
            {

            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Cut file
            var moveCon = new ControlsItemUC(IconChar.PaperPlane, "Duy chuyển  thư mục");
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

            // Download file
            var downloadCon = new ControlsItemUC(IconChar.Download, "Tải thư mục");
            downloadCon.OnClickControl += () =>
            {

            };

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // Rename  file
            var renameCon = new ControlsItemUC(IconChar.Edit, "Đổi tên thư mục");
            renameCon.OnClickControl += () =>
            {

            };

            // Delete file
            var deleteCon = new ControlsItemUC(IconChar.Times, "Xóa thư mục");
            deleteCon.OnClickControl += () =>
            {

            };


            flpControls.Controls.AddRange(new Control[] { getLinkCon, shareCon, GetSeparator(), moveCon, downloadCon, GetSeparator(), renameCon, deleteCon });
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
