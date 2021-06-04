using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.ControlCustom.Message
{
    public class MyDialogResult
    {
        public DialogResult Value { get; set; }

        public MyDialogResult()
        {
            Value = DialogResult.Cancel;
        }
    }
}
