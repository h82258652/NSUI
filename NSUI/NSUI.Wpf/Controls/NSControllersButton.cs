using System.Windows;

namespace NSUI.Controls
{
    public class NSControllersButton : NSCircleButton
    {
        static NSControllersButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSControllersButton), new FrameworkPropertyMetadata(typeof(NSControllersButton)));
        }
    }
}