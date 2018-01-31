using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSTextBox : TextBox
    {
        static NSTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSTextBox), new FrameworkPropertyMetadata(typeof(NSTextBox)));
        }
    }
}