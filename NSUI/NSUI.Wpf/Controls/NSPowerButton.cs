using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using NSUI.Extensions;

namespace NSUI.Controls
{
    [TemplatePart(Name = IconTemplateName, Type = typeof(UIElement))]
    public class NSPowerButton : NSAppButton
    {
        private const string IconTemplateName = "PART_Icon";

        private UIElement _icon;

        static NSPowerButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSPowerButton), new FrameworkPropertyMetadata(typeof(NSPowerButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _icon = (UIElement)GetTemplateChild(IconTemplateName);
        }

        protected override Task PlayClickEffectAsync()
        {
            return Task.WhenAll(base.PlayClickEffectAsync(), PlayIconAnimationAsync());
        }

        private Task PlayIconAnimationAsync()
        {
            ApplyTemplate();
            if (_icon == null)
            {
                return Task.CompletedTask;
            }

            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 1.5
                });
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.1),
                    Value = 1
                });
                Storyboard.SetTarget(animation, _icon);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 1.5
                });
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.1),
                    Value = 1
                });
                Storyboard.SetTarget(animation, _icon);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                storyboard.Children.Add(animation);
            }
            return storyboard.BeginAsync();
        }
    }
}