using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PCBManufacturing.Helpers.Converters
{
    public class PercentToColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 0.0;
            if (value is double)
                result = (double)value;
            
            return new GridLength(result, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
