using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSPage : Page
    {
        static NSPage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSPage), new FrameworkPropertyMetadata(typeof(NSPage)));
        }
    }
}