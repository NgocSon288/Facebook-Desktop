using Facebook.Common;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Profile
{
    public partial class InfoProfileSectionUC : UserControl
    {
        public delegate void Expanded();
        public event Expanded OnExpanded;

        private readonly IProfileDAO _profileDAO;

        private string title;
        private string content; // chuổi các text abcCS511defCS511123
        private IconChar icon;

        private bool isReadonlyPage;
        private bool isLastItem;
        private List<string> contentList;

        private string profileName;

        public InfoProfileSectionUC(string profileName, string title, string content, IconChar icon, IProfileDAO profileDAO, bool isReadOnly = false, bool isLastItem = false)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

            this._profileDAO = profileDAO;

            this.profileName = profileName;
            this.title = title;
            this.content = content;
            this.isReadonlyPage = isReadOnly;
            this.isLastItem = isLastItem;
            this.icon = icon;

            Load();
        }

        #region Methods

        new private void Load()
        {
            contentList = StringHelper.StringToStringList(content);
            btnTitle.Text = title;
            LoadContentSeparator();

            foreach (var text in contentList)
            {
                var item = new InfoProfileItemUC(text, isReadonlyPage);
                item.Tag = text; // old text
                item.OnRemoveItem += Item_OnRemoveItem;
                item.OnUpdateItem += Item_OnUpdateItem;

                flpContent.Controls.Add(item);
            }

            // is readonly
            pnlAdd.Visible = !isReadonlyPage;

            // Cần sửa  lại
            UpdateHeight();

            // Setup header expanded
            btnTitle.FlatAppearance.MouseOverBackColor = Constants.EXPAND_HEADER_COLOR;
            btnTitle.FlatAppearance.MouseDownBackColor = Constants.EXPAND_HEADER_COLOR;
            btnTitle.IconChar = icon;
            btnExpand.FlatAppearance.MouseOverBackColor = Constants.EXPAND_HEADER_COLOR;
            btnExpand.FlatAppearance.MouseDownBackColor = Constants.EXPAND_HEADER_COLOR;

            lblAdd.Text = $"Thêm {title} mới";
            pnlAdd.Width = btnAdd.Width + lblAdd.Width;

            SetColor();

            btnTitle_Click(null, null);

            UIHelper.BorderRadius(pnlHeadTitle, Constants.BORDER_RADIUS_SECTION_LIKE);
            //UIHelper.SetBlur(this, (o, s) => this.ActiveControl = (Control)o, true);
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlHeadTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            btnTitle.IconColor = Constants.MAIN_FORE_COLOR;

            btnExpand.ForeColor = Constants.MAIN_FORE_COLOR;
            btnExpand.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnExpand.IconColor = Constants.MAIN_FORE_COLOR;

            flpContent.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            pnlAdd.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            pnlSeparator.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            btnAdd.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnAdd.IconColor = Constants.MAIN_FORE_LINK_COLOR;
            btnAdd.FlatAppearance.MouseDownBackColor = Constants.MAIN_BACK_CONTENT_COLOR;
            btnAdd.FlatAppearance.MouseOverBackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            lblAdd.LinkColor = Constants.MAIN_FORE_LINK_COLOR;
        }

        private void UpdateHeight()
        {
            // Cách cái separator ra cho đẹp
            var offsetBottom = 10;
            var heightPnlAdd = pnlAdd.Visible ? pnlAdd.Height : 0;

            if (isLastItem)
            {
                pnlSeparator.Height = 0;
                pnlSeparator.Visible = false;
            }

            var top = flpContent.Top;
            var height = top;

            if (flpContent.Visible)
            {
                foreach (Control item in flpContent.Controls)
                {
                    height += item.Height + item.Margin.Top + item.Margin.Bottom;
                }
            }

            height += pnlSeparator.Height;

            flpContent.Height = height - top - pnlSeparator.Height + offsetBottom;
            this.Height = height + offsetBottom + heightPnlAdd;

            if (pnlAdd.Visible)
            {
                pnlAdd.Top = this.Height - heightPnlAdd - pnlSeparator.Height - offsetBottom + 5;
            }
        }

        /// <summary>
        /// Add content vào separator, một đường gạch nhỏ, ở giữa
        /// </summary>
        private void LoadContentSeparator()
        {
            var pnl = new Panel()
            {
                Width = 700,
                Height = 3,
                BackColor = Constants.BORDER_BOX_COLOR,
                Top = 0,
                Left = pnlSeparator.Width / 2 - 700 / 2
            };

            pnlSeparator.Controls.Add(pnl);
        }

        private void SetBackgroundColorHead(Color color)
        {
            pnlHeadTitle.BackColor = color;
            btnTitle.BackColor = color;
            btnExpand.BackColor = color;
        }

        /// <summary>
        /// Kiểm tra đã có newItem chưa
        /// </summary>
        /// <returns></returns>
        private bool NewItemIsExists()
        {
            // Kiểm tra nếu đã có một newItem  thì không cho thực hiện tiếp
            foreach (var control in flpContent.Controls)
            {
                var con = control as InfoProfileNewItemUC;

                // Tồn tại một newItem
                if (con != null)
                {
                    return true;
                }
            }

            return false;
        }

        private InfoProfileNewItemUC GetNewItem()
        {
            foreach (var item in flpContent.Controls)
            {
                var con = item as InfoProfileNewItemUC;

                if (con != null)
                {
                    return con;
                }
            }

            return null;
        }

        new public void Update(string value)
        {
            var type = Constants.ProfileSession.GetType();
            var propertyInfo = type.GetProperty(profileName);

            propertyInfo.SetValue(Constants.ProfileSession, value, null);

            // Update db, vì session tham chiếu db
            _profileDAO.SaveChanges();
        }
        #endregion

        #region Events

        /// <summary>
        ///  Click vào sẽ đóng hoặc mở content bên trong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTitle_Click(object sender, EventArgs e)
        {
            flpContent.Visible = !flpContent.Visible;
            if (!isReadonlyPage)
            {
                pnlAdd.Visible = !pnlAdd.Visible;
            }

            UpdateHeight();
            btnExpand.IconChar = !flpContent.Visible ? IconChar.PlusCircle : IconChar.MinusCircle;

            // Thông báo cho InfoProfileUC biết là độ dài đã thay đổi
            OnExpanded?.Invoke();
        }

        private void pnlHeadTitle_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundColorHead(Constants.EXPAND_HEADER_COLOR);
        }

        private void pnlHeadTitle_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundColorHead(Constants.MAIN_BACK_CONTENT_COLOR);
        }

        /// <summary>
        /// Add thêm item textbox, save, delete vào
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAdd_Click(object sender, EventArgs e)
        {
            if (NewItemIsExists())
            {
                MyMessageBox.Show("Thêm mới không thành công!", MessageBoxType.Warning);

                return;
            }


            var item = new InfoProfileNewItemUC($"{title} mới...");
            item.OnAddNewItem += Item_OnAddNewItem;
            item.OnRemoveNewIte += Item_OnRemoveNewIte;

            flpContent.Controls.Add(item);
            UpdateHeight();

            OnExpanded?.Invoke();
        }

        /// <summary>
        /// Xóa item đó, cập nhật UI
        /// </summary>
        private void Item_OnRemoveNewIte()
        {
            var itemRemove = GetNewItem();

            flpContent.Controls.Remove(itemRemove);
            UpdateHeight();
            OnExpanded?.Invoke();
        }

        /// <summary>
        /// Xử lý khi đã có dữ liệu, và  nhấn ok
        /// </summary>
        /// <param name="content"></param>
        private void Item_OnAddNewItem(string text)
        {
            var itemRemove = GetNewItem();

            // Update ram với content
            contentList.Add(text);
            var content = StringHelper.StringListToString(contentList);

            // update db với content
            Update(content);

            // Cập nhật UI
            flpContent.Controls.Remove(itemRemove);

            var newItem = new InfoProfileItemUC(text);
            newItem.Tag = text; // old text
            newItem.OnRemoveItem += Item_OnRemoveItem;
            newItem.OnUpdateItem += Item_OnUpdateItem;

            flpContent.Controls.Add(newItem);

            MyMessageBox.Show("Cập nhật DB thành công", MessageBoxType.Success);


        }

        private void Item_OnRemoveItem(string text)
        {
            // Update ram với content
            contentList.Remove(text);
            var content = StringHelper.StringListToString(contentList);

            // update db với content
            Update(content);

            UpdateHeight();
            OnExpanded?.Invoke();
        }

        private void Item_OnUpdateItem(object sender, string newText)
        {
            // Lấy ra old text từ tag
            var item = sender as InfoProfileItemUC;
            var oldText = item.Tag.ToString();

            // update ram với content
            var index = contentList.IndexOf(oldText);

            contentList[index] = newText;
            var content = StringHelper.StringListToString(contentList);

            // update db với content
            Update(content);
        }


        #endregion
    }
}
