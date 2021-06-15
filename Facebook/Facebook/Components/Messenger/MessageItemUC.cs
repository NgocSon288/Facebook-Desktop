using Facebook.Common;
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
using Message = Facebook.Model.Models.Message;

namespace Facebook.Components.Messenger
{
    public partial class MessageItemUC : UserControl
    {

        private Message message;
        private bool isSelf;    // true là nằm bên phải, false là bên trái

        public MessageItemUC(Message message)
        {
            InitializeComponent();

            this.message = message;

            Load();
            SetColor();
            UpdateHeight();
        }

        #region Methods

        new private void Load()
        {
            isSelf = message.SenderID == Constants.UserSession.ID;

            if (isSelf)
            {
                // hiện icon bên phải
                picFriendAvatarRight.Visible = false;
            }
            else
            {
                pnlRight.Visible = false;

                // hiện icon của friend bên trái
                picFriendAvatarLeft.BackgroundImage = ImageHelper.GetAvatarByUser(Constants.MAIN_BACK_COLOR, MessengerFriendItemUC.CurrentItem.user);
            }

            // cứ add content image, file, text vào -->> còn position do isSelf quy định  

            // Time
            var time = new Label()
            {
                AutoSize = false,
                Width = pnlContent.Width,
                Height = 30,
                ForeColor = Constants.MAIN_FORE_SMALLTEXT_COLOR,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = GetTime(message.CreatedAt)
            };
            time.Font = new Font("Consolas", 8);

            time.Top = 0;
            pnlContent.Controls.Add(time);

            // Image
            var messageItemImageUC = new MessageItemImageUC(StringHelper.StringToStringList(message.Image), !isSelf);
            if (isSelf)
            {
                messageItemImageUC.Left = pnlContent.Width - messageItemImageUC.Width;
            }
            messageItemImageUC.Top = time.Bottom;
            pnlContent.Controls.Add(messageItemImageUC);

            // File
            var messageItemFileUC = new MessageItemFileUC(StringHelper.StringToStringList(message.File), !isSelf);
            if (isSelf)
            {
                messageItemFileUC.Left = pnlContent.Width - messageItemFileUC.Width;
            }
            messageItemFileUC.Top = messageItemImageUC.Bottom;
            pnlContent.Controls.Add(messageItemFileUC);

            // Text
            var messageItemTextUC = new MessageItemTextUC(message.Description);
            if (isSelf)
            {
                messageItemTextUC.Left = pnlContent.Width - messageItemTextUC.Width;
            }
            messageItemTextUC.Top = messageItemFileUC.Bottom;
            pnlContent.Controls.Add(messageItemTextUC);

            pnlContent.Top = 0;
            pnlContent.Height = messageItemFileUC.Height + messageItemTextUC.Height + time.Height + messageItemImageUC.Height;
            this.Height = pnlContent.Height;
        }

        private void SetColor()
        {
            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        private void UpdateHeight()
        {

        }

        private string GetTime(DateTime time)
        {
            var da = time.ToShortDateString();
            var ti = time.ToShortTimeString();

            var day = da.Substring(0, da.IndexOf('/'));
            da = da.Substring(da.IndexOf('/') + 1);
            var month = da.Substring(0, da.IndexOf('/'));
            var year = da.Substring(da.IndexOf('/') + 1);
            var hour = ti.Substring(0, ti.IndexOf(':'));
            var minute = ti.Substring(ti.IndexOf(':') + 1, ti.IndexOf(' ') - ti.IndexOf(':') - 1);
            var apm = ti.Substring(ti.IndexOf(' ') + 1);

            hour = apm == "PM" ? (Convert.ToInt32(hour) + 12).ToString() : hour;

            if (time.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return $"{hour}:{minute}";
            }

            if (time.Year == DateTime.Now.Year)
            {
                return $"{hour}:{minute}, {day} tháng {month}";
            }

            return $"{hour}:{minute}, {day} tháng {month} năm {year}";
        }

        #endregion
    }
}
