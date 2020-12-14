using PCBManufacturing.Models.Contracts;

namespace PCBManufacturing.ViewModels
{
    public class ExpandedItemViewModel : ViewModelBase, IExpandedItem
    {
        public bool IsExpanded { get; private set; } = true;

        public void Hide() => this.SetExpandedValue(false); 

        public void Show() => this.SetExpandedValue(true);

        private void SetExpandedValue(bool value)
        {
            this.IsExpanded = value;
            Notify(() => IsExpanded);

        }
    }
}
