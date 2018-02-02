using System.Windows;

namespace NSUI.Controls
{
    public class NSCircleButton : NSButtonBase
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(NSCircleButton), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(NSCircleButton), new PropertyMetadata(default(double)));

        static NSCircleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSCircleButton), new FrameworkPropertyMetadata(typeof(NSCircleButton)));
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
    }
}