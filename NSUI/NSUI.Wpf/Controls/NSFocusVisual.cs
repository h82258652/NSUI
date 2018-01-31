using System.Windows;

namespace NSUI.Controls
{
    public class NSFocusVisual : NSFocusVisualBase
    {
        static NSFocusVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSFocusVisual), new FrameworkPropertyMetadata(typeof(NSFocusVisual)));
        }
    }
}