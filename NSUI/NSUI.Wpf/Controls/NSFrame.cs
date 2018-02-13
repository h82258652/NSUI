using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using NSUI.Extensions;

namespace NSUI.Controls
{
    [TemplatePart(Name = FrameContentPresenterTemplateName, Type = typeof(ContentPresenter))]
    public class NSFrame : Frame
    {
        private const string FrameContentPresenterTemplateName = "PART_FrameCP";

        private ContentPresenter _frameContentPresenter;

        static NSFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSFrame), new FrameworkPropertyMetadata(typeof(NSFrame)));
        }

        public async Task GoBackWithTransition()
        {
            await FadeOut();

            GoBack();

            await FadeIn();
        }

        public async Task GoForwardWithTransition()
        {
            await FadeOut();

            GoForward();

            await FadeIn();
        }

        public async Task<bool> NavigateWithTransition(Uri source, object extraData)
        {
            await FadeOut();

            var result = Navigate(source, extraData);

            await FadeIn();

            return result;
        }

        public Task<bool> NavigateWithTransition(Uri source)
        {
            return NavigateWithTransition(source, null);
        }

        public Task<bool> NavigateWithTransition(object content)
        {
            return NavigateWithTransition(content, null);
        }

        public async Task<bool> NavigateWithTransition(object content, object extraData)
        {
            await FadeOut();

            var result = Navigate(content, extraData);

            await FadeIn();

            return result;
        }

        public override void OnApplyTemplate()
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
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            Storyboard.SetTarget(animation, _frameContentPresenter);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
            return storyboard.BeginAsync();
        }

        private Task FadeOut()
        {
            if (_frameContentPresenter == null)
            {
                return Task.CompletedTask;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            Storyboard.SetTarget(animation, _frameContentPresenter);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
            return storyboard.BeginAsync();
        }
    }
}