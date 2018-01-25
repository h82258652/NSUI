using System.Windows;

namespace NSUI.Controls
{
    public class NSCircleButton : NSButtonBase
    {
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(NSCircleButton), new PropertyMetadata(default(double)));

        static NSCircleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSCircleButton), new FrameworkPropertyMetadata(typeof(NSCircleButton)));
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
    }
}