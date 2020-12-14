using PCBManufacturing.Models;
using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Enums;
using PCBManufacturing.Models.Models;
using System.Windows.Media;

namespace PCBManufacturing.ViewModels
{
    public class ImportantBoardPreferencesViewModel : NotifyPropertyChangedModel, ISaveable<ImportantBoardPreferencesInfo>
    {
        public ImportantBoardPreferencesViewModel(ImportantBoardPreferencesInfo importantBoardInfo = null)
        {
            if (importantBoardInfo != null)
            {
                this.BoardThinkness = importantBoardInfo.BoardThinkness;
                this.MaterialSelected = importantBoardInfo.MaterialSelected;
                this.SurfaceFinishSelected = importantBoardInfo.SurfaceFinishSelected;
                this.SolidMaskColorSelected = importantBoardInfo.SolidMaskColorSelected;
            }
        }

        public string BoardThinkness { get; set; } = "1.57mm";

        private MaterialItem materialSelected { get; set; } = MaterialItem.Material1;
        public MaterialItem MaterialSelected
        {
            get
            {
                return this.materialSelected;
            }
            set
            {
                this.materialSelected = value;
                UpdateAdditionalsMaterials();
            }
        }

        private SurfaceFinishItem surfaceFinishSelected { get; set; } = SurfaceFinishItem.EasySurface;
        public SurfaceFinishItem SurfaceFinishSelected
        {
            get
            {
                return this.surfaceFinishSelected;
            }
            set
            {
                this.surfaceFinishSelected = value;
                UpdateAdditionalsSurfaceFinish();
            }
        }

        public Color SolidMaskColorSelected { get; set; } = Colors.Green;

        public int AdditionalDaysSurfaceFinish { get; private set; } = 0;
        public int AdditionalMaterialCost { get; private set; } = 0;
        public int AdditionalSurfaceCost { get; private set; } = 0;


        private void UpdateAdditionalsSurfaceFinish()
        {
            switch (SurfaceFinishSelected)
            {
                case SurfaceFinishItem.EasySurface:
                    AdditionalDaysSurfaceFinish = 0;
                    AdditionalSurfaceCost = 453;
                    break;
                case SurfaceFinishItem.OneDaySurface:
                    AdditionalDaysSurfaceFinish = 1;
                    AdditionalSurfaceCost = 2553;
                    break;
                case SurfaceFinishItem.DifficaltSurface:
                    AdditionalDaysSurfaceFinish = 3;
                    AdditionalSurfaceCost = 3753;
                    break;
            }

            Notify(() => AdditionalDaysSurfaceFinish);
            Notify(() => AdditionalSurfaceCost);
        }
        
        private void UpdateAdditionalsMaterials()
        {
            switch (materialSelected)
            {
                case MaterialItem.Material1:
                    AdditionalMaterialCost = 369;
                    break;
                case MaterialItem.Material2:
                    AdditionalMaterialCost = 840;
                    break;
                case MaterialItem.Material3:
                    AdditionalMaterialCost = 2213;
                    break;
            }

            Notify(() => AdditionalMaterialCost);
        }

        public ImportantBoardPreferencesInfo Save()
        {
            return new ImportantBoardPreferencesInfo()
            {
                AdditionalDaysSurfaceFinish = this.AdditionalDaysSurfaceFinish,
                AdditionalMaterialCost = this.AdditionalMaterialCost,
                AdditionalSurfaceCost = this.AdditionalSurfaceCost,
                BoardThinkness = this.BoardThinkness,
                MaterialSelected = this.MaterialSelected,
                SolidMaskColorSelected = this.SolidMaskColorSelected,
                SurfaceFinishSelected = this.SurfaceFinishSelected,
            };
        }
    }
}
