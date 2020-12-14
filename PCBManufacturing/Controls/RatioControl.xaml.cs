using PCBManufacturing.Models.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCBManufacturing.Controls
{
    /// <summary>
    /// Interaction logic for RatioControl.xaml
    /// </summary>
    public partial class RatioControl : UserControl
    {
        public RatioControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty RatioProperty =
                               DependencyProperty.Register("Ratio", typeof(Ratio), typeof(RatioControl),
                               new FrameworkPropertyMetadata(Ratio.None,
                                     FrameworkPropertyMetadataOptions.AffectsRender |
                                     FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        public Ratio Ratio
        {
            get { return (Ratio)GetValue(RatioProperty); }
            set { SetValue(RatioProperty, value); }
        }
        
        public static readonly DependencyProperty FillBrushProperty =
                               DependencyProperty.Register("FillBrush", typeof(SolidColorBrush), typeof(RatioControl),
                               new FrameworkPropertyMetadata(null,
                                     FrameworkPropertyMetadataOptions.AffectsRender |
                                     FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        public SolidColorBrush FillBrush
        {
            get { return (SolidColorBrush)GetValue(FillBrushProperty); }
            set { SetValue(FillBrushProperty, value); }
        }
    }
}
