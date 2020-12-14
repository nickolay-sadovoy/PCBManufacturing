using System;
using System.Globalization;
using System.Windows.Data;

namespace PCBManufacturing.Helpers.Converters
{
    public class DecreseParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double delta = 0;
            if (parameter is string)
            {
                double.TryParse(parameter as string, out delta);
            }

            if (value is double)
                return (value as double?).Value - delta;

            if (value is int)
                return (value as int?).Value - Math.Round(delta,MidpointRounding.ToEven);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
