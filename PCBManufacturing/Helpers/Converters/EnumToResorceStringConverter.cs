using PCBManufacturing.Models.Enums;
using PCBManufacturing.Properties;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PCBManufacturing.Helpers.Converters
{
    public class EnumToResorceStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resourcaName = string.Empty;
            if (value is IPCClassItem)
                resourcaName = GetResourceName<IPCClassItem>(value); 
            else if (value is TentingViasItem)
                resourcaName = GetResourceName<TentingViasItem>(value);
            else if(value is LeadFree)
                resourcaName = GetResourceName<LeadFree>(value);
            else if(value is ControlledImpadanceItem)
                resourcaName = GetResourceName<ControlledImpadanceItem>(value);
            else if(value is StackupItem)
                resourcaName = GetResourceName<StackupItem>(value);
            else if(value is SurfaceFinishItem)
                resourcaName = GetResourceName<SurfaceFinishItem>(value);            
            else if(value is ItarItem)
                resourcaName = GetResourceName<ItarItem>(value);           
            else if(value is FluxTypeItem)
                resourcaName = GetResourceName<FluxTypeItem>(value);

            if (!string.IsNullOrEmpty(resourcaName))
            {
                string resourceString = null;
                try
                {
                    resourceString = typeof(Resources).GetProperty(resourcaName).GetValue(null) as string;
                }
                catch (Exception) { }

                if (!string.IsNullOrEmpty(resourceString))
                    return resourceString;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetResourceName<T>(object value) where T: Enum => $"Enum_{typeof(T).Name}_{Enum.Parse(typeof(T), value.ToString())}"; 
    }
}
