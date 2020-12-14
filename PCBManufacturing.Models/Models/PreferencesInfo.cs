using PCBManufacturing.Models.Enums;
using System.Windows.Media;

namespace PCBManufacturing.Models.Models
{
    public class PreferencesInfo
    {
        public PreferencesBasicsInfo BasicsInfo { get; set; }
        public SpecialBoardPreferencesInfo SpecialBoardInfo { get; set; }
        public ImportantBoardPreferencesInfo ImportantBoardInfo { get; set; }

    }

    public class PreferencesBasicsInfo
    {
        public string ProjectName { get; set; }
        public string ZipCode { get; set; }
        public int BoardsQuantity { get; set; }

    }

    public class SpecialBoardPreferencesInfo
    {
        public LeadFree LeadFreeSelected { get; set; }
        public IPCClassItem IPCClassSelected { get; set; }
        public ItarItem ItarSelected { get; set; }
        public FluxTypeItem FluxTypeSelected { get; set; }
        public CooperWeightItem CooperWeightInnerSelected { get; set; }
        public CooperWeightItem CooperWeightOuterSelected { get; set; }
        public ControlledImpadanceItem ControlledImpadanceSelected { get; set; }
        public TentingViasItem TentingViasSelected { get; set; }
        public StackupItem StackupSelected { get; set; }
        public Color SdkscreenColorSelected { get; set; }
        public string Notes { get; set; }
    }

    public class ImportantBoardPreferencesInfo
    {
        public string BoardThinkness { get; set; }

        public MaterialItem MaterialSelected { get; set; }

        public SurfaceFinishItem SurfaceFinishSelected { get; set; }

        public Color SolidMaskColorSelected { get; set; }

        public int AdditionalDaysSurfaceFinish { get; set; }
        public int AdditionalMaterialCost { get; set; }
        public int AdditionalSurfaceCost { get; set; }
    }
}
