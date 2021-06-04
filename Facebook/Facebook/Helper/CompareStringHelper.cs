using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Helper
{
    static class CompareStringHelper
    {
        private static readonly string[] VietnameseChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string Convert(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietnameseChar.Length; i++)
            {
                for (int j = 0; j < VietnameseChar[i].Length; j++)
                    str = str.Replace(VietnameseChar[i][j], VietnameseChar[0][i - 1]);
            }
            return str;
        }

        public static bool Contanins(string str, string subStr)
        {
            var A = Convert(str.ToUpper());
            var B = Convert(subStr.ToUpper());
            return Convert(str.ToUpper()).Contains(Convert(subStr.ToUpper()));
        }
    }
}
