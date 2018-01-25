using System.Windows;

namespace NSUI.Controls
{
    public class NSButton : NSButtonBase
    {
        static NSButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSButton), new FrameworkPropertyMetadata(typeof(NSButton)));
        }
    }
}