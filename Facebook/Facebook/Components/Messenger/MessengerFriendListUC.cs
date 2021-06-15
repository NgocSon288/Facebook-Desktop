using Facebook.Common;
using Facebook.Configure.Autofac;
using Facebook.DAO;
using Facebook.Helper;
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
using Message = Facebook.Model.Models.Message;

namespace Facebook.Components.Messenger
{
    public partial class MessengerFriendListUC : UserControl
    {
        public delegate void ChangedUser();
        public event ChangedUser OnChangedUser;

        private readonly IUserDAO _userDAO;
        private readonly IMessageDAO _messageDAO;

        private List<User> friendList;

        public Dictionary<int, MessengerFriendItemUC> itemsUC;

        public MessengerFriendListUC(IUserDAO userDAO, IMessageDAO messageDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;
            this._messageDAO = messageDAO;

            Load();
            SetColor();
        }

        #region Methods

        new private void Load()
        {
            var i = 0;
            var users = _userDAO.GetAll();
            var friends = StringHelper.StringToIntList(Constants.UserSession.Friend);

            friendList = friends.Join(users, f => f, u => u.ID, (f, u) => u).ToList();
            itemsUC = new Dictionary<int, MessengerFriendItemUC>();

            foreach (var item in friendList)
            {
                var itemUC = new MessengerFriendItemUC(item, _messageDAO.GetLastCommentByUserID(item.ID, Constants.UserSession.ID), AutofacFactory<IMessageQueueDAO>.Get());
                if (i == 0)
                {
                    MessengerFriendItemUC.CurrentItem = itemUC;
                    itemUC.ActiveItemColor(itemUC);
                    i++;
                }
                itemUC.OnChangedUser += () =>
                {
                    // thông báo cho cha
                    OnChangedUser?.Invoke();
                };

                itemsUC.Add(item.ID, itemUC);
                flpContent.Controls.Add(itemUC);
            }
        }


        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
            flpContent.BackColor = Constants.MAIN_BACK_COLOR;
        }

        #endregion

        #region Events


        #endregion
    }
}
