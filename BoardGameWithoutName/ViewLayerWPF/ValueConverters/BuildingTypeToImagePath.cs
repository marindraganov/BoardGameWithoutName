namespace ViewLayerWPF.ValueConverters
{
    using System;
    using System.Windows.Data;

    using GameLogic.Map.Fields;

    internal class BuildingTypeToImagePath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TypeOfBuilding)
            {
                TypeOfBuilding type = (TypeOfBuilding)value;

                if (type == TypeOfBuilding.House)
                {
                    return "/Media/Images/Buildings/house1.png";
                }
                else if (type == TypeOfBuilding.Hotel)
                {
                    return "/Media/Images/Buildings/hotel1.png";
                }
                else if (type == TypeOfBuilding.Palace)
                {
                    return "/Media/Images/Buildings/palace1.png";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
