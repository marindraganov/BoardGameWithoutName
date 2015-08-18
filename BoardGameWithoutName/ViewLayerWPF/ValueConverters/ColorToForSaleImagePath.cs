namespace ViewLayerWPF.ValueConverters
{
    using System;
    using System.Drawing;
    using System.Windows.Data;

    internal class ColorToForSaleImagePath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;

            if (color.R > color.B && color.R > color.G)
            {
                return "/Media/Images/ForSale2.png";
            }
            else if (color.B > color.R && color.B > color.G)
            {
                return "/Media/Images/ForSale3.png";
            }
            else if (color.G > color.R && color.G > color.B)
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
