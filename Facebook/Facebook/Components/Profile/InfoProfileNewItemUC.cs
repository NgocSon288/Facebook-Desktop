using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.Helper;
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
    public partial class InfoProfileNewItemUC : UserControl
    {
        public delegate void AddNewItem(string content);
        public event AddNewItem OnAddNewItem;
        public delegate void RemoveNewItem();
        public event RemoveNewItem OnRemoveNewIte;


        private string textPlaceholder;

        public InfoProfileNewItemUC(string textPlaceholder)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this.textPlaceholder = textPlaceholder;

            Load();

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS_SECTION_LIKE);
            UIHelper.SetBlur(this, () => this.ActiveControl = null);
        }
        #region Methods

        new private void Load()
        {
            // LoadText
            txtText.Text = textPlaceholder;

            SetColor();
        }

        private void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
            txtText.BackColor = color;
            btnAdd.BackColor = color;
            btnCancel.BackColor = color;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnAdd.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnAdd.IconColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
            btnAdd.FlatAppearance.MouseOverBackColor = Constants.EXPAND_HEADER_COLOR;

            btnCancel.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnCancel.IconColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
            btnCancel.FlatAppearance.MouseOverBackColor = Constants.EXPAND_HEADER_COLOR;

            txtText.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            txtText.ForeColor = Constants.MAIN_FORE_PARAGRAPH_COLOR;
        }


        #endregion

        #region Events

        private void txtText_MouseEnter(object sender, EventArgs e)
        {
            var txt = txtText.Text;

            if (string.Equals(txt, textPlaceholder, StringComparison.OrdinalIgnoreCase))
            {
                txtText.Text = "";
            }

            // Color
            txtText.ForeColor = Constants.TEXTBOX_ENTER_FORECOLOR;
            pnlBottomText.BackColor = Constants.TEXTBOX_ENTER_FORECOLOR;
        }

        private void txtText_MouseLeave(object sender, EventArgs e)
        {
            var txt = txtText.Text;

            if (string.IsNullOrEmpty(txt.Trim()))
            {
                txtText.Text = textPlaceholder;
            }

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
        /// Thêm vào db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var txt = txtText.Text;

            if (string.IsNullOrEmpty(txt.Trim()) || txt == textPlaceholder)
            {
                MyMessageBox.Show("Thông tin không hợp lệ", MessageBoxType.Error);

                return;
            }

            // Thông báo cho InfoProfileSection xóa newItem ra, và  thêm item thay thế
            // Truyền vào nội dung cho cha xử lý
            OnAddNewItem?.Invoke(txt);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnRemoveNewIte?.Invoke();
        }

        #endregion
    }
}
