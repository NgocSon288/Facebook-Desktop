using Facebook.Common;
using Facebook.Components.Messenger;
using Facebook.Configure.Autofac;
using Facebook.ControlCustom.Message;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = Facebook.Model.Models.Message;

namespace Facebook.FormUC
{
    public partial class fMessenger : UserControl
    {
        private readonly IMessageDAO _messageDAO;
        private readonly IMessageQueueDAO _messageQueueDAO;

        private MessengerFriendListUC messengerFriendListUC;    // left
        private MessageListUC messageListUC;

        public fMessenger(IMessageDAO messageDAO, IMessageQueueDAO messageQueueDAO)
        {
            InitializeComponent();

            timerMQ.Start();

            this._messageDAO = messageDAO;
            this._messageQueueDAO = messageQueueDAO;

            SetUpUI();
            SetColor();
            Load();

            UIHelper.SetBlur(this, () => this.ActiveControl = pnlMiddle);
        }

        #region Methods

        new private void Load()
        {
            if (!string.IsNullOrEmpty(Constants.UserSession.Friend))
            {
                LoadLeft();

                LoadMiddle();
            }
            else
            {
                LoadEmpty();
            }
        }

        private void LoadLeft()
        {
            pnlLeft.Controls.Clear();

            messengerFriendListUC = new MessengerFriendListUC(AutofacFactory<IUserDAO>.Get(), AutofacFactory<IMessageDAO>.Get());
            messengerFriendListUC.OnChangedUser += () =>
            {
                // Load lại thông tin ở giữa
                LoadMiddle();
            };

            pnlLeft.Controls.Add(messengerFriendListUC);
        }

        private void LoadMiddle()
        {
            if (MessengerFriendItemUC.CurrentItem == null)
            {
                return;
            }

            var senderID = Constants.UserSession.ID;
            var receiverID = MessengerFriendItemUC.CurrentItem.user.ID;

            // Kiểm tra MQ, người này có nhắn cho mình hay không, nếu có thì cập nhật xóa mq của mình
            var mq = _messageQueueDAO.GetByMultipID(senderID, receiverID, senderID);
            if (mq != null)
            {
                // Nếu có thì xóa
                _messageQueueDAO.Delete(mq);

                // Cập nhật mq của người gửi thành isRead = true
                var mqO = _messageQueueDAO.GetByMultipID(receiverID, receiverID, senderID);
                mqO.isRead = true;
                _messageQueueDAO.SaveChanges();

                // cập nhật UI text xanh thành trắng
            }

            // Load Top
            pnlMiddleTop.Controls.Clear();
            var messengerHeaderMessageUC = new MessengerHeaderMessageUC(MessengerFriendItemUC.CurrentItem.user);

            pnlMiddleTop.Controls.Add(messengerHeaderMessageUC);


            // Load Center
            pnlMiddleCenter.Controls.Clear();
            messageListUC = new MessageListUC(AutofacFactory<IMessageDAO>.Get());

            pnlMiddleCenter.Controls.Add(messageListUC);


            // Load Bottom
            pnlMiddleBottom.Controls.Clear();
            var messengerContentMessageUC = new MessengerContentMessageUC();
            messengerContentMessageUC.OnHeightChanged += () =>
            {
                pnlMiddleBottom.Height = messengerContentMessageUC.Height;
            };
            messengerContentMessageUC.OnSendMessage += (description, imageList, fileList) =>
              {

                  var message = new Message();
                  message.SenderID = senderID;
                  message.ReceiverID = receiverID;
                  message.Description = description;
                  message.CreatedAt = DateTime.Now;

                  // Lưu hình ảnh
                  if (imageList != null && imageList.Count > 0)
                  {
                      message.Image = UpdateLoadImages(imageList);
                  }
                  else
                  {
                      message.Image = null;
                  }

                  // Lưu file 
                  if (fileList != null && fileList.Count > 0)
                  {
                      message.File = UpdateLoadFiles(fileList);
                  }
                  else
                  {
                      message.File = null;
                  }

                  // Lưu Message để có MessageID
                  _messageDAO.Create(message);

                  // tạo MQ cho người gửi, kiểm tra đã có chưa, nếu có thì isRead cập nhật thành true
                  var mq1 = _messageQueueDAO.GetByMultipID(senderID, senderID, receiverID);

                  if (mq1 == null)
                  {
                      mq1 = new MessageQueue()
                      {
                          OwnID = senderID,
                          SenderID = senderID,
                          ReceiverID = receiverID,
                          MessageID = message.ID,
                          isRead = false
                      };

                      _messageQueueDAO.Create(mq1);
                  }
                  else
                  {
                      mq1.isRead = false;
                      mq1.MessageID = message.ID;

                      _messageQueueDAO.SaveChanges();
                  }

                  // tạo MQ cho người nhận, kiểm tra nếu không có thì thêm vào, nếu có cập nhật MessageID
                  var mq2 = _messageQueueDAO.GetByMultipID(receiverID, senderID, receiverID);
                  if (mq2 == null)
                  {
                      mq2 = new MessageQueue()
                      {
                          OwnID = receiverID,
                          SenderID = senderID,
                          ReceiverID = receiverID,
                          MessageID = message.ID,
                          isRead = false
                      };

                      _messageQueueDAO.Create(mq2);
                  }
                  else
                  {
                      _messageQueueDAO.Delete(mq2);
                      _messageQueueDAO.SaveChanges();

                      mq2 = new MessageQueue()
                      {
                          OwnID = receiverID,
                          SenderID = senderID,
                          ReceiverID = receiverID,
                          MessageID = message.ID,
                          isRead = false
                      };

                      _messageQueueDAO.Create(mq2);
                  }

                  // Thêm vào MessageList
                  messageListUC.AddNewMessage(message);

                  // Có thể cập nhật lại CurrentItem 
                  MessengerFriendItemUC.CurrentItem.SetTextWhenCreateNewMessage(message);
              };

            pnlMiddleBottom.Controls.Add(messengerContentMessageUC);
        }

        private string UpdateLoadImages(List<string> list)
        {
            var result = new List<string>();

            foreach (var item in list)
            {
                if (File.Exists(item))
                {

                    var newFileName = Path.GetFileName(item);
                    newFileName = new Random().Next(0, 1000000000).ToString() + newFileName;

                    if (!File.Exists(Path.Combine("./../../Assets/Images/Messenger/" + newFileName)))
                    {
                        File.Copy(item, Path.Combine("./../../Assets/Images/Messenger/", newFileName));

                        result.Add(newFileName);
                    }
                }
            }

            return StringHelper.StringListToString(result);
        }

        private string UpdateLoadFiles(List<string> list)
        {
            var result = new List<string>();

            foreach (var item in list)
            {
                if (File.Exists(item))
                {

                    var newFileName = Path.GetFileName(item);
                    newFileName = new Random().Next(0, 1000000000).ToString() + newFileName;

                    if (!File.Exists(Path.Combine("./../../Assets/Files/Messenger/" + newFileName)))
                    {
                        File.Copy(item, Path.Combine("./../../Assets/Files/Messenger/", newFileName));

                        result.Add(newFileName);
                    }
                }
            }

            return StringHelper.StringListToString(result);
        }

        private void LoadEmpty()
        {
            pnlWrap.BackColor = Constants.MAIN_BACK_COLOR;
            // Không có bạn bè nào
            pnlWrap.Controls.Clear();

            var pic = new PictureBox()
            {
                Width = 800,
                Height = 800 * 560 / 900,
            };

            pic.Location = new Point(pnlWrap.Width / 2 - pic.Width / 2, pnlWrap.Height / 2 - pic.Height / 2 - 250);

            pic.BackgroundImage = Image.FromFile("./../../Assets/Images/Messenger/empty-message.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            var lbl = new Label()
            {
                Text = "Hãy kết bạn để có thể sử dụng tính năng này",
                BackColor = Constants.MAIN_BACK_COLOR,
                ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR,
                AutoSize = true
            };
            lbl.Font = new Font("Consolas", 18);

            lbl.Location = new Point(400, pnlWrap.Height / 2);

            pnlWrap.Controls.Add(pic);
            pnlWrap.Controls.Add(lbl);
        }

        private void SetColor()
        {
            pnlWrap.BackColor = Constants.BORDER_BOX_COLOR;
            pnlLeft.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMiddle.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMiddleCenter.BackColor = Constants.MAIN_BACK_COLOR;
            pnlMiddleBottom.BackColor = Constants.MAIN_BACK_COLOR;
            pnlRight.BackColor = Constants.MAIN_BACK_COLOR;
        }




        #endregion

        #region SetUpUI

        private void SetUpUI()
        {
            // Set background color for form
            this.BackColor = Constants.MAIN_BACK_COLOR;

            // Set color for button control window
            btnMinimize.BackColor = Constants.MAIN_BACK_COLOR;
            btnMinimize.ForeColor = Constants.MAIN_FORE_COLOR;
            btnMinimize.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
            btnClose.BackColor = Constants.MAIN_BACK_COLOR;
            btnClose.ForeColor = Constants.MAIN_FORE_COLOR;
            btnClose.FlatAppearance.MouseOverBackColor = Constants.CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            if (MyMessageBox.Show("Bạn có muốn thoát?", MessageBoxType.Question).Value == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            Constants.MainForm.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Thực hiện  truy xuất DB liên tục
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMQ_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Constants.UserSession == null || MessengerFriendItemUC.CurrentItem == null || MessengerFriendItemUC.CurrentItem.user == null)
                    return;

                var ownID = Constants.UserSession.ID;
                var currentID = MessengerFriendItemUC.CurrentItem.user.ID;

                var mqs = _messageQueueDAO.GetByUserID(ownID);

                if (mqs.Count <= 0)
                {
                    return;
                }

                var a = _messageQueueDAO.GetAll().Max(m => m.MessageID);

                List<MessageQueue> deleteList = new List<MessageQueue>();
                foreach (var item in mqs)
                {
                    // Send
                    // Tìm các mq mà mình gửi mà người nhận  đã đọc
                    if (item.SenderID == ownID && item.isRead)
                    {
                        deleteList.Add(item);
                    }

                    // Receive
                    // Tìm ra các mq mà mình nhận được cập nhật db
                    if (item.ReceiverID == ownID)
                    {
                        // tìm ra newMessage
                        var messageID = item.MessageID;
                        var message = _messageDAO.GetByID(messageID);

                        // Nếu dang là currentItem thì add message vào list, còn không thi thôi
                        if (currentID == item.SenderID)
                        {
                            // Xóa luôn, vì coi như đang nhắn tin trực tiếp
                            _messageQueueDAO.Delete(item);

                            // add vào message 
                            messageListUC.AddNewMessage(message);
                        }

                        // nếu không đang ở current, không nhắn tin trực tiếp thì gọi cập nhật current thành màu xanh thôi
                        // cập nhật text nhận thành ->          xin chào ....
                        // text màu xanh
                        // Cần tìm ra MessengerFriendItemUC
                        var itemUC = messengerFriendListUC.itemsUC[item.SenderID];
                        _messageDAO.RefreshData();
                        itemUC.SetTextWhenReceiveNewMessage(message, currentID == item.SenderID);
                    }
                }

                _messageQueueDAO.DeleteMultip(deleteList);
            }
            catch (Exception)
            {

            }

        }

        #endregion
    }
}
