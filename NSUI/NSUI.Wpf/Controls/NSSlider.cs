using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSSlider : Slider
    {
        static NSSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSSlider), new FrameworkPropertyMetadata(typeof(NSSlider)));
        }
    }
}