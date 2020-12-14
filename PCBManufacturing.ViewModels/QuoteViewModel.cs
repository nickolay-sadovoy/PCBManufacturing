using PCBManufacturing.Models;
using PCBManufacturing.Models.Contracts;
using PCBManufacturing.Models.Enums;
using PCBManufacturing.Models.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PCBManufacturing.ViewModels
{
    public class QuoteViewModel : ExpandedItemViewModel, IMainItem
    {
        public QuoteViewModel(PreferencesInfo preferenceInfo = null)
        {
            CalculateQuote(preferenceInfo);
        }
        public MainItemType Type => MainItemType.Quote;

        public double FabricationPercent { get; private set; } 
        public double AssemblyPercent { get; private set; }
        public double ComponentsPercent { get; private set; }
        public ObservableCollection<HeaderQuoteParameter> HeaderQuoteParameters { get; set; } = new ObservableCollection<HeaderQuoteParameter>();
        public ObservableCollection<FabricationItem> FabricationList { get; set; } = new ObservableCollection<FabricationItem>();

        public double TotalCost { get; private set; }
        public int TotalDaysDuration { get; private set; }
        public double FabricationCost { get; private set; }
        public double AssemblyCost { get; private set; }
        public double ComponentsCost { get; private set; }

        private void CalculateQuote(PreferencesInfo preferenceInfo)
        {

            // do calculation and update results

            this.FabricationPercent = 25;
            this.AssemblyPercent = 65;
            this.ComponentsPercent = 10;

            this.TotalCost = 776214.64;
            this.TotalDaysDuration = 5;
            this.FabricationCost = 1710000.00;
            this.AssemblyCost = 4995.00;
            this.ComponentsCost = 957.00;

            var fabricationItemList = new List<FabricationItem>()
            {
                new FabricationItem()
                {
                    Name = nameof(preferenceInfo.ImportantBoardInfo.BoardThinkness),
                    Value = preferenceInfo.ImportantBoardInfo.BoardThinkness,
                    TimeRatio = Ratio.One,
                    CostRatio = Ratio.Three
                },

                new FabricationItem()
                {
                    Name = nameof(preferenceInfo.ImportantBoardInfo.MaterialSelected),
                    Value = preferenceInfo.ImportantBoardInfo.MaterialSelected.ToString(),
                    TimeRatio = Ratio.Two,
                    CostRatio = Ratio.Four
                },new FabricationItem()
                {
                    Name = nameof(preferenceInfo.ImportantBoardInfo.SolidMaskColorSelected),
                    Value = preferenceInfo.ImportantBoardInfo.SolidMaskColorSelected.ToString(),
                    TimeRatio = Ratio.Three,
                    CostRatio = Ratio.Five
                },new FabricationItem()
                {
                    Name = nameof(preferenceInfo.ImportantBoardInfo.SurfaceFinishSelected),
                    Value = preferenceInfo.ImportantBoardInfo.SurfaceFinishSelected.ToString(),
                    TimeRatio = Ratio.Five,
                    CostRatio = Ratio.One
                },new FabricationItem()
                {
                    Name = nameof(preferenceInfo.SpecialBoardInfo.ControlledImpadanceSelected),
                    Value = preferenceInfo.SpecialBoardInfo.ControlledImpadanceSelected.ToString(),
                    TimeRatio = Ratio.Two,
                    CostRatio = Ratio.Two
                },new FabricationItem()
                {
                    Name = nameof(preferenceInfo.SpecialBoardInfo.CooperWeightInnerSelected),
                    Value = preferenceInfo.SpecialBoardInfo.CooperWeightInnerSelected.ToString(),
                    TimeRatio = Ratio.One,
                    CostRatio = Ratio.Three
                },new FabricationItem()
                {
                    Name = nameof(preferenceInfo.SpecialBoardInfo.CooperWeightOuterSelected),
                    Value = preferenceInfo.SpecialBoardInfo.CooperWeightOuterSelected.ToString(),
                    TimeRatio = Ratio.Five,
                    CostRatio = Ratio.Four
                },
            };

            foreach (var item in fabricationItemList)
            {
                item.ValidValues = GetValidValues(item.Name);
                FabricationList.Add(item);
            }
            var headerQuoteParametersList = new List<HeaderQuoteParameter>()
            {
                new HeaderQuoteParameter()
                {
                    ParameterName = "Fabrication",
                    DaysImpacted = 4,
                    Cost = 1710.00,
                    Items = new ObservableCollection<QuoteParameter>()
                    {
                        new QuoteParameter()
                        {
                            ParameterName = "Base Fabrication",
                            Value = "61.72x148.84mm 10 levels",
                            DaysImpacted = 1,
                            Cost = 10970.00
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Boards Quantity",
                            Value = "20",
                            DaysImpacted = 0,
                            Cost = 538.00
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Surface Finish",
                            Value = "ENEPIG",
                            DaysImpacted = 3,
                            Cost = 25.00
                        }
                    }
                },
                new HeaderQuoteParameter()
                {
                    ParameterName = "Assembly",
                    DaysImpacted = 1,
                    Cost = 4955.50,
                    Items = new ObservableCollection<QuoteParameter>()
                    {
                        new QuoteParameter()
                        {
                            ParameterName = "Packages",
                            Value = "package on Packages",
                            DaysImpacted = 1,
                            Cost = 2679.00
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Processes",
                            Value = "Split Assemply",
                            DaysImpacted = 0,
                            Cost = 720.50
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Minimum Pich",
                            Value = "0.3mm pitch BGA",
                            DaysImpacted = 0,
                            Cost = 804.00
                        }
                    }
                },
                new HeaderQuoteParameter()
                {
                    ParameterName = "Components",
                    DaysImpacted = 0,
                    Cost = 957.50,
                    Items = new ObservableCollection<QuoteParameter>()
                    {
                        new QuoteParameter()
                        {
                            ParameterName = "Microchip ATTIMNY2313-2DSU",
                            Value = "2",
                            DaysImpacted = 0,
                            Cost = 48.64
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Microchip ATTIMNY2313-18PC",
                            Value = "1",
                            DaysImpacted = 0,
                            Cost = 20000
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Microchip ATTIMNY2313-19PC",
                            Value = "1",
                            DaysImpacted = 0,
                            Cost = 30000
                        },
                        new QuoteParameter()
                        {
                            ParameterName = "Microchip ATTIMNY2313-6785",
                            Value = "3",
                            DaysImpacted = 0,
                            Cost = 40000
                        }
                    }
                }
            };

            foreach (var item in headerQuoteParametersList)
                HeaderQuoteParameters.Add(item);

            Notify(() => this.FabricationPercent);
            Notify(() => this.AssemblyPercent);
            Notify(() => this.ComponentsPercent);
            Notify(() => this.TotalCost);
            Notify(() => this.TotalDaysDuration);
            Notify(() => this.FabricationCost);
            Notify(() => this.AssemblyCost);
            Notify(() => this.ComponentsCost);
        }

        private List<CostItem> GetValidValues(string propertyName)
        {
            //calculation

            return new List<CostItem>()
            {
                new CostItem()
                {
                    IsSelected = false,
                    Value = "up to 8",
                    CostRatio = Ratio.One,
                    TimeRatio = Ratio.One,
                },
                new CostItem()
                {
                    IsSelected = true,
                    Value = "up to 18",
                    CostRatio = Ratio.Two,
                    TimeRatio = Ratio.Two,
                },
                new CostItem()
                {
                    IsSelected = false,
                    Value = "18 - 64",
                    CostRatio = Ratio.Three,
                    TimeRatio = Ratio.Three,
                }
            };
        }
    }
}
