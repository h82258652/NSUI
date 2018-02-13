using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using NSUI.Extensions;

namespace NSUI.Controls
{
    [TemplatePart(Name = RippleTemplateName, Type = typeof(UIElement))]
    public class NSAppButton : NSCircleButton
    {
        private const string RippleTemplateName = "PART_Ripple";

        private UIElement _ripple;

        static NSAppButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSAppButton), new FrameworkPropertyMetadata(typeof(NSAppButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _ripple = (UIElement)GetTemplateChild(RippleTemplateName);
        }

        protected override Task PlayClickEffectAsync()
        {
            return Task.WhenAll(base.PlayClickEffectAsync(), PlayRippleAnimationAsync());
        }

        private Task PlayRippleAnimationAsync()
        {
            ApplyTemplate();
            if (_ripple == null)
            {
                return Task.CompletedTask;
            }

            const double scaleTo = 1.4;
            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = scaleTo,
                    Duration = TimeSpan.FromSeconds(0.3)
                };
                Storyboard.SetTarget(animation, _ripple);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = scaleTo,
                    Duration = TimeSpan.FromSeconds(0.3)
                };
                Storyboard.SetTarget(animation, _ripple);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 0.3
                });
                animation.KeyFrames.Add(new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.4),
                    Value = 0,
                    EasingFunction = new CubicEase()
                    {
                        EasingMode = EasingMode.EaseIn
                    }
                });
                Storyboard.SetTarget(animation, _ripple);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
                storyboard.Children.Add(animation);
            }
            return storyboard.BeginAsync();
        }
    }
}