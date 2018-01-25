using System.Windows;

namespace NSUI.Controls
{
    public class NSActionBarButton : NSButton
    {
        static NSActionBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSActionBarButton), new FrameworkPropertyMetadata(typeof(NSActionBarButton)));
        }
    }
}