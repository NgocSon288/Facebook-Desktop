using Facebook.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Helper
{
    public static class StringHelper
    {
        public static string StringListToString(List<string> list)
        {
            return string.Join(Constants.SEPERATE_CHAR, list);
        }

        public static List<string> StringToStringList(string s)
        {
            return new List<string>(s.Split(new string[] { Constants.SEPERATE_CHAR }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
