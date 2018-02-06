using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using NAudio.Wave;

namespace NSUI.Controls
{
    [TemplatePart(Name = VisualElementTemplateName, Type = typeof(FrameworkElement))]
    public abstract class NSFocusVisualBase : Control, INSFocusVisual
    {
        private const string VisualElementTemplateName = "PART_VisualElement";

        private FrameworkElement _visualElement;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild(VisualElementTemplateName);
            if (_visualElement != null)
            {
                ((Storyboard)_visualElement.Resources["VisualBrushStoryboard"]).Begin();
            }
        }

        public void ShakeDown()
        {
            Shake(8, -4, "(UIElement.RenderTransform).(TranslateTransform.Y)");
        }

        public void ShakeLeft()
        {
            Shake(-8, 4, "(UIElement.RenderTransform).(TranslateTransform.X)");
        }

        public void ShakeRight()
        {
            Shake(8, -4, "(UIElement.RenderTransform).(TranslateTransform.X)");
        }

        public void ShakeUp()
        {
            Shake(-8, 4, "(UIElement.RenderTransform).(TranslateTransform.Y)");
        }

        private static void PlayShakeAudio()
        {
            using (var wasapiOut = new WasapiOut())
            {
                var audio = Application.GetResourceStream(new Uri("pack://application:,,,/NSUI.Wpf;component/Assets/Audios/standby.wav"));
                Debug.Assert(audio != null);
                using (var waveProvider = new WaveFileReader(audio.Stream))
                {
                    wasapiOut.Init(waveProvider);
                    wasapiOut.Play();
                }
            }
        }

        private void Shake(double value1, double value2, string propertyPath)
        {
            PlayShakeAudio();

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
                Value = value1
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.08),
                Value = value2
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.12),
                Value = 0
            });
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath(propertyPath));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}