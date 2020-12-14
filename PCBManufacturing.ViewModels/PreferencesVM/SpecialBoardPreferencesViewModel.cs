using PCBManufacturing.Models.Enums;
using PCBManufacturing.Models;
using System.Windows.Media;
using PCBManufacturing.Models.Models;
using PCBManufacturing.Models.Contracts;

namespace PCBManufacturing.ViewModels
{
    public class SpecialBoardPreferencesViewModel : NotifyPropertyChangedModel, ISaveable<SpecialBoardPreferencesInfo>
    {
        public SpecialBoardPreferencesViewModel(SpecialBoardPreferencesInfo specialBoardInfo)
        {
            if(specialBoardInfo != null)
            {
                this.Notes = specialBoardInfo.Notes;
                this.LeadFreeSelected = specialBoardInfo.LeadFreeSelected;
                this.ItarSelected = specialBoardInfo.ItarSelected;
                this.IPCClassSelected = specialBoardInfo.IPCClassSelected;
                this.FluxTypeSelected = specialBoardInfo.FluxTypeSelected;
                this.ControlledImpadanceSelected = specialBoardInfo.ControlledImpadanceSelected;
                this.CooperWeightInnerSelected = specialBoardInfo.CooperWeightInnerSelected;
                this.CooperWeightOuterSelected = specialBoardInfo.CooperWeightOuterSelected;
                this.TentingViasSelected = specialBoardInfo.TentingViasSelected;
                this.StackupSelected = specialBoardInfo.StackupSelected;
                this.SdkscreenColorSelected = specialBoardInfo.SdkscreenColorSelected;
            }
        }

        public LeadFree LeadFreeSelected { get; set; } = LeadFree.Yes;
        public IPCClassItem IPCClassSelected { get; set; } = IPCClassItem.Class2;
        public ItarItem ItarSelected { get; set; } = ItarItem.No;
        public FluxTypeItem FluxTypeSelected { get; set; } = FluxTypeItem.NoClean;
        public CooperWeightItem CooperWeightInnerSelected { get; set; } = CooperWeightItem.Low;
        public CooperWeightItem CooperWeightOuterSelected { get; set; } = CooperWeightItem.Medium;
        public ControlledImpadanceItem ControlledImpadanceSelected { get; set; } = ControlledImpadanceItem.None;
        public TentingViasItem TentingViasSelected { get; set; } = TentingViasItem.None;
        public StackupItem StackupSelected { get; set; } = StackupItem.Standard;
        public Color SdkscreenColorSelected { get; set; } = Colors.White;
        public string Notes { get; set; }

        public SpecialBoardPreferencesInfo Save()
        {
            return new SpecialBoardPreferencesInfo()
            {
                ControlledImpadanceSelected = this.ControlledImpadanceSelected,
                CooperWeightOuterSelected = this.CooperWeightOuterSelected,
                CooperWeightInnerSelected = this.CooperWeightInnerSelected,
                FluxTypeSelected = this.FluxTypeSelected,
                StackupSelected = this.StackupSelected,
                IPCClassSelected = this.IPCClassSelected,
                ItarSelected = this.ItarSelected,
                LeadFreeSelected = this.LeadFreeSelected,
                Notes = this.Notes,
                SdkscreenColorSelected = this.SdkscreenColorSelected,
                TentingViasSelected = this.TentingViasSelected
            };
        }
    }
}
