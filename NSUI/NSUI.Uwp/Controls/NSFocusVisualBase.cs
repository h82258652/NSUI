using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    [TemplatePart(Name = VisualElementTemplateName, Type = typeof(FrameworkElement))]
    public abstract class NSFocusVisualBase : Control, INSFocusVisual
    {
        private const string VisualElementTemplateName = "PART_VisualElement";

        private FrameworkElement _visualElement;

        public void ShakeDown()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0),
                Value = 0
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.04),
                Value = 8
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.08),
                Value = -4
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.12),
                Value = 0
            });
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        public void ShakeLeft()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0),
                Value = 0
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.04),
                Value = -8
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.08),
                Value = 4
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.12),
                Value = 0
            });
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.X)");
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        public void ShakeRight()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0),
                Value = 0
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.04),
                Value = 8
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.08),
                Value = -4
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.12),
                Value = 0
            });
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.X)");
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        public void ShakeUp()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0),
                Value = 0
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.04),
                Value = -8
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.08),
                Value = 4
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.12),
                Value = 0
            });
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild(VisualElementTemplateName);
            if (_visualElement != null)
            {
                ((Storyboard)_visualElement.Resources["VisualBrushStoryboard"]).Begin();
            }
        }
    }
}