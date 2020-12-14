using PCBManufacturing.Models;
using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Models;

namespace PCBManufacturing.ViewModels
{
    public class ProjectBasicsViewModel : NotifyPropertyChangedModel, ISaveable<PreferencesBasicsInfo>
    {
        public ProjectBasicsViewModel(PreferencesBasicsInfo basicsInfo = null)
        {
            if (basicsInfo != null)
            {
                this.ProjectName = basicsInfo.ProjectName;
                this.ZipCode = basicsInfo.ZipCode;
                this.BoardsQuantity = basicsInfo.BoardsQuantity;
            }
        }
        
        public string ProjectName { get; set; } = "BC0001";
        public string ZipCode { get; set; } = "92122";
        public int BoardsQuantity { get; set; } = 10;

        public PreferencesBasicsInfo Save()
        {
            return new PreferencesBasicsInfo()
            {
                BoardsQuantity = this.BoardsQuantity,
                ZipCode = this.ZipCode,
                ProjectName = this.ProjectName
            };
        }
    }
}
