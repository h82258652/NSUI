using System;
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

        private async void NSButtonBase_Click(object sender, RoutedEventArgs e)
        {
            var audioSource = AudioSource;
            if (audioSource == null)
            {
                return;
            }

            var audioFile = await StorageFile.GetFileFromApplicationUriAsync(audioSource);

            var wasapiOut = new WasapiOutRT(AudioClientShareMode.Shared, 200);
            wasapiOut.Init(() => new MediaFoundationReader(audioFile.Path));
            wasapiOut.Play();
        }
    }
}