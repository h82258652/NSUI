using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace NSUI.Sample.Views
{
    [ContentProperty("Child")]
    public class XxHost : FrameworkElement
    {
        public XxHost()
        {
        }

        public static readonly DependencyProperty ChildProperty = DependencyProperty.Register(
            "Child", typeof(UIElement), typeof(XxHost), new PropertyMetadata(default(UIElement), Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var child = e.NewValue as UIElement;
            XxHost obj = d as XxHost;

            obj.RemoveVisualChild(e.OldValue as Visual);
            obj.AddVisualChild(child);

            obj.InvalidateVisual();
        }

        protected override Visual GetVisualChild(int index)
        {
            return Child;
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        public UIElement Child
        {
            get { return (UIElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Child?.Measure(availableSize);

            //if (Child != null)
            //{
            //     Child.Measure(availableSize);
            //    var width = availableSize.Width;
            //    var height = availableSize.Height;
            //    if (double.IsInfinity(width))
            //    {
            //        width = 0;
            //    }
            //    if (double.IsInfinity(height))
            //    {
            //        height = 0;
            //    }
            //    return new Size(width, height);
            //}

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0 - finalSize.Width / 2;

            double y = 0 - finalSize.Height / 2;

            var elementWidth = finalSize.Width > 0 ? finalSize.Width : Child.DesiredSize.Width;
            var elementHeight = finalSize.Height > 0 ? finalSize.Height : Child.DesiredSize.Height;

            Child .Arrange(new Rect(new Point(x, y), new Size(elementWidth, elementHeight)));
            return new Size(0, 0);
        }
    }
}