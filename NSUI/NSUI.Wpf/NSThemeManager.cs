using System;
using System.Collections.Generic;
using System.ComponentModel;
using NSUI.Styles;

namespace NSUI
{
    public class NSThemeManager : INSThemeManager
    {
        private static readonly List<WeakReference<NSThemeManager>> ThemeManagers = new List<WeakReference<NSThemeManager>>();

        private static NSTheme _currentTheme;

        public NSThemeManager()
        {
            ThemeManagers.Add(new WeakReference<NSThemeManager>(this));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static INSThemeManager Instance { get; } = new NSThemeManager();

        public NSTheme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                if (_currentTheme == value)
                {
                    return;
                }

                if (!Enum.IsDefined(typeof(NSTheme), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _currentTheme = value;
                for (var i = ThemeManagers.Count - 1; i >= 0; i--)
                {
                    var themeManagerReference = ThemeManagers[i];
                    if (themeManagerReference.TryGetTarget(out var themeManager))
                    {
                        themeManager.PropertyChanged?.Invoke(themeManager, new PropertyChangedEventArgs(nameof(CurrentTheme)));
                    }
                    else
                    {
                        ThemeManagers.RemoveAt(i);
                    }
                }
                NSThemeResourceDictionary.ChangeTheme(value);
            }
        }
    }
}