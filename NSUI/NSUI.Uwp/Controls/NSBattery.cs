using Windows.System.Power;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NSUI.Controls
{
    public class NSBattery : Control
    {
        public NSBattery()
        {
            DefaultStyleKey = typeof(NSBattery);
            Loaded += NSBattery_Loaded;
            Unloaded += NSBattery_Unloaded;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisual();
        }

        private void NSBattery_Loaded(object sender, RoutedEventArgs e)
        {
            PowerManager.RemainingChargePercentChanged += PowerManager_RemainingChargePercentChanged;
        }

        private void NSBattery_Unloaded(object sender, RoutedEventArgs e)
        {
            PowerManager.RemainingChargePercentChanged -= PowerManager_RemainingChargePercentChanged;
        }

        private void PowerManager_RemainingChargePercentChanged(object sender, object e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            var remainingChargePercent = PowerManager.RemainingChargePercent;
        }
    }
}