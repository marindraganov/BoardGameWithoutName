using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace ViewLayerWPF.ValueConverters
{
    class ProgressFrom100ToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int progress = (int)value;
            Color color;

            if (progress < 33)
            {
                color = Colors.Green;
            }
            else if (progress < 66)
            {
                color = Colors.Gold;
            }
            else
            {
                color = Colors.Red;
            }

            SolidColorBrush brush = new SolidColorBrush(color);

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
