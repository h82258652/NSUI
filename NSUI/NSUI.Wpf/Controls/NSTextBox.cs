using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    [TemplatePart(Name = BorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = PlaceholderContentPresenterTemplateName, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = LimitTextBlockTemplateName, Type = typeof(TextBlock))]
    public class NSTextBox : TextBox
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(object), typeof(NSTextBox), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(NSTextBox), new PropertyMetadata(default(DataTemplate)));
        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register(nameof(PlaceholderText), typeof(string), typeof(NSTextBox), new PropertyMetadata(string.Empty));

        private const string BorderTemplateName = "PART_Border";
        private const string LimitTextBlockTemplateName = "PART_LimitTextBlock";
        private const string PlaceholderContentPresenterTemplateName = "PART_PlaceholderContentPresenter";

        private Border _border;
        private TextBlock _limitTextBlock;
        private ContentPresenter _placeholderContentPresenter;

        static NSTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSTextBox), new FrameworkPropertyMetadata(typeof(NSTextBox)));
        }

        public NSTextBox()
        {
            Loaded += NSTextBox_Loaded;
            Unloaded += NSTextBox_Unloaded;
            TextChanged += NSTextBox_TextChanged;
        }

        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public DataTemplate HeaderTemplate
        {
            get => (DataTemplate)GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _border = (Border)GetTemplateChild(BorderTemplateName);
            _placeholderContentPresenter = (ContentPresenter)GetTemplateChild(PlaceholderContentPresenterTemplateName);
            _limitTextBlock = (TextBlock)GetTemplateChild(LimitTextBlockTemplateName);

            UpdateVisual();
        }

        private void AcceptsReturnChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void MaxLengthChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void NSTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            DependencyPropertyDescriptor.FromProperty(AcceptsReturnProperty, typeof(NSTextBox)).AddValueChanged(this, AcceptsReturnChanged);
            DependencyPropertyDescriptor.FromProperty(MaxLengthProperty, typeof(NSTextBox)).AddValueChanged(this, MaxLengthChanged);
        }

        private void NSTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_placeholderContentPresenter != null)
            {
                _placeholderContentPresenter.Visibility = Text.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void NSTextBox_Unloaded(object sender, RoutedEventArgs e)
        {
            DependencyPropertyDescriptor.FromProperty(AcceptsReturnProperty, typeof(NSTextBox)).RemoveValueChanged(this, AcceptsReturnChanged);
            DependencyPropertyDescriptor.FromProperty(MaxLengthProperty, typeof(NSTextBox)).RemoveValueChanged(this, MaxLengthChanged);
        }

        private void UpdateVisual()
        {
            _border.BorderThickness = AcceptsReturn ? BorderThickness : new Thickness(0, 0, 0, BorderThickness.Bottom);
            _limitTextBlock.Visibility = MaxLength > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}