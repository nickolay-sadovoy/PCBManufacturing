using PCBManufacturing.Models;
using PCBManufacturing.Models.Enums;

namespace PCBManufacturing.ViewModels
{
    public class StatusViewModel : ViewModelBase
    {
        public AutomationStatus Status { get; private set; } = AutomationStatus.Ok;
        public OrderInfo OrderInfo { get; private set; } = null;
        public void UpdateStatus(OrderInfo orderInfo)
        {
            OrderInfo = orderInfo;
            Notify(() => OrderInfo);
            //Notify(() => OrderInfo.BoardsCount);
            //Notify(() => OrderInfo.DaysRequired);
            //Notify(() => OrderInfo.TotalCost);
        }
    }
}
