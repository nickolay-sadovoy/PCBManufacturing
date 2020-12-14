using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Enums;
using System.Windows;
using System.Windows.Controls;

namespace PCBManufacturing.Helpers.DataSelectors
{
    public class MainItemsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PreferencesTemplate { get; set; }
        public DataTemplate QuoteTemplate { get; set; }
        public DataTemplate OrderTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dataTemplate = null;
            var mainItem = item as IMainItem;
            if (mainItem != null)
                switch (mainItem.Type)
                {
                    case MainItemType.Preferences:
                        dataTemplate = PreferencesTemplate;
                        break;
                    case MainItemType.Quote:
                        dataTemplate = QuoteTemplate;
                        break;
                    case MainItemType.Order:
                        dataTemplate = OrderTemplate;
                        break;
                    default:
                        break;
                }

            return dataTemplate;
        }
    }
}
