using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KomgaInfoChanger.UI
{
    static internal class UiUtils
    {
        public static SolidColorBrush BrushFromColorCode(string colorCode)
        {
            SolidColorBrush colorBrush = new SolidColorBrush();
            //(SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF08585"))
            colorBrush.Color = (Color)ColorConverter.ConvertFromString(colorCode);
            return colorBrush;
        }
    }
}
