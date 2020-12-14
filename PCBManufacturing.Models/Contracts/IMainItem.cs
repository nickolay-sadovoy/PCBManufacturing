using PCBManufacturing.Models.Enums;

namespace PCBManufacturing.Models.Contracts
{
    public interface IMainItem : IViewModel
    {
        MainItemType Type { get; }
    }
}
