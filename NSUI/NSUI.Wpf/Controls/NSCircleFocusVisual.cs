using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NSUI.Controls
{
    [TemplatePart(Name = VisualElementTemplateName, Type = typeof(FrameworkElement))]
    public class NSCircleFocusVisual : Control, INSFocusVisual
    {
        private const string VisualElementTemplateName = "PART_VisualElement";

        private FrameworkElement _visualElement;

        static NSCircleFocusVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSCircleFocusVisual), new FrameworkPropertyMetadata(typeof(NSCircleFocusVisual)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild(VisualElementTemplateName);
            Debug.Assert(_visualElement != null);
            ((Storyboard)_visualElement.Resources["VisualBrushStoryboard"]).Begin();
        }

        public void ShakeDown()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = Constants.FocusVisualShakeToValue,
                Duration = Constants.FocusVisualShakeDuration
            };
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeLeft()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            storyboard.Begin();

            // TODO
        }

        public void ShakeRight()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0
            };
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeUp()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }
    }
}