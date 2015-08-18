﻿namespace ViewLayerWPF.ValueConverters
{
    using System;
    using System.Windows.Data;
    using ViewLayerWPF.GameWindowControls;

    public class TokenColToXPosition : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(double))
            {
                return null;
            }
            
            int currCol = int.Parse(value.ToString());
            int cols = MapControl.Cols;
            double width = MapControl.Width;

            return (currCol + 0.5) * (width / cols);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
