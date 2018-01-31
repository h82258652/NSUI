using System.Windows;

namespace NSUI.Controls
{
    public class NSCircleFocusVisual : NSFocusVisualBase
    {
        static NSCircleFocusVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSCircleFocusVisual), new FrameworkPropertyMetadata(typeof(NSCircleFocusVisual)));
        }
    }
}