using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media;

namespace PCBManufacturing.Helpers.Converters
{
    public class ColorToColorNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value as Color?;
            if (color != null)
            { 
                PropertyInfo colorProperty = typeof(Colors).GetProperties().FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), color.Value));
                return colorProperty != null ? colorProperty.Name : string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.Value.A, color.Value.R, color.Value.G, color.Value.B); 
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
