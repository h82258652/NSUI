using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using WinRTXamlToolkit.AwaitableUI;

namespace NSUI.Controls
{
    public class NSFrame : Frame
    {
        private const string FrameContentPresenterTemplateName = "PART_FrameCP";

        private ContentPresenter _frameContentPresenter;

        public NSFrame()
        {
            DefaultStyleKey = typeof(NSFrame);
        }

        public void NavigateWithTransition(Type sourcePageType)
        {
            // TODO
            base.Navigate(sourcePageType);
        }

        public void NavigateWithTransition(Type sourcePageType, object parameter)
        {
            // TODO
            base.Navigate(sourcePageType, parameter);
        }

        private Task FadeIn()
        {
            if (_frameContentPresenter == null)
            {
                return Task.CompletedTask;
            }

            var storyboard = new Storyboard();
            return storyboard.BeginAsync();

            throw new NotImplementedException();
        }

        public void NavigateWithTransition(Type sourcePageType, object parameter, NavigationTransitionInfo infoOverride)
        {
            // TODO
            base.Navigate(sourcePageType, parameter, infoOverride);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _frameContentPresenter = (ContentPresenter)GetTemplateChild(FrameContentPresenterTemplateName);
        }
    }
}