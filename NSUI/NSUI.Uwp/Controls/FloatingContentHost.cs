using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace NSUI.Controls
{
    [ContentProperty(Name = nameof(Content))]
    public class FloatingContentHost : FrameworkElement
    {
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(nameof(Content), typeof(UIElement), typeof(FloatingContentHost), new PropertyMetadata(default(UIElement)));

        public UIElement Content
        {
            get
            {
                return (UIElement)GetValue(ContentProperty);
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }
    }
}