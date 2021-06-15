using Facebook.Common;
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
    public partial class MessengerFriendItemUC : UserControl
    {
        public delegate void ChangedUser();
        public event ChangedUser OnChangedUser;

        public readonly IMessageQueueDAO _messageQueueDAO;

        public User user;
        public Message message;

        public static MessengerFriendItemUC CurrentItem;

        public MessengerFriendItemUC(User user, Message message, IMessageQueueDAO messageQueueDAO)
        {
            InitializeComponent();

            this.user = user;
            this.message = message;
            this._messageQueueDAO = messageQueueDAO;

            Load();
            SetColor();
        }

        #region Methods

        new private void Load()
        {
            picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, user);
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblName.Text = user.Name;

            lblDesctiption.Text = "Các bạn hiện đã được kết nối"; // get message cuối cùng

            lblDesctiption.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            if (message != null)
            {
                lblDesctiption.Text = GetMessage(message, message.SenderID == Constants.UserSession.ID);
                lblDesctiption.ForeColor = _messageQueueDAO.CheckIsQueue(Constants.UserSession.ID, message.ID) ? Constants.MAIN_FORE_LINK2_COLOR : Constants.MAIN_FORE_SMALLTEXT_COLOR;
            }
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;

            lblName.ForeColor = Constants.MAIN_FORE_COLOR;
            lblName.BackColor = Constants.MAIN_BACK_COLOR;

            lblDesctiption.BackColor = Constants.MAIN_BACK_COLOR;

            UIHelper.BorderRadius(this, Constants.BORDER_RADIUS);
        }

        public void ActiveItemColor(MessengerFriendItemUC item)
        {
            SetColor(item, Constants.ACTIVE_ITEM_FRIEND_COLOR);
            lblDesctiption.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
        }

        public void HoverItemColor(MessengerFriendItemUC item)
        {
            SetColor(item, Constants.HOVER_ITEM_FRIEND_COLOR);
        }

        public void ResetItemColor(MessengerFriendItemUC item)
        {
            SetColor(item, Constants.MAIN_BACK_COLOR);
        }

        private void SetColor(MessengerFriendItemUC item, Color color)
        {
            item.BackColor = color;
            item.lblName.BackColor = color;
            item.lblDesctiption.BackColor = color;
            item.picAvatar.BackgroundImage = ImageHelper.GetAvatarByUser(color, item.user);
        }

        /// <summary>
        /// Reset lại test khi tạo mới message
        /// </summary>
        /// <param name="text"></param>
        public void SetTextWhenCreateNewMessage(Message message)
        {
            lblDesctiption.Text = GetMessage(message);
            lblDesctiption.ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR;
            //lblDesctiption.ForeColor = Constants.MAIN_FORE_LINK2_COLOR;
        }

        /// <summary>
        /// Reset lại test khi nhận được tin mới mà  chưa nhấn vào xem
        /// </summary>
        /// <param name="text"></param>
        public void SetTextWhenReceiveNewMessage(Message message, bool isCurrent)
        {
            lblDesctiption.Text = GetMessage(message, false);
            lblDesctiption.ForeColor = isCurrent ? Constants.MAIN_FORE_SMALLTEXT_COLOR : Constants.MAIN_FORE_LINK2_COLOR;
        }

        public string GetMessage(Message message, bool isSelf = true)
        {
            var text = message.Description;
            var imageCount = StringHelper.StringToStringList(message.Image).Count;
            var fileCount = StringHelper.StringToStringList(message.File).Count;
            var name = user.Name.Substring(user.Name.LastIndexOf(" ") + 1);
            var self = isSelf ? "Bạn" : name;
            var mess = "";
            if (imageCount > 0)
            {
                mess = $"{self} đã gửi {imageCount} ảnh.";
            }
            if (fileCount > 0 && mess == "")
            {
                mess = $"{self} đã gửi {fileCount} file.";
            }

            return string.IsNullOrEmpty(text) ? mess : $"{self}: {text}";
        }

        #endregion

        #region Events

        private void picAvatar_Click(object sender, EventArgs e)
        {
            // reset màu cho current  
            ResetItemColor(CurrentItem);

            // active this
            ActiveItemColor(this);

            CurrentItem = this;

            // thông báo cho cha
            OnChangedUser?.Invoke();
        }

        private void picAvatar_MouseEnter(object sender, EventArgs e)
        {
            if (this != CurrentItem)
            {
                HoverItemColor(this);
            }
        }

        private void MessengerFriendItemUC_MouseLeave(object sender, EventArgs e)
        {
            if (this != CurrentItem)
            {
                ResetItemColor(this);
            }
        }


        #endregion
    }
}
