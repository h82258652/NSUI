using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using NSUI.Extensions;

namespace NSUI.Controls
{
    [TemplatePart(Name = RippleTemplateName, Type = typeof(UIElement))]
    public class NSSystemSettingsButton : NSCircleButton
    {
        private const string RippleTemplateName = "PART_Ripple";

        private UIElement _ripple;

        static NSSystemSettingsButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSSystemSettingsButton), new FrameworkPropertyMetadata(typeof(NSSystemSettingsButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _ripple = (UIElement)GetTemplateChild(RippleTemplateName);
        }

        protected override Task PlayClickEffectAsync()
        {
            return Task.WhenAll(base.PlayClickEffectAsync(), PlayClickAnimationAsync());
        }

        private Task PlayClickAnimationAsync()
        {
            if (_ripple == null)
            {
                return Task.CompletedTask;
            }

            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 1.1,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, _ripple);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 1.1,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, _ripple);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, _ripple);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
                storyboard.Children.Add(animation);
            }
            return storyboard.BeginAsync();
        }
    }
}