using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Common
{
    public static class Constants
    {
        public static readonly Color MAIN_BACK_COLOR = Color.FromArgb(188, 206, 229); // all form - màu nền chính cho chương 
        public static readonly Color MAIN_FORE_COLOR = Color.FromArgb(19, 15, 64);  // all form - màu chữ chính
        public static readonly Color CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR = Color.FromArgb(168, 192, 221); // all form - màu khi over minimize, close button

        public static readonly Color BORDER_MENU_LEFT_COLOR = Color.FromArgb(249, 88, 155); // fmain - màu border của menu 


        public static fMain MainForm = null;    // form chính của chương trình
        public static fAccountForm AccountForm = null;
    }
}
