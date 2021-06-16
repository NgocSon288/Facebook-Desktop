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

        public List<Message> messages;
        private MessageEmptyUC messageEmptyUC;

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

            if (messages != null && messages.Count > 0)
            {
                foreach (var item in messages)
                {
                    var itemUC = new MessageItemUC(item);

                    if (flpContent.InvokeRequired)
                    {

                        flpContent.BeginInvoke((Action)(() =>
                        {
                            flpContent.Controls.Add(itemUC);
                        }));
                    }
                    else
                    {
                        flpContent.Controls.Add(itemUC);
                    }
                }

                ScrollToBottom();
            }
            else
            {
                LoadEmpty();
            }


            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        public void SetThemeColor()
        {
            foreach (Control item in flpContent.Controls)
            {
                var itemUC = item as MessageItemUC;

                if (itemUC != null)
                    itemUC.SetThemeColor();
            }
        }

        private void LoadEmpty()
        {
            messageEmptyUC = new MessageEmptyUC();

            flpContent.Controls.Add(messageEmptyUC);
        }

        public void AddNewMessage(Message newMessage)
        {
            // Nếu messages.count == 0 => remove empty

            if (messages.Count <= 0)
            {
                flpContent.Controls.Clear();
            }

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
