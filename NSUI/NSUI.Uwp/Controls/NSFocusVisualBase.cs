using System;
using System.IO;
using NAudio.CoreAudioApi;
using NAudio.Win8.Wave.WaveOutputs;
using Windows.Storage;
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

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild(VisualElementTemplateName);
            if (_visualElement != null)
            {
                ((Storyboard)_visualElement.Resources["VisualBrushStoryboard"]).Begin();
            }
        }

        private static async void PlayShakeAudio()
        {
            using (var wasapiOut = new WasapiOutRT(AudioClientShareMode.Shared, 200))
            {
                var audio = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///NSUI.Uwp/Assets/Audios/standby.wav"));
                var audioSource = await audio.OpenStreamForReadAsync();
                using (var waveProvider = new MediaFoundationReaderUniversal(audioSource.AsRandomAccessStream()))
                {
                    wasapiOut.Init(() => waveProvider);
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
            Storyboard.SetTargetProperty(animation, propertyPath);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}