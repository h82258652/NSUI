using System.Windows;

namespace NSUI.Controls
{
    public class NSNewsButton : NSCircleButton
    {
        static NSNewsButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSNewsButton), new FrameworkPropertyMetadata(typeof(NSNewsButton)));
        }
    }
}