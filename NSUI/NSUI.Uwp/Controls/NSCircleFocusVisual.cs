using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    public class NSCircleFocusVisual : Control, INSFocusVisual
    {
        public NSCircleFocusVisual()
        {
            DefaultStyleKey = typeof(NSCircleFocusVisual);
        }

        public void ShakeDown()
        {
            var storyboard = new Storyboard();

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
            // TODO
        }

        public void ShakeUp()
        {
            // TODO
        }
    }
}