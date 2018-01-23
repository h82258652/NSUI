using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NSUI.Controls
{
    public class NSCircleFocusVisual : Control
    {
        static NSCircleFocusVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSCircleFocusVisual), new FrameworkPropertyMetadata(typeof(NSCircleFocusVisual)));
        }

        public void ShakeDown()
        {
            var storyboard = new Storyboard();


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