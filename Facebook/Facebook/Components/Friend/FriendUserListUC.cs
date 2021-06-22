using Facebook.Common;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Friend
{
    public partial class FriendUserListUC : UserControl
    {
        public delegate void ClickUser(User user);
        public delegate void ClickSendOrCancelRequest(User user, bool isSend);
        public delegate void ClickBlockUser(User user);
        public event ClickUser OnClickUser;
        public event ClickSendOrCancelRequest OnClickSendOrCancelRequest;
        public event ClickBlockUser OnClickBlockUser;

        private List<User> users;

        public FriendUserListUC(List<User> users)
        {
            InitializeComponent();

            this.users = users;

            Load();
            SetUpUI();
        }

        #region Methods

        new private void Load()
        {
            LoadItem();
            UpdateHeight();
        }

        private void LoadItem()
        {
            // Cần load các item UC
            foreach (var item in users)
            {
                var itemUC = new FriendUserItemUC(item);

                itemUC.OnClickSection += () => OnClickUser(item);
                itemUC.OnClickSendOrCancelRequest += (isSend) => OnClickSendOrCancelRequest?.Invoke(item, isSend);
                itemUC.OnClickBlock += (itemDelete) =>
                {
                    flpItems.Controls.Remove(itemDelete);   // xóa ra khỏi  danh sách  userList
                    UpdateHeight();
                    OnClickBlockUser(item);
                };

                flpItems.Controls.Add(itemUC);
            }
        }

        private void SetUpUI()
        {
            pnlSeparator.Width = this.Width;
            pnlSeparator.Height = 1;
            pnlSeparator.BackColor = Constants.BORDER_BOX_COLOR;
            pnlSeparator.Left = 0;

            this.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            lblTitle.ForeColor = Constants.MAIN_FORE_COLOR;
            lblTitle.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;

            flpItems.BackColor = Constants.MAIN_BACK_CONTENT_COLOR;
        }

        private void UpdateHeight()
        {
            var margin = 10;
            var height = flpItems.Top;
            var heightContent = 0;
            foreach (Control item in flpItems.Controls)
            {
                heightContent += item.Height;
            }

            flpItems.Height = heightContent;
            this.Height = height + heightContent + pnlSeparator.Height + margin;
            pnlSeparator.Top = this.Height - pnlSeparator.Height;
        }

        #endregion

        #region Events


        #endregion
    }
}
