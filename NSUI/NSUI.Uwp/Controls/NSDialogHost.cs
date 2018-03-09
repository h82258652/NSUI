using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NSUI.Controls
{
    [TemplateVisualState(GroupName = DialogStateGroupName, Name = ClosedStateName)]
    [TemplateVisualState(GroupName = DialogStateGroupName, Name = OpenedStateName)]
    public class NSDialogHost : ContentControl
    {
        public static readonly DependencyProperty DialogContentProperty = DependencyProperty.Register(nameof(DialogContent), typeof(object), typeof(NSDialogHost), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty DialogContentTemplateProperty = DependencyProperty.Register(nameof(DialogContentTemplate), typeof(DataTemplate), typeof(NSDialogHost), new PropertyMetadata(default(DataTemplate)));
        public static readonly DependencyProperty DialogContentTemplateSelectorProperty = DependencyProperty.Register(nameof(DialogContentTemplateSelector), typeof(DataTemplateSelector), typeof(NSDialogHost), new PropertyMetadata(default(DataTemplateSelector)));
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(NSDialogHost), new PropertyMetadata(default(bool), OnIsOpenChanged));

        private const string ClosedStateName = "Closed";
        private const string DialogStateGroupName = "DialogStates";
        private const string OpenedStateName = "Opened";

        public NSDialogHost()
        {
            DefaultStyleKey = typeof(NSDialogHost);
        }

        public event EventHandler DialogClosed;

        public event EventHandler DialogOpened;

        public object DialogContent
        {
            get => GetValue(DialogContentProperty);
            set => SetValue(DialogContentProperty, value);
        }

        public DataTemplate DialogContentTemplate
        {
            get => (DataTemplate)GetValue(DialogContentTemplateProperty);
            set => SetValue(DialogContentTemplateProperty, value);
        }

        public DataTemplateSelector DialogContentTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(DialogContentTemplateSelectorProperty);
            set => SetValue(DialogContentTemplateSelectorProperty, value);
        }

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (NSDialogHost)d;
            var value = (bool)e.NewValue;

            if (value)
            {
                VisualStateManager.GoToState(obj, OpenedStateName, true);
                obj.DialogOpened?.Invoke(obj, EventArgs.Empty);
            }
            else
            {
                VisualStateManager.GoToState(obj, ClosedStateName, true);
                obj.DialogClosed?.Invoke(obj, EventArgs.Empty);
            }
        }
    }
}