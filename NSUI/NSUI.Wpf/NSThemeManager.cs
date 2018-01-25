using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NSUI
{
    public class NSThemeManager : INotifyPropertyChanged
    {
        private static NSTheme _currentTheme;
        private readonly List<WeakReference<NSThemeManager>> _themeManagers = new List<WeakReference<NSThemeManager>>();

        public NSThemeManager()
        {
            _themeManagers.Add(new WeakReference<NSThemeManager>(this));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NSTheme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                if (_currentTheme == value)
                {
                    return;
                }

                _currentTheme = value;
                for (var i = _themeManagers.Count - 1; i >= 0; i--)
                {
                    var themeManagerReference = _themeManagers[i];
                    if (themeManagerReference.TryGetTarget(out var themeManager))
                    {
                        themeManager.PropertyChanged?.Invoke(themeManager, new PropertyChangedEventArgs(nameof(CurrentTheme)));
                    }
                    else
                    {
                        _themeManagers.RemoveAt(i);
                    }
                }
            }
        }
    }
}