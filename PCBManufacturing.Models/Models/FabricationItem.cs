using PCBManufacturing.Models.Enums;
using System.Collections.Generic;

namespace PCBManufacturing.Models.Models
{
    public class FabricationItem : CostItem
    {
        public string Name { get; set; }
        public List<CostItem> ValidValues { get; set; }
    }

    public class CostItem
    {
        public bool IsSelected { get; set; }
        public string Value { get; set; }
        public Ratio TimeRatio { get; set; }
        public Ratio CostRatio { get; set; }
    }
}
