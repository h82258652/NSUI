using System;
using System.Windows;
using System.Windows.Controls;
using NAudio.Wave;

namespace NSUI.Controls
{
    public class NSButtonBase : Button
    {
        public static readonly DependencyProperty AudioSourceProperty = DependencyProperty.Register(nameof(AudioSource), typeof(Uri), typeof(NSButtonBase), new PropertyMetadata(new Uri("pack://application:,,,/NSUI.Wpf;component/Assets/Audios/settings.wav")));

        public NSButtonBase()
        {
            Click += NSButtonBase_Click;
        }

        public Uri AudioSource
        {
            get => (Uri)GetValue(AudioSourceProperty);
            set => SetValue(AudioSourceProperty, value);
        }

        private void NSButtonBase_Click(object sender, RoutedEventArgs e)
        {
            var audioSource = AudioSource;
            if (audioSource == null)
            {
                return;
            }

            var audio = Application.GetResourceStream(audioSource);
            if (audio == null)
            {
                return;
            }

            var wasapiOut = new WasapiOut();
            wasapiOut.Init(new WaveFileReader(audio.Stream));
            wasapiOut.Play();
        }
    }
}