using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.ApplicationServices;

namespace NSUI.Controls
{
    public class NSBattery : Control
    {
        static NSBattery()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSBattery), new FrameworkPropertyMetadata(typeof(NSBattery)));
        }

        public NSBattery()
        {
            Loaded += NSBattery_Loaded;
            Unloaded += NSBattery_Unloaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisual();
        }

        private void NSBattery_Loaded(object sender, RoutedEventArgs e)
        {
            PowerManager.BatteryLifePercentChanged += PowerManager_BatteryLifePercentChanged;
        }

        private void NSBattery_Unloaded(object sender, RoutedEventArgs e)
        {
            PowerManager.BatteryLifePercentChanged -= PowerManager_BatteryLifePercentChanged;
        }

        private void PowerManager_BatteryLifePercentChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (PowerManager.IsBatteryPresent)
            {
                var batteryLifePercent = PowerManager.BatteryLifePercent;
                var currentBatteryState = PowerManager.GetCurrentBatteryState();

                // TODO
            }
            else
            {
                // TODO 100%
            }
        }
    }
}