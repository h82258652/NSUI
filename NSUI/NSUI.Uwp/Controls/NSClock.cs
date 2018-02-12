using System;
using System.Diagnostics;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NSUI.Controls
{
    [TemplatePart(Name = HourItemsControlTemplateName, Type = typeof(ItemsControl))]
    [TemplatePart(Name = MinuteItemsControlTemplateName, Type = typeof(ItemsControl))]
    [TemplatePart(Name = AMPMItemsControlTemplateName, Type = typeof(ItemsControl))]
    public class NSClock : Control
    {
        private const string AMPMItemsControlTemplateName = "PART_AMPMItemsControl";
        private const string HourItemsControlTemplateName = "PART_HourItemsControl";
        private const string MinuteItemsControlTemplateName = "PART_MinuteItemsControl";

        private readonly DispatcherTimer _timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromTicks(Stopwatch.Frequency)
        };

        private ItemsControl _ampmItemsControl;
        private ItemsControl _hourItemsControl;
        private ItemsControl _minuteItemsControl;

        public NSClock()
        {
            DefaultStyleKey = typeof(NSClock);

            _timer.Tick += Timer_Tick;
            Loaded += NSClock_Loaded;
            Unloaded += NSClock_Unloaded;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _hourItemsControl = (ItemsControl)GetTemplateChild(HourItemsControlTemplateName);
            _minuteItemsControl = (ItemsControl)GetTemplateChild(MinuteItemsControlTemplateName);
            _ampmItemsControl = (ItemsControl)GetTemplateChild(AMPMItemsControlTemplateName);

            UpdateVisual();
        }

        private void NSClock_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void NSClock_Unloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void Timer_Tick(object sender, object e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            var now = DateTime.Now;
            var hour = now.Hour;
            _hourItemsControl.ItemsSource = hour > 12 ? (hour - 12).ToString() : hour.ToString();
            _minuteItemsControl.ItemsSource = now.Minute.ToString("00");
            _ampmItemsControl.ItemsSource = now.ToString("tt", CultureInfo.InvariantCulture);
        }
    }
}