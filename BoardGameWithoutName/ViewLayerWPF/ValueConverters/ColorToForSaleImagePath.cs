using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewLayerWPF.ValueConverters
{
    class ColorToForSaleImagePath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;

            if(color.A > color.B && color.A > color.G)
            {
                return "/Media/Images/ForSale2.png";
            }
            else if (color.B > color.A && color.B > color.G)
            {
                return "/Media/Images/ForSale3.png";
            }
            else if (color.G > color.A && color.G > color.B)
            {
                return "/Media/Images/ForSale1.png";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
