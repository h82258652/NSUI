using System;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Win8.Wave.WaveOutputs;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NSUI.Controls
{
    public class NSButtonBase : Button
    {
        public static readonly DependencyProperty AudioSourceProperty = DependencyProperty.Register(nameof(AudioSource), typeof(Uri), typeof(NSButtonBase), new PropertyMetadata(new Uri("ms-appx:///NSUI.Uwp/Assets/Audios/settings.wav")));

        public NSButtonBase()
        {
            Click += NSButtonBase_Click;
        }

        public Uri AudioSource
        {
            get => (Uri)GetValue(AudioSourceProperty);
            set => SetValue(AudioSourceProperty, value);
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