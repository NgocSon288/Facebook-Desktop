using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.Helper;
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

namespace Facebook.Components.Profile
{
    public partial class InfoProfileItemUC : UserControl
    {
        public delegate void RemoveItem(string content);
        public event RemoveItem OnRemoveItem;
        public delegate void UpdateItem(Object sender, string content);
        public event UpdateItem OnUpdateItem;

        private string content;
        private bool isEdit;    // nếu là edit thì hiện cái bottom lên
        private bool isReadOnlyItem;


        public InfoProfileItemUC(string content, bool isReadOnly = false)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this.content = content;
            this.isReadOnlyItem = isReadOnly;

            Load();
        }

        #region Methods

        new private void Load()
        {
            // LoadText
            txtText.Text = content;

            // is readonly
            btnEditOrUpdate.Visible = btnDeleteOrCancel.Visible = !isReadOnlyItem;

            LoadUI();

            SetColor();

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS_SECTION_LIKE);
            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }

        private void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
            txtText.BackColor = color;
            btnDeleteOrCancel.BackColor = color;
            btnEditOrUpdate.BackColor = color;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnDeleteOrCancel.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnDeleteOrCancel.IconColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
            btnDeleteOrCancel.FlatAppearance.MouseOverBackColor = Constants.EXPAND_HEADER_COLOR;

            btnEditOrUpdate.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnEditOrUpdate.IconColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
            btnEditOrUpdate.FlatAppearance.MouseOverBackColor = Constants.EXPAND_HEADER_COLOR;

            txtText.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            txtText.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
        }

        private void LoadUI()
        {
            // Nếu là isEdit thì hiện pnlBottom, readonly = false 
            pnlBottomText.Visible = isEdit;
            txtText.Enabled = isEdit;

            // Load icon cho 2 button control
            btnEditOrUpdate.IconChar = isEdit ? IconChar.Check : IconChar.Edit;
            btnDeleteOrCancel.IconChar = isEdit ? IconChar.UndoAlt : IconChar.Minus;

        }

        #endregion

        #region Events

        private void txtText_MouseEnter(object sender, EventArgs e)
        {

            // Color
            txtText.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlBottomText.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
        }

        private void txtText_MouseLeave(object sender, EventArgs e)
        {

            // Color
            txtText.ForeColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
            pnlBottomText.BackColor = Constants.TEXTBOX_LEAVE_FORECOLOR;
        }

        private void InfoProfileItemUC_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundColor(Constants.MAIN_BACK_CONTENT_COLOR);
        }

        private void InfoProfileItemUC_MouseEnter1(object sender, EventArgs e)
        {
            SetBackgroundColor(Constants.EXPAND_HEADER_COLOR);
        }

        /// <summary>
        /// Click vào edit  thì chuyển thành update và ngược  lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditOrUpdate_Click(object sender, EventArgs e)
        {
            // Nếu đang là edit mà nhấn vào thì cập nhật xuống db rồi mới load lại
            if (isEdit)
            {
                content = txtText.Text;

                OnUpdateItem?.Invoke(this, content);
            }

            isEdit = !isEdit;
            btnDeleteOrCancel.Tag = txtText.Text;

            LoadUI();
        }

        /// <summary>
        /// Click vào remove thì chuyển sang cancel và ngược lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Nếu không đang ở edit mà nhấn vào thì remove, cập nhật db
            if (!isEdit)
            {
                if (MyMessageBox.Show("Bạn có muốn xóa!", MessageBoxType.Question).Value == DialogResult.OK)
                {
                    // Xóa element này
                    this.Visible = false;
                    this.Height = 0;

                    // Thông báo cho InfoProfileSectionUC giảm height xuống
                    OnRemoveItem?.Invoke(content);
                }

                return;
            }

            isEdit = false;

            txtText.Text = btnDeleteOrCancel.Tag.ToString();

            LoadUI();
        }

        private void btnEditOrUpdate_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnEditOrUpdate_MouseLeave(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
