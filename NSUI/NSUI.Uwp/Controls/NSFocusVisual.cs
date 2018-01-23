using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    public class NSFocusVisual : Control
    {
        public NSFocusVisual()
        {
            DefaultStyleKey = typeof(NSFocusVisual);
        }

        private const double ShakeToValue = 8;

        private static readonly Duration ShakeDuration = TimeSpan.FromSeconds(0.3);

        public void ShakeDown()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animation  = new DoubleAnimation();
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
            // TODO
        }

        public void ShakeRight()
        {
            // TODO
        }

        public void ShakeUp()
        {
            // TODO
        }
    }
}