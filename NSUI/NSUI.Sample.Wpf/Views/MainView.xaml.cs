using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                var frame = new Frame();
                window.Content = frame;
                frame.Navigate(new HomeView());
                window.Show();
            }
        }
    }
}