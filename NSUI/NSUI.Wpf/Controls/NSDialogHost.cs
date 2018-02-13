using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSDialogHost : ContentControl
    {
        static NSDialogHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSDialogHost), new FrameworkPropertyMetadata(typeof(NSDialogHost)));
        }
    }
}