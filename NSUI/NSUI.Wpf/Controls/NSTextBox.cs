using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    [TemplatePart(Name = BorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = LimitTextBlockTemplateName, Type = typeof(TextBlock))]
    [TemplateVisualState(GroupName = LineStateGroupName, Name = SingleLineStateName)]
    [TemplateVisualState(GroupName = LineStateGroupName, Name = MultiLineStateName)]
    public class NSTextBox : TextBox
    {
        private const string BorderTemplateName = "PART_Border";
        private const string LimitTextBlockTemplateName = "PART_LimitTextBlock";
        private const string LineStateGroupName = "LineStates";
        private const string MultiLineStateName = "MultiLine";
        private const string SingleLineStateName = "SingleLine";

        private Border _border;
        private TextBlock _limitTextBlock;

        static NSTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSTextBox), new FrameworkPropertyMetadata(typeof(NSTextBox)));
        }

        public NSTextBox()
        {
            Loaded += NSTextBox_Loaded;
            Unloaded += NSTextBox_Unloaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _border = (Border)GetTemplateChild(BorderTemplateName);
            _limitTextBlock = (TextBlock)GetTemplateChild(LimitTextBlockTemplateName);

            UpdateVisual();
        }

        private void AcceptsReturnChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void NSTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            DependencyPropertyDescriptor.FromProperty(AcceptsReturnProperty, typeof(NSTextBox)).AddValueChanged(this, AcceptsReturnChanged);
        }

        private void NSTextBox_Unloaded(object sender, RoutedEventArgs e)
        {
            DependencyPropertyDescriptor.FromProperty(AcceptsReturnProperty, typeof(NSTextBox)).RemoveValueChanged(this, AcceptsReturnChanged);
        }

        private void UpdateVisual()
        {
            if (AcceptsReturn)
            {
                _border.BorderThickness = BorderThickness;
                VisualStateManager.GoToState(this, MultiLineStateName, true);
            }
            else
            {
                _border.BorderThickness = new Thickness(0, 0, 0, BorderThickness.Bottom);
                VisualStateManager.GoToState(this, SingleLineStateName, true);
            }

            _limitTextBlock.Visibility = MaxLength > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}