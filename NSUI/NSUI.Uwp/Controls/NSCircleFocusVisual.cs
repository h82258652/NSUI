using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    public class NSCircleFocusVisual : Control, INSFocusVisual
    {
        private FrameworkElement _visualElement;

        public NSCircleFocusVisual()
        {
            DefaultStyleKey = typeof(NSCircleFocusVisual);
        }

        public void ShakeDown()
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

        public void ShakeLeft()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();

            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeRight()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
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
            animation.Duration = Constants.FocusVisualShakeDuration;
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild("PART_VisualElement");
        }
    }
}