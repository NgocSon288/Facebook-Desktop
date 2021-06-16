using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Common
{
    public static class ThemeColor
    {
        public static List<ThemeColorItem> Themes = new List<ThemeColorItem>()
        {
            new ThemeColorItem("timnho", Color.FromArgb(94,0,126)),
            new ThemeColorItem("loang", Color.FromArgb(0,82,205)),
            new ThemeColorItem("theseries", Color.FromArgb(159,36,255)),
            new ThemeColorItem("nhietdoi", Color.FromArgb(159,213,45)),

            new ThemeColorItem("bongram", Color.FromArgb(62,59,189)),
            new ThemeColorItem("kylan", Color.FromArgb(58, 29, 138)),
            new ThemeColorItem("keomut", Color.FromArgb(77,62,194)),
            new ThemeColorItem("thugian", Color.FromArgb(64, 159, 255)),

            new ThemeColorItem("tao", Color.FromArgb(170, 50,50)),
            new ThemeColorItem("daiduong", Color.FromArgb(54, 83, 232)),
            new ThemeColorItem("camchanh", Color.FromArgb(0,223,187)),
            new ThemeColorItem("timoaihuong", Color.FromArgb(174,160,255))
        };

        public static ThemeColorItem GetThemeByName(string name)
        {
            return Themes.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class ThemeColorItem
    {
        public string Name { get; set; }

        public Color Color { get; set; }

        public ThemeColorItem()
        {

        }

        public ThemeColorItem(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}
