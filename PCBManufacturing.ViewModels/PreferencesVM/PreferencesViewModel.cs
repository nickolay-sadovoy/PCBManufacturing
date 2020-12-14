using PCBManufacturing.Models;
using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Enums;
using PCBManufacturing.Models.Models;

namespace PCBManufacturing.ViewModels
{
    public class PreferencesViewModel : ExpandedItemViewModel, IMainItem, ISaveable<PreferencesInfo>
    {
        public PreferencesViewModel(PreferencesInfo preferencesInfo = null)
        {
            this.EnumLists = new EnumValues();
            this.ProjectBasicsVM = new ProjectBasicsViewModel(preferencesInfo?.BasicsInfo);
            this.ImportantBoardPreferencesVM = new ImportantBoardPreferencesViewModel(preferencesInfo?.ImportantBoardInfo);
            this.SpecialBoardPreferencesVM = new SpecialBoardPreferencesViewModel(preferencesInfo?.SpecialBoardInfo);
        }

        public EnumValues EnumLists { get; }
        public ImportantBoardPreferencesViewModel ImportantBoardPreferencesVM { get; }
        public ProjectBasicsViewModel ProjectBasicsVM { get; }
        public SpecialBoardPreferencesViewModel SpecialBoardPreferencesVM { get; }

        public MainItemType Type => MainItemType.Preferences;

        public PreferencesInfo Save()
        {
            return new PreferencesInfo()
            {
                BasicsInfo = this.ProjectBasicsVM.Save(),
                ImportantBoardInfo = this.ImportantBoardPreferencesVM.Save(),
                SpecialBoardInfo = this.SpecialBoardPreferencesVM.Save()
            };
        }

    }
}
