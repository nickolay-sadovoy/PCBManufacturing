using PCBManufacturing.Models;
using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PCBManufacturing.ViewModels
{
    public class OrderViewModel : ExpandedItemViewModel, IMainItem
    {
        private OrderInfo orderDraft = null;
        public OrderViewModel()
        {
            this.MakeCurrentOrderCommand = new RelayCommand(MakeAnOrder);
            this.Orders = new ObservableCollection<OrderInfo>();
        }
        public MainItemType Type => MainItemType.Order;
        public bool IsOrdersEmpty => Orders.Count == 0;
        public bool AnyOrdersExist => Orders.Count != 0;

        public ObservableCollection<OrderInfo> Orders { get; private set; }
        public ICommand MakeCurrentOrderCommand { get; private set; }

        public void SetDraft(OrderInfo orderInfo)
        {
            this.orderDraft = orderInfo;
            this.orderDraft.CreatedDate = DateTime.Now;
        }

        private void MakeAnOrder()
        {
            this.orderDraft.Id = this.Orders.Count() + 1;
            this.Orders.Add(orderDraft);
            this.orderDraft = null;
            Notify(() => this.IsOrdersEmpty);
            Notify(() => this.AnyOrdersExist);
        }
    }
}
