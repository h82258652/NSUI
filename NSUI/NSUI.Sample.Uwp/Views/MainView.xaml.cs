using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace NSUI.Sample.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            
            FocusManager.GetFocusedElement();
        }
    }
}