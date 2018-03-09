using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Views;
using NSUI.Controls;
using NSUI.Sample.Extensions;

namespace NSUI.Sample.Services
{
    public class AppNavigationService : INavigationService
    {
        public const string UnknownPageKey = "-- UNKNOWN --";

        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    var frame = Application.Current.MainWindow.GetFirstDescendantOfType<NSFrame>();
                    var currentType = frame.Content.GetType();

                    if (_pagesByKey.All(temp => temp.Value != currentType))
                    {
                        return UnknownPageKey;
                    }

                    var item = _pagesByKey.FirstOrDefault(temp => temp.Value == currentType);

                    return item.Key;
                };
            }
        }

        public void Config(string key, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    throw new ArgumentException("This key is already used: " + key);
                }
                if (_pagesByKey.Any(p => p.Value == pageType))
                {
                    throw new ArgumentException("This type is already configured with key " + _pagesByKey.First(p => p.Value == pageType).Key);
                }

                _pagesByKey.Add(key, pageType);
            }
        }

        public void GoBack()
        {
            var frame = Application.Current.MainWindow.GetFirstDescendantOfType<NSFrame>();
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public async void NavigateTo(string pageKey, object parameter)
        {
            Type pageType;
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0}. Did you forget to call NavigationService.Configure?", pageKey), nameof(pageKey));
                }

                pageType = _pagesByKey[pageKey];
            }
            var activeWindow = Application.Current.Windows.Cast<Window>().SingleOrDefault(temp => temp.IsActive);
            if (activeWindow != null)
            {
                var frame = activeWindow.GetFirstDescendantOfType<NSFrame>();
                await frame.NavigateWithTransition(Activator.CreateInstance(pageType), parameter);
            }
        }
    }
}