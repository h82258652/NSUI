using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NSUI
{
    public class NSFocusManager : INotifyPropertyChanged
    {
        private static readonly List<WeakReference<NSFocusManager>> FocusManagers = new List<WeakReference<NSFocusManager>>();

        public NSFocusManager()
        {
            FocusManagers.Add(new WeakReference<NSFocusManager>(this));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IInputElement FocusedElement
        {
            get
            {
                Window activeWindow = null;
                foreach (Window window in Application.Current.Windows)
                {
                    FocusManager.RemoveGotFocusHandler(window, Window_FocusChanged);
                    FocusManager.AddGotFocusHandler(window, Window_FocusChanged);
                    FocusManager.RemoveLostFocusHandler(window, Window_FocusChanged);
                    FocusManager.AddLostFocusHandler(window, Window_FocusChanged);

                    if (window.IsActive)
                    {
                        activeWindow = window;
                    }
                }
                return activeWindow != null ? FocusManager.GetFocusedElement(activeWindow) : null;
            }
        }

        public static readonly DependencyProperty ActionsProperty = DependencyProperty.RegisterAttached("Actions", typeof(object), typeof(NSFocusManager), new PropertyMetadata(default(object)));

        public static void SetActions(DependencyObject obj, object value)
        {
            obj.SetValue(ActionsProperty, value);
        }

        public static object GetActions(DependencyObject obj)
        {
            return obj.GetValue(ActionsProperty);
        }

        private static void Window_FocusChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            for (var i = FocusManagers.Count - 1; i >= 0; i--)
            {
                var focusManagerReference = FocusManagers[i];
                if (focusManagerReference.TryGetTarget(out var focusManager))
                {
                    focusManager.PropertyChanged?.Invoke(focusManager, new PropertyChangedEventArgs(nameof(FocusedElement)));
                }
                else
                {
                    FocusManagers.RemoveAt(i);
                }
            }
        }
    }
}