using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NAudio.Wave;

namespace NSUI.Controls
{
    [TemplatePart(Name = FocusVisualTemplateName, Type = typeof(INSFocusVisual))]
    public abstract class NSButtonBase : Button
    {
        public static readonly DependencyProperty AudioSourceProperty = DependencyProperty.Register(nameof(AudioSource), typeof(Uri), typeof(NSButtonBase), new PropertyMetadata(new Uri("pack://application:,,,/NSUI.Wpf;component/Assets/Audios/standby.wav")));

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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _focusVisual = (INSFocusVisual)GetTemplateChild(FocusVisualTemplateName);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (_focusVisual == null)
            {
                return;
            }

            var key = e.Key;
            if (key == Key.Left)
            {
                var leftFocusableElement = PredictFocus(FocusNavigationDirection.Left);
                if (leftFocusableElement == null || ReferenceEquals(this, leftFocusableElement))
                {
                    _focusVisual.ShakeLeft();
                }
            }
            else if (key == Key.Up)
            {
                var upFocusableElement = PredictFocus(FocusNavigationDirection.Up);
                if (upFocusableElement == null || ReferenceEquals(this, upFocusableElement))
                {
                    _focusVisual.ShakeUp();
                }
            }
            else if (key == Key.Right)
            {
                var rightFocusableElement = PredictFocus(FocusNavigationDirection.Right);
                if (rightFocusableElement == null || ReferenceEquals(this, rightFocusableElement))
                {
                    _focusVisual.ShakeRight();
                }
            }
            else if (key == Key.Down)
            {
                var downFocusableElement = PredictFocus(FocusNavigationDirection.Down);
                if (downFocusableElement == null || ReferenceEquals(this, downFocusableElement))
                {
                    _focusVisual.ShakeDown();
                }
            }
        }

        protected Task PlayAudioAsync()
        {
            var audioSource = AudioSource;
            if (audioSource == null)
            {
                return Task.CompletedTask;
            }

            var audio = Application.GetResourceStream(audioSource);
            if (audio == null)
            {
                return Task.CompletedTask;
            }

            return PlayAudioAsync(audio.Stream);
        }

        protected Task PlayAudioAsync(Stream audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            var tcs = new TaskCompletionSource<object>();
            using (var wasapiOut = new WasapiOut())
            {
                void PlaybackStopped(object sender, StoppedEventArgs e)
                {
                    wasapiOut.PlaybackStopped -= PlaybackStopped;
                    tcs.SetResult(null);
                }
                wasapiOut.PlaybackStopped += PlaybackStopped;
                using (var waveProvider = new WaveFileReader(audioSource))
                {
                    wasapiOut.Init(waveProvider);
                    wasapiOut.Play();
                }
            }
            return tcs.Task;
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