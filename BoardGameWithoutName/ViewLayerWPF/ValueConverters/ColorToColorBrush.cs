using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;


namespace ViewLayerWPF.ValueConverters
{
    class ColorToColorBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //System.Drawing.Color color = (System.Drawing.Color)value;
            //string colorName = ((Color)value).;
            SolidColorBrush colorBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(value.ToString());

            return colorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
