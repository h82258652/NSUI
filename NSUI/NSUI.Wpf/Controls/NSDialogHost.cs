using System;
using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    [TemplateVisualState(GroupName = DialogStateGroupName, Name = ClosedStateName)]
    [TemplateVisualState(GroupName = DialogStateGroupName, Name = OpenedStateName)]
    public class NSDialogHost : ContentControl
    {
        public static readonly DependencyProperty DialogContentProperty = DependencyProperty.Register(nameof(DialogContent), typeof(object), typeof(NSDialogHost), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(NSDialogHost), new PropertyMetadata(default(bool), OnIsOpenChanged));

        private const string ClosedStateName = "Closed";
        private const string DialogStateGroupName = "DialogStates";
        private const string OpenedStateName = "Opened";

        static NSDialogHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSDialogHost), new FrameworkPropertyMetadata(typeof(NSDialogHost)));
        }

        public event EventHandler DialogClosed;

        public event EventHandler DialogOpened;

        public object DialogContent
        {
            get => GetValue(DialogContentProperty);
            set => SetValue(DialogContentProperty, value);
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