using PCBManufacturing.Models;
using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Enums;
using PCBManufacturing.Models.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PCBManufacturing.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private OrderViewModel OrderVM = null;
        public MainViewModel()
        {
            this.MainItems = new ObservableCollection<IMainItem>();
            this.StatusVM = new StatusViewModel();
            this.PlaceOrderCommand = new RelayCommand(this.PlaceOrder);
            this.SaveAndContinueCommand = new RelayCommand(this.SaveAndContinue);
        }
        public ObservableCollection<IMainItem> MainItems { get; private set; }

        public StatusViewModel StatusVM { get; set; }
        public ISaveable<PreferencesInfo> SaveableVM { get; set; }
        public ICommand PlaceOrderCommand { get; private set; }
        public ICommand SaveAndContinueCommand { get; private set; }

        public bool IsSaveAndContinueButtonVisible { get; set; }

        private void PlaceOrder()
        {
            var preferences = new List<IMainItem>(this.MainItems.Where(x => x.Type == Models.Enums.MainItemType.Preferences));
            foreach (var pref in preferences)
                this.MainItems.Remove(pref);

            var preferencesViewModel = new PreferencesViewModel();
            SaveableVM = preferencesViewModel;
            this.MainItems.Insert(0, preferencesViewModel);

            IsSaveAndContinueButtonVisible = true;
            Notify(() => IsSaveAndContinueButtonVisible);
        }

        private void SaveAndContinue()
        {
            var preferences = this.MainItems.Where(x => x.Type == MainItemType.Preferences && x is IExpandedItem).Select(x=> x as IExpandedItem);
            foreach (var pref in preferences)
                pref.Hide();
            
            var preferenceInfo = SaveableVM.Save();

            var Quote = this.MainItems.FirstOrDefault(x => x.Type == Models.Enums.MainItemType.Quote);
            while (Quote != null)
            {
                this.MainItems.Remove(Quote);
                Quote = this.MainItems.FirstOrDefault(x => x.Type == Models.Enums.MainItemType.Quote);
            }

            var quoteVM = new QuoteViewModel(preferenceInfo);

            this.MainItems.Insert(1, quoteVM);
            
            if (this.OrderVM == null)
            {
                this.OrderVM = new OrderViewModel();
                this.MainItems.Insert(2, this.OrderVM);
            }
            
            var orderInfo = new OrderInfo()
            {
                BoardsCount = preferenceInfo.BasicsInfo.BoardsQuantity,
                DaysRequired = quoteVM.TotalDaysDuration,
                TotalCost = quoteVM.TotalCost,
            };

            this.StatusVM.UpdateStatus(orderInfo);
            this.OrderVM.SetDraft(orderInfo);

            this.IsSaveAndContinueButtonVisible = false;
            Notify(() => IsSaveAndContinueButtonVisible);
        }
    }
}
