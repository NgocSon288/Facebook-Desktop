using Facebook.Common;
using Facebook.DAO;
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
    public partial class MessageListUC : UserControl
    {
        private readonly IMessageDAO _messageDAO;

        private List<Message> messages;

        public MessageListUC(IMessageDAO messageDAO)
        {
            InitializeComponent();

            this._messageDAO = messageDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            messages = _messageDAO.GetByMultipUserID(MessengerFriendItemUC.CurrentItem.user.ID, Constants.UserSession.ID);

            foreach (var item in messages)
            {
                var itemUC = new MessageItemUC(item);

                flpContent.Controls.Add(itemUC);
            }

            ScrollToBottom();

            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        public void AddNewMessage(Message newMessage)
        {
            messages.Add(newMessage);

            var itemUC = new MessageItemUC(newMessage);

            flpContent.Controls.Add(itemUC);

            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            Label uct = new Label();
            uct.Parent = flpContent;

            this.ActiveControl = uct;

            if (flpContent.VerticalScroll.Visible)
            {
                flpContent.ScrollControlIntoView(uct);
            }
        }



        #endregion
    }
}
