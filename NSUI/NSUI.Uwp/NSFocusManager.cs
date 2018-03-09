using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

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

        public object FocusedElement
        {
            get
            {
                var rootContent = Window.Current.Content;
                rootContent.GotFocus -= RootContent_FocusChanged;
                rootContent.GotFocus += RootContent_FocusChanged;
                rootContent.LostFocus -= RootContent_FocusChanged;
                rootContent.LostFocus += RootContent_FocusChanged;

                return FocusManager.GetFocusedElement();
            }
        }
        
        private static void RootContent_FocusChanged(object sender, RoutedEventArgs e)
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