using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NSUI.Controls
{
    public class NSPage : Page
    {
        static NSPage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSPage), new FrameworkPropertyMetadata(typeof(NSPage)));
        }

        public NSPage()
        {
            var navigationService = NavigationService;
            if (navigationService != null)
            {
                navigationService.Navigated += NavigationService_Navigated;
            }
        }

        protected virtual void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            OnNavigatedTo(e);
        }
    }
}