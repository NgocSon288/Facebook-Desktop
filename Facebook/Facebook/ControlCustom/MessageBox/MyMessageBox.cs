using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.ControlCustom.Message
{
    public static class MyMessageBox
    {
        public static MyDialogResult Show(string message, MessageBoxType type, string title = null)
        {
            MyDialogResult result = new MyDialogResult();
            if (title == null)
            {
                switch (type)
                {
                    case MessageBoxType.Success:
                        title = "Success!";
                        break;
                    case MessageBoxType.Error:
                        title = "Error!";
                        break;
                    case MessageBoxType.Warning:
                        title = "Warning!";
                        break;
                    case MessageBoxType.Infomation:
                        title = "Information";
                        break;
                    case MessageBoxType.Question:
                        title = "Question";
                        break;
                }
            }

            MessageBoxCustom a = new MessageBoxCustom(message, title, type, result);
            a.ShowDialog();

            return result;
        }
    }

    public enum MessageBoxType
    {
        Success,
        Error,
        Infomation,
        Warning,
        Question
    }
}
