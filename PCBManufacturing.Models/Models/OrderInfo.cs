using System;

namespace PCBManufacturing.Models
{
    public class OrderInfo : NotifyPropertyChangedModel
    {
        public int Id { get; set; }
        public int BoardsCount { get; set; }
        public int DaysRequired { get; set; }
        public double TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
