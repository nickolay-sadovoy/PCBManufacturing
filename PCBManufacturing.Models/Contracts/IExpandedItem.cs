namespace PCBManufacturing.Models.Contracts
{
    public interface IExpandedItem
    {
        void Hide();
        void Show();
        bool IsExpanded { get; }
    }
}
