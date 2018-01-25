using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    [TemplatePart(Name = VisualElementTemplateName, Type = typeof(FrameworkElement))]
    public class NSFocusVisual : Control, INSFocusVisual
    {
        private const string VisualElementTemplateName = "PART_VisualElement";

        private FrameworkElement _visualElement;

        public NSFocusVisual()
        {
            DefaultStyleKey = typeof(NSFocusVisual);
        }

        public void ShakeDown()
        {
            var storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = Constants.FocusVisualShakeToValue;
            animation.Duration = Constants.FocusVisualShakeDuration;

            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeLeft()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
            animation.From = 0;
            Storyboard.SetTarget(animation, null);
            Storyboard.SetTargetProperty(animation, null);
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeRight()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = Constants.FocusVisualShakeToValue;
            animation.Duration = Constants.FocusVisualShakeDuration;
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeUp()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 0 - Constants.FocusVisualShakeToValue;
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild(VisualElementTemplateName);
            Debug.Assert(_visualElement != null);
            ((Storyboard)_visualElement.Resources["VisualBrushStoryboard"]).Begin();
        }
    }
}