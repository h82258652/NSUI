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

            var image = GetTemplateChild("Image");

            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 1.4,
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
                    To = 1.4,
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

            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = 90,
                    Duration = TimeSpan.FromSeconds(0.1)
                };
                Storyboard.SetTarget(animation, image);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(RotateTransform.Angle)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.05),
                    Value = 1.1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.1),
                    Value = 1
                });
                Storyboard.SetTarget(animation, image);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleX)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.05),
                    Value = 1.1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.1),
                    Value = 1
                });
                Storyboard.SetTarget(animation, image);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleY)"));
                storyboard.Children.Add(animation);
            }
            return storyboard.BeginAsync();
        }
    }
}