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
    public partial class FriendRequestedListUC : UserControl
    {
        public delegate void ClickUser(User user);
        public delegate void ClickDelete(User user);
        public delegate void ClickAccept(User user);
        public event ClickUser OnClickUser;
        public event ClickDelete OnClickDelete;
        public event ClickAccept OnClickAccept;

        private List<User> users;

        public FriendRequestedListUC(List<User> users)
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
                var itemUC = new FriendRequestedItemUC(item);

                itemUC.OnClickSection += () => OnClickUser(item);
                itemUC.OnClickDelete += () =>
                {
                    flpItems.Controls.Remove(itemUC);
                    UpdateHeight();
                    OnClickDelete?.Invoke(item);
                };
                itemUC.OnClickAccept += () =>
                {
                    flpItems.Controls.Remove(itemUC);
                    UpdateHeight();
                    OnClickAccept?.Invoke(item);
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
            if (users.Count <= 0 || flpItems.Controls.Count <= 0)
            {
                var lbl = new Label()
                {
                    AutoSize = false,
                    Width = this.Width,
                    Margin = new Padding(0, 0, 0, 0),
                    Padding = new Padding(0, 0, 0, 0),
                    Height = 100,
                    ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR,
                    Text = "Không có yêu cầu mới",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Consolas", 12),
                    Top = -10
                };

                flpItems.Controls.Add(lbl);
            }

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

        public void DeleteItemByUser(User user)
        {
            try
            {
                FriendRequestedItemUC itemUC = null;
                foreach (FriendRequestedItemUC item in flpItems.Controls)
                {
                    if (item.user.ID == user.ID)
                    {
                        itemUC = item;
                        break;
                    }
                }

                flpItems.Controls.Remove(itemUC);
                UpdateHeight();
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Events


        #endregion
    }
}
