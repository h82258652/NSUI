using System.Windows;
using System.Windows.Input;

namespace NSUI.Controls
{
    [TemplatePart(Name = FocusVisualTemplateName, Type = typeof(NSCircleFocusVisual))]
    public class NSCircleButton : NSButtonBase
    {
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(NSCircleButton), new PropertyMetadata(default(double)));

        private const string FocusVisualTemplateName = "PART_FocusVisual";

        private INSFocusVisual _focusVisual;

        static NSCircleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSCircleButton), new FrameworkPropertyMetadata(typeof(NSCircleButton)));
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _focusVisual = (INSFocusVisual)GetTemplateChild(FocusVisualTemplateName);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (_focusVisual == null)
            {
                return;
            }

            var key = e.Key;
            if (key == Key.Left)
            {
                var leftFocusableElement = PredictFocus(FocusNavigationDirection.Left);
                if (leftFocusableElement == null || ReferenceEquals(this, leftFocusableElement))
                {
                    _focusVisual.ShakeLeft();
                }
            }
            else if (key == Key.Up)
            {
                var upFocusableElement = PredictFocus(FocusNavigationDirection.Up);
                if (upFocusableElement == null || ReferenceEquals(this, upFocusableElement))
                {
                    _focusVisual.ShakeUp();
                }
            }
            else if (key == Key.Right)
            {
                var rightFocusableElement = PredictFocus(FocusNavigationDirection.Right);
                if (rightFocusableElement == null || ReferenceEquals(this, rightFocusableElement))
                {
                    _focusVisual.ShakeRight();
                }
            }
            else if (key == Key.Down)
            {
                var downFocusableElement = PredictFocus(FocusNavigationDirection.Down);
                if (downFocusableElement == null || ReferenceEquals(this, downFocusableElement))
                {
                    _focusVisual.ShakeDown();
                }
            }
        }
    }
}