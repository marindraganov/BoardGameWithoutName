namespace ViewLayerWPF.ValueConverters
{
    using System;
    using System.Windows.Data;
    using GameLogic.Map;
    using ViewLayerWPF.GameWindowControls;

    internal class TokenRowToYPosition : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(double))
            {
                return null;
            }

            int currRow = int.Parse(value.ToString());
            int rows = MapControl.Rows;
            double heigth = MapControl.Height;

            double posY = heigth / rows * currRow;

            return posY;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
