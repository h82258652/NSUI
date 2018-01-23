using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using NSUI.Animation;

namespace NSUI.Controls
{
    [TemplatePart(Name = VisualElementTemplateName, Type = typeof(UIElement))]
    public class NSFocusVisual : Control
    {
        private const string VisualElementTemplateName = "PART_VisualElement";

        private UIElement _visualElement;

        static NSFocusVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSFocusVisual), new FrameworkPropertyMetadata(typeof(NSFocusVisual)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (UIElement)GetTemplateChild(VisualElementTemplateName);
        }

        public void ShakeDown()
        {
            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = Constants.FocusVisualShakeToValue,
                Duration = Constants.FocusVisualShakeDuration,
                EasingFunction = new BackEase()
                {
                }
            };
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
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
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 0 - Constants.FocusVisualShakeToValue,
                Duration = Constants.FocusVisualShakeDuration,
                AutoReverse = true,
                EasingFunction = new CubicBezierEase()
                {
                    ControlPoint1 = new Point(.36, .07),
                    ControlPoint2 = new Point(.19, .97)
                }
            };
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
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
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = Constants.FocusVisualShakeToValue,
                Duration = Constants.FocusVisualShakeDuration,
                EasingFunction = new BackEase()
                {
                }
            };
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
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
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = 0 - Constants.FocusVisualShakeToValue,
                Duration = Constants.FocusVisualShakeDuration,
                EasingFunction = new BackEase()
                {
                }
            };
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}