using PCBManufacturing.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace PCBManufacturing.Models
{
    public class EnumValues
    {
        public List<IPCClassItem> IPCClassList { get; private set; }
        public List<TentingViasItem> TentingViasList { get; private set; }
        public List<LeadFree> LeadFreeList { get; private set; }
        public List<SurfaceFinishItem> SurfaceFinishList { get; private set; }
        public List<ControlledImpadanceItem> ControlledImpadanceList { get; private set; }
        public List<FluxTypeItem> FluxTypeList { get; private set; }
        public List<ItarItem> ItarList { get; private set; }
        public List<StackupItem> StackupList { get; private set; }
        public List<MaterialItem> MaterialList { get; private set; }
        public List<CooperWeightItem> CooperWeightList { get; private set; }
        public IEnumerable<Color> ColorList { get; private set; }

        public EnumValues()
        {
            SurfaceFinishList = InitializeEnumList<SurfaceFinishItem>();
            LeadFreeList = InitializeEnumList<LeadFree>();
            IPCClassList = InitializeEnumList<IPCClassItem>();
            TentingViasList = InitializeEnumList<TentingViasItem>();
            ControlledImpadanceList = InitializeEnumList<ControlledImpadanceItem>();
            FluxTypeList = InitializeEnumList<FluxTypeItem>();
            ItarList = InitializeEnumList<ItarItem>();
            StackupList = InitializeEnumList<StackupItem>();
            MaterialList = InitializeEnumList<MaterialItem>();
            CooperWeightList = InitializeEnumList<CooperWeightItem>();
            InitializeColorList();
        }

        private List<T> InitializeEnumList<T>() where T : Enum
        {

            var values = Enum.GetValues(typeof(T));
            var newList = new List<T>();

            foreach (T value in values)
            {
                newList.Add(value);
            }

            return newList;
        }

        private void InitializeColorList()
        {
            ColorList = typeof(Colors)
                    .GetProperties()
                    .Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
                    .Select(prop => (Color)prop.GetValue(prop.Name));
        }

    }
}
