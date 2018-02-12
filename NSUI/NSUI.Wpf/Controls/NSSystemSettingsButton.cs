using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using NSUI.Extensions;

namespace NSUI.Controls
{
    [TemplatePart(Name = IconTemplateName, Type = typeof(UIElement))]
    public class NSSystemSettingsButton : NSAppButton
    {
        private const string IconTemplateName = "Image";

        private UIElement _icon;

        static NSSystemSettingsButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSSystemSettingsButton), new FrameworkPropertyMetadata(typeof(NSSystemSettingsButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _icon = (UIElement)GetTemplateChild(IconTemplateName);
        }

        protected override Task PlayClickEffectAsync()
        {
            return Task.WhenAll(base.PlayClickEffectAsync(), PlayClickAnimationAsync());
        }

        private Task PlayClickAnimationAsync()
        {
            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = 90,
                    Duration = TimeSpan.FromSeconds(0.1)
                };
                Storyboard.SetTarget(animation, _icon);
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
                Storyboard.SetTarget(animation, _icon);
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
                Storyboard.SetTarget(animation, _icon);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleY)"));
                storyboard.Children.Add(animation);
            }
            return storyboard.BeginAsync();
        }
    }
}