using GameLogic.Map.Fields.Institutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewLayerWPF.ValueConverters
{
    class CreditsToAmount : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Credit> credits = (List<Credit>)value;
            int sum = 0;
            foreach (var item in credits)
            {
                sum += item.PaymentAmount * item.PaymentsRemainig;
            }

            return sum;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
