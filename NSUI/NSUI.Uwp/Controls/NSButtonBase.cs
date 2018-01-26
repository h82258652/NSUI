using System;
using System.IO;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Win8.Wave.WaveOutputs;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace NSUI.Controls
{
    [TemplatePart(Name = FocusVisualTemplateName, Type = typeof(INSFocusVisual))]
    public abstract class NSButtonBase : Button
    {
        public static readonly DependencyProperty AudioSourceProperty = DependencyProperty.Register(nameof(AudioSource), typeof(Uri), typeof(NSButtonBase), new PropertyMetadata(new Uri("ms-appx:///NSUI.Uwp/Assets/Audios/settings.wav")));

        private const string FocusVisualTemplateName = "PART_FocusVisual";

        private INSFocusVisual _focusVisual;

        protected NSButtonBase()
        {
            Click += NSButtonBase_Click;
        }

        public event EventHandler ClickEffectEnded;

        public Uri AudioSource
        {
            get => (Uri)GetValue(AudioSourceProperty);
            set => SetValue(AudioSourceProperty, value);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _focusVisual = (INSFocusVisual)GetTemplateChild(FocusVisualTemplateName);
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);

            if (_focusVisual == null)
            {
                return;
            }

            var key = e.Key;
            if (key == VirtualKey.Left)
            {
                var leftFocusableElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Left);
                if (leftFocusableElement == null || ReferenceEquals(this, leftFocusableElement))
                {
                    _focusVisual.ShakeLeft();
                }
            }
            else if (key == VirtualKey.Up)
            {
                var upFocusableElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Up);
                if (upFocusableElement == null || ReferenceEquals(this, upFocusableElement))
                {
                    _focusVisual.ShakeUp();
                }
            }
            else if (key == VirtualKey.Right)
            {
                var rightFocusableElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Right);
                if (rightFocusableElement == null || ReferenceEquals(this, rightFocusableElement))
                {
                    _focusVisual.ShakeRight();
                }
            }
            else if (key == VirtualKey.Down)
            {
                var downFocusableElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Down);
                if (downFocusableElement == null || ReferenceEquals(this, downFocusableElement))
                {
                    _focusVisual.ShakeDown();
                }
            }
        }

        protected Task PlayAudioAsync(Stream audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            var tcs = new TaskCompletionSource<object>();
            using (var wasapiOut = new WasapiOutRT(AudioClientShareMode.Shared, 200))
            {
                void PlaybackStopped(object sender, StoppedEventArgs e)
                {
                    wasapiOut.PlaybackStopped -= PlaybackStopped;
                    tcs.SetResult(null);
                }
                wasapiOut.PlaybackStopped += PlaybackStopped;
                using (var waveProvider = new MediaFoundationReaderUniversal(audioSource.AsRandomAccessStream()))
                {
                    wasapiOut.Init(() => waveProvider);
                    wasapiOut.Play();
                }
            }
            return tcs.Task;
        }

        protected async Task PlayAudioAsync()
        {
            var audioSource = AudioSource;
            if (audioSource == null)
            {
                return;
            }

            var audio = await StorageFile.GetFileFromApplicationUriAsync(audioSource);
            var audioStream = await audio.OpenStreamForReadAsync();

            await PlayAudioAsync(audioStream);
        }

        protected virtual Task PlayClickEffectAsync()
        {
            return PlayAudioAsync();
        }

        private async void NSButtonBase_Click(object sender, RoutedEventArgs e)
        {
            await PlayClickEffectAsync();

            ClickEffectEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}