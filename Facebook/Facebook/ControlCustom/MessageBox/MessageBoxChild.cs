using Facebook.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.ControlCustom.Message
{
    public partial class MessageBoxChild : Form
    {
        public delegate void ClickOk();
        public delegate void ClickCancel();
        public event ClickOk OnClickOk;
        public event ClickCancel OnClickCancel;

        private Form parent;
        private string message;
        private string title;
        private MessageBoxType type;
        private Color color;

        public MessageBoxChild(string message, string title, MessageBoxType type, Form parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.message = message;
            this.title = title;
            this.type = type;

            Load();
        }

        #region Methods

        new private void Load()
        {
            lblTitle.Text = title;
            lblMessage.Text = message;
            picImage.BackgroundImageLayout = ImageLayout.Stretch;

            switch (type)
            {
                case MessageBoxType.Success:
                    color = Constants.SUCCESS_COLOR;
                    SetUI("./../../Assets/Images/icon-success-message.png");
                    break;
                case MessageBoxType.Error:
                    color = Constants.ERROR_COLOR;
                    SetUI("./../../Assets/Images/icon-error-message.png");
                    break;
                case MessageBoxType.Warning:
                    color = Constants.WARNING_COLOR;
                    SetUI("./../../Assets/Images/icon-warning-message.png");
                    break;
                case MessageBoxType.Infomation:
                    color = Constants.INFO_COLOR;
                    SetUI("./../../Assets/Images/icon-infomation-message.png");
                    break;
                case MessageBoxType.Question:
                    color = Constants.QUESTION_COLOR;
                    SetUI("./../../Assets/Images/icon-question-message.png");
                    break;
            }
        }

        private void SetUI(string image)
        {
            picImage.BackgroundImage = new Bitmap(image);
            lblTitle.ForeColor = color;
            lblTitle.Left = (pnlWrap.Width / 2 - lblTitle.Width / 2);
            pnlSeparator.BackColor = color;
            pnlSeparator.Height = 2;
            pnlSeparator.Left = pnlWrap.Width / 2 - pnlSeparator.Width / 2;

            btnCancel.ForeColor = color;
            btnCancel.FlatAppearance.BorderColor = color;
            btnOk.ForeColor = color;
            btnOk.FlatAppearance.BorderColor = color;

            pnlBottom.BackColor = color;
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
            OnClickOk?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            OnClickCancel?.Invoke();
        }

        private void btnOk_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as Button;

            btn.BackColor = color;
            btn.ForeColor = Color.White;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as Button;

            btn.BackColor = Color.White;
            btn.ForeColor = color;
        }
    }
}
