using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NSUI.Controls
{
    [TemplatePart(Name = TimeTextBlockTemplateName, Type = typeof(TextBlock))]
    [TemplatePart(Name = MiddayTextBlockTemplateName, Type = typeof(TextBlock))]
    public class NSClock : Control
    {
        private const string MiddayTextBlockTemplateName = "PART_MiddayTextBlock";
        private const string TimeTextBlockTemplateName = "PART_TimeTextBlock";

        private readonly DispatcherTimer _timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromTicks(Stopwatch.Frequency)
        };

        private TextBlock _middayTextBlock;
        private TextBlock _timeTextBlock;

        static NSClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSClock), new FrameworkPropertyMetadata(typeof(NSClock)));
        }

        public NSClock()
        {
            _timer.Tick += Timer_Tick;
            Loaded += NSClock_Loaded;
            Unloaded += NSClock_Unloaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _timeTextBlock = (TextBlock)GetTemplateChild(TimeTextBlockTemplateName);
            _middayTextBlock = (TextBlock)GetTemplateChild(MiddayTextBlockTemplateName);

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            var now = DateTime.Now;
            _timeTextBlock.Text = now.ToString("h:m", CultureInfo.InvariantCulture);
            _middayTextBlock.Text = now.ToString("tt", CultureInfo.InvariantCulture);
        }
    }
}