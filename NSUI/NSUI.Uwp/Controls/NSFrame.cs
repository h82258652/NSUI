using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using WinRTXamlToolkit.AwaitableUI;

namespace NSUI.Controls
{
    [TemplatePart(Name = FrameContentPresenterTemplateName, Type = typeof(ContentPresenter))]
    public class NSFrame : Frame
    {
        private const string FrameContentPresenterTemplateName = "PART_FrameCP";

        private ContentPresenter _frameContentPresenter;

        public NSFrame()
        {
            DefaultStyleKey = typeof(NSFrame);
        }

        public async Task<bool> NavigateWithTransition(Type sourcePageType)
        {
            await FadeOut();

            // TODO
            var result = base.Navigate(sourcePageType);

            await FadeIn();

            return result;
        }

        public void NavigateWithTransition(Type sourcePageType, object parameter)
        {
            // TODO
            base.Navigate(sourcePageType, parameter);
        }

        public async Task<bool> NavigateWithTransition(Type sourcePageType, object parameter, NavigationTransitionInfo infoOverride)
        {
            await FadeOut();

            // TODO
            var result = base.Navigate(sourcePageType, parameter, infoOverride);

            await FadeIn();

            return result;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _frameContentPresenter = (ContentPresenter)GetTemplateChild(FrameContentPresenterTemplateName);
        }

        private Task FadeIn()
        {
            if (_frameContentPresenter == null)
            {
                return Task.CompletedTask;
            }

            var storyboard = new Storyboard();
            return storyboard.BeginAsync();
        }

        private Task FadeOut()
        {
            if (_frameContentPresenter == null)
            {
                return Task.CompletedTask;
            }

            var storyboard = new Storyboard();
            return storyboard.BeginAsync();
        }
    }
}