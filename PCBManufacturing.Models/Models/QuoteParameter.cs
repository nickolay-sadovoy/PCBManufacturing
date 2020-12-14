using System.Collections.ObjectModel;

namespace PCBManufacturing.Models
{
    public class QuoteParameter : NotifyPropertyChangedModel
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }
        public int DaysImpacted { get; set; }
        public double Cost { get; set; }
    }

    public class HeaderQuoteParameter : QuoteParameter
    {
        public ObservableCollection<QuoteParameter> Items { get; set; }
    }
}
