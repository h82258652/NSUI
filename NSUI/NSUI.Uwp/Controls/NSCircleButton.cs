using Windows.UI.Xaml;

namespace NSUI.Controls
{
    public class NSCircleButton : NSButtonBase
    {
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(NSCircleButton), new PropertyMetadata(default(double)));

        public NSCircleButton()
        {
            DefaultStyleKey = typeof(NSCircleButton);
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
    }
}