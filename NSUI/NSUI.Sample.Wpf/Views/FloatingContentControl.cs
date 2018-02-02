using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NSUI.Sample.Views
{
    public class FloatingContentControl : ContentControl
    {
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            var childCount = VisualTreeHelper.GetChildrenCount(this);
            if (childCount > 0)
            {
                var child = VisualTreeHelper.GetChild(this, 0) as UIElement;
                if (child != null)
                {
                    var x = 0 - arrangeBounds.Width / 2;
                    var y = 0 - arrangeBounds.Height / 2;
                    var width = arrangeBounds.Width > 0 ? arrangeBounds.Width : child.DesiredSize.Width;
                    var height = arrangeBounds.Height > 0 ? arrangeBounds.Height : child.DesiredSize.Height;
                    child.Arrange(new Rect(new Point(x, y), new Size(width, height)));
                }
            }
            return new Size(0, 0);
        }
    }
}