using PCBManufacturing.Models.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PCBManufacturing.Helpers.Converters
{
    public class RatioToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Ratio ratio)
            {
                Enum.TryParse(parameter.ToString(), out Ratio MinValue);

                return ratio < MinValue ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
