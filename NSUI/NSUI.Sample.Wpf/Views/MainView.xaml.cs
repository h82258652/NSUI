using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NSUI.Sample.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                var window = new Window();
                var frame = new Frame() {Focusable = false};
                window.Content = frame;
                frame.Navigate(new HomeView());
                window.Show();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        { 

            var nsThemeManager = NSThemeManager.Instance;
            if (nsThemeManager.CurrentTheme == NSTheme.Light)
            {
                nsThemeManager.CurrentTheme = NSTheme.Dark;
            }
            else
            {
                nsThemeManager.CurrentTheme = NSTheme.Light;
            }
        }

        private void NSButtonBase_OnClickEffectEnded(object sender, EventArgs e)
        {
            MessageBox.Show("Ended");
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = !DialogHost.IsOpen;
        }
    }
}