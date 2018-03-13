using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    [TemplatePart(Name = MenuItemsHostTemplateName, Type = typeof(ListView))]
    public class NSNavigationView : ContentControl
    {
        public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(nameof(MenuItems), typeof(IList<object>), typeof(NSNavigationView), new PropertyMetadata(default(IList<object>)));
        public static readonly DependencyProperty MenuItemsSourceProperty = DependencyProperty.Register(nameof(MenuItemsSource), typeof(object), typeof(NSNavigationView), new PropertyMetadata(default(object)));

        private const string MenuItemsHostTemplateName = "PART_MenuItemsHost";

        static NSNavigationView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSNavigationView), new FrameworkPropertyMetadata(typeof(NSNavigationView)));
        }

        public IList<object> MenuItems => (IList<object>)GetValue(MenuItemsProperty);

        public object MenuItemsSource
        {
            get => GetValue(MenuItemsSourceProperty);
            set => SetValue(MenuItemsSourceProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var menuItemsHost = (ListView)GetTemplateChild(MenuItemsHostTemplateName);
        }
    }
}