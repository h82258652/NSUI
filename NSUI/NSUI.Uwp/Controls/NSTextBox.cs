using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NSUI.Controls
{
    [TemplatePart(Name = BorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = LimitTextBlockTemplateName, Type = typeof(TextBlock))]
    public class NSTextBox : TextBox
    {
        private const string BorderTemplateName = "PART_Border";
        private const string LimitTextBlockTemplateName = "PART_LimitTextBlock";

        private long _acceptsReturnCallbackToken;

        private Border _border;
        private TextBlock _limitTextBlock;

        private long _maxLengthCallbackToken;

        public NSTextBox()
        {
            DefaultStyleKey = typeof(NSTextBox);
            
            Loaded += NSTextBox_Loaded;
            Unloaded += NSTextBox_Unloaded;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _border = (Border)GetTemplateChild(BorderTemplateName);
            _limitTextBlock = (TextBlock)GetTemplateChild(LimitTextBlockTemplateName);

            UpdateVisual();
        }

        private void AcceptsReturnChanged(DependencyObject sender, DependencyProperty dp)
        {
            UpdateVisual();
        }

        private void MaxLengthChanged(DependencyObject sender, DependencyProperty dp)
        {
            UpdateVisual();
        }

        private void NSTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            _acceptsReturnCallbackToken = RegisterPropertyChangedCallback(AcceptsReturnProperty, AcceptsReturnChanged);
            _maxLengthCallbackToken = RegisterPropertyChangedCallback(MaxLengthProperty, MaxLengthChanged);
        }

        private void NSTextBox_Unloaded(object sender, RoutedEventArgs e)
        {
            UnregisterPropertyChangedCallback(AcceptsReturnProperty, _acceptsReturnCallbackToken);
            UnregisterPropertyChangedCallback(MaxLengthProperty, _maxLengthCallbackToken);
        }

        private void UpdateVisual()
        {
            _border.BorderThickness = AcceptsReturn ? BorderThickness : new Thickness(0, 0, 0, BorderThickness.Bottom);
            _limitTextBlock.Visibility = MaxLength > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}