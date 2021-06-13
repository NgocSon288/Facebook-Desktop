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
            if (s == null)
            {
                return new List<string>();
            }

            return new List<string>(s.Split(new string[] { Constants.SEPERATE_CHAR }, StringSplitOptions.RemoveEmptyEntries));
        }

        public static List<int> StringToIntList(string s)
        {
            if (s == null)
            {
                return new List<int>();
            }

            return (new List<string>(s.Split(new string[] { Constants.SEPERATE_CHAR }, StringSplitOptions.RemoveEmptyEntries))).Select(m => Convert.ToInt32(m)).ToList();
        }


        public static string IntListToString(List<int> list)
        {
            return StringListToString(list.Select(m => m.ToString()).ToList());
        }
    }
}
