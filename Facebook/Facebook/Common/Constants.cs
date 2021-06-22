using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Common
{
    public static class Constants
    {
        public static readonly string SEPERATE_CHAR = "CS511";
        public static readonly double OPACITY = 0.5;
        public static readonly int BORDER_RADIUS = 35;
        public static readonly int BORDER_RADIUS_SECTION_LIKE = 20;

        public static readonly Color MAIN_BACK_COLOR = Color.FromArgb(36, 37, 38); // all form - màu nền chính cho chương 
        public static readonly Color MAIN_BACK_CONTENT_COLOR = Color.FromArgb(50, 50, 50); // all form - màu nền chính cho chương 
        public static readonly Color MAIN_BACK_CONTENT_ENTER_COLOR = Color.FromArgb(70, 70, 70); // all form - màu nền khi mouse enter
        public static readonly Color MAIN_FORE_COLOR = Color.FromArgb(228, 230, 235);  // all form - màu chữ chính
        public static readonly Color MAIN_FORE_PARAGRAPH_COLOR = Color.FromArgb(208, 210, 214);  // all form - màu chữ chính paragraph
        public static readonly Color MAIN_FORE_PARAGRAPH_NOT_ACTIVE_COLOR = Color.FromArgb(130, 133, 137);  // all form - màu chữ chính paragraph
        public static readonly Color MAIN_FORE_SMALLTEXT_COLOR = Color.FromArgb(176, 179, 184);  // all form - màu chữ chính cho các text nhỏ như ngày tháng
        public static readonly Color MAIN_FORE_LINK_COLOR = Color.FromArgb(84, 160, 255);  // all form - màu chữ chính cho các link
        public static readonly Color MAIN_FORE_LINK2_COLOR = Color.FromArgb(46, 137, 255);  // all form - màu chữ chính cho các link
        public static readonly Color MAIN_FORE_LINK_ENTER_COLOR = Color.Red;  // all form - màu chữ chính cho các link khi enter


        public static readonly Color CONTROLS_WINDOW_MOUSE_OVER_BACK_COLOR = Color.FromArgb(61, 63, 65); // all form - màu khi over minimize, close button

        public static readonly Color BORDER_MENU_LEFT_COLOR = Color.FromArgb(249, 88, 155); // fmain - màu border của menu 


        public static readonly Color TEXTBOX_ENTER_FORECOLOR = MAIN_FORE_COLOR; // Account - màu chữ khi nhấn vào textbox 
        public static readonly Color TEXTBOX_LEAVE_FORECOLOR = Color.FromArgb(131, 149, 167); // Account - màu chữ khi nhấn vào textbox, border bottom
        public static readonly Color BOX_WRAP_TEXT_COLOR = Color.FromArgb(70, 70, 70);
        public static readonly Color BOX_WRAP_TEXT_ENTER_COLOR = Color.FromArgb(80, 80, 80);

        // Profile
        public static readonly Color DEFAULT_IMAGE_COLOR = Color.White; // Màu mặc định khi user không có ảnh bìa
        public static readonly Color EXPAND_HEADER_COLOR = Color.FromArgb(83, 92, 104); // Color khi enter chuột vào phần header của expande
        public static readonly Color BORDER_BOX_COLOR = Color.FromArgb(100, 101, 102); // Color khi enter chuột vào phần header của expande
        public static readonly Color BACKGROUND_COMBOBOX_COLOR = Color.FromArgb(60, 61, 62); // Color khi enter chuột vào phần header của expande
        public static readonly Color BACKGROUND_POSTSTATUS_ACTIVE_COLOR = Color.FromArgb(37, 47, 60); // Khi item  được chọn
        public static readonly Color BACKGROUND_POSTSTATUS_HOVER_COLOR = Color.FromArgb(60, 61, 62); // Khi item  được hover

        public static readonly Color BACKGROUND_TEXTBOX_MYCOMMENT = Color.FromArgb(78, 79, 80);
        public static readonly Color PLACEHOLDER_FORECOLOR = Color.FromArgb(131, 149, 167);
        public static readonly Color LIKED_FORECOLOR = Color.FromArgb(45, 134, 255);

        public static readonly Color BORDER_IMAGE_COLOR = Color.FromArgb(223, 249, 251); //  Màu border của ảnh đại diện


        // Messenger
        public static readonly int BORDER_RADIUS_MESSAGE_TEXT = 50;
        public static readonly Color ACTIVE_ITEM_FRIEND_COLOR = Color.FromArgb(37, 47, 60);
        public static readonly Color HOVER_ITEM_FRIEND_COLOR = Color.FromArgb(50, 50, 50);
        public static readonly Color FILE_BACKGROUND_COLOR = Color.FromArgb(110, 113, 116);
        public static Color THEME_COLOR = Color.FromArgb(94, 0, 126);



        // Bootstrap Color
        public static readonly Color SUCCESS_COLOR = Color.FromArgb(40, 167, 69);
        public static readonly Color ERROR_COLOR = Color.FromArgb(220, 53, 69);
        public static readonly Color WARNING_COLOR = Color.FromArgb(255, 193, 7);
        public static readonly Color INFO_COLOR = Color.FromArgb(0, 123, 255);
        public static readonly Color QUESTION_COLOR = Color.FromArgb(247, 153, 65);


        public static fMain MainForm = null;    // form chính của chương trình
        public static fAccountForm AccountForm = null;

        public static User UserSession = null;      // Giống như session Web, lưu user hiện tại
        public static Profile ProfileSession = null;      // Giống như session Web, lưu profile hiện tại, giúp trang Profile

    }
}
