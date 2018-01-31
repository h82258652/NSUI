using System;
using System.Collections.Generic;
using System.Windows;

namespace NSUI.Styles
{
    public class NSThemeResourceDictionary : ResourceDictionary
    {
        private static readonly List<WeakReference<NSThemeResourceDictionary>> ResourceDictionaries = new List<WeakReference<NSThemeResourceDictionary>>();

        public NSThemeResourceDictionary()
        {
            ResourceDictionaries.Add(new WeakReference<NSThemeResourceDictionary>(this));

            var theme = NSThemeManager.Instance.CurrentTheme;
            MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri($"pack://application:,,,/NSUI.Wpf;component/Styles/NSThemeStyle.{theme}.xaml")
            });
        }

        internal static void ChangeTheme(NSTheme theme)
        {
            var source = new Uri($"pack://application:,,,/NSUI.Wpf;component/Styles/NSThemeStyle.{theme}.xaml");
            for (var i = ResourceDictionaries.Count - 1; i >= 0; i--)
            {
                var resourceDictionaryReference = ResourceDictionaries[i];
                if (resourceDictionaryReference.TryGetTarget(out var resourceDictionary))
                {
                    resourceDictionary.MergedDictionaries.Clear();
                    resourceDictionary.MergedDictionaries.Add(new ResourceDictionary()
                    {
                        Source = source
                    });
                }
                else
                {
                    ResourceDictionaries.RemoveAt(i);
                }
            }
        }
    }
}