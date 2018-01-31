using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSScrollViewer : ScrollViewer
    {
        static NSScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSScrollViewer), new FrameworkPropertyMetadata(typeof(NSScrollViewer)));
        }
    }
}