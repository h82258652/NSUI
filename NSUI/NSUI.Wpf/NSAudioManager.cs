using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace NSUI
{
    public static class NSAudioManager
    {
        public static bool IsMuted { get; set; }

        internal static void PlayAudio(Uri audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            if (IsMuted)
            {
                return;
            }

            var audio = Application.GetResourceStream(audioSource);
            Debug.Assert(audio != null);
            PlayAudio(audio.Stream);
        }

        internal static void PlayAudio(Stream audioStream)
        {
            if (audioStream == null)
            {
                throw new ArgumentNullException(nameof(audioStream));
            }

            if (IsMuted)
            {
                return;
            }

            using (var wasapiOut = new WasapiOut())
            {
                var waveProvider = new WaveFileReader(audioStream);
                wasapiOut.Init(waveProvider);
                wasapiOut.Play();
            }
        }

        internal static Task PlayAudioAsync(Uri audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            var audio = Application.GetResourceStream(audioSource);
            Debug.Assert(audio != null);
            return PlayAudioAsync(audio.Stream);
        }

        internal static Task PlayAudioAsync(Stream audioStream)
        {
            if (audioStream == null)
            {
                throw new ArgumentNullException(nameof(audioStream));
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
                var waveProvider = new VolumeSampleProvider(new WaveToSampleProvider(new WaveFileReader(audioStream)));
                if (IsMuted)
                {
                    waveProvider.Volume = 0;
                }
                wasapiOut.Init(waveProvider);
                wasapiOut.Play();
            }
            return tcs.Task;
        }
    }
}