using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    public class NSFocusVisual : Control, INSFocusVisual
    {
        private const double ShakeToValue = 8;

        private static readonly Duration ShakeDuration = TimeSpan.FromSeconds(0.3);

        public NSFocusVisual()
        {
            DefaultStyleKey = typeof(NSFocusVisual);
        }

        public void ShakeDown()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = ShakeToValue;
            animation.Duration = ShakeDuration;
            animation.EasingFunction = new BackEase()
            {
            };
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
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }

        public void ShakeUp()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
            animation.From = 0;
            storyboard.Children.Add(animation);
            storyboard.Begin();

            // TODO
        }
    }
}