using System;
using System.IO;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.Win8.Wave.WaveOutputs;
using Windows.Storage;

namespace NSUI
{
    public static class NSAudioManager
    {
        public static bool IsMuted { get; set; }

        internal static async void PlayAudio(Uri audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            if (IsMuted)
            {
                return;
            }

            var audio = await StorageFile.GetFileFromApplicationUriAsync(audioSource);
            var audioStream = await audio.OpenStreamForReadAsync();
            PlayAudio(audioStream);
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

            using (var wasapiOut = new WasapiOutRT(AudioClientShareMode.Shared, 200))
            {
                var waveProvider = new MediaFoundationReaderUniversal(audioStream.AsRandomAccessStream());
                wasapiOut.Init(() => waveProvider);
                wasapiOut.Play();
            }
        }

        internal static async Task PlayAudioAsync(Uri audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            var audio = await StorageFile.GetFileFromApplicationUriAsync(audioSource);
            var audioStream = await audio.OpenStreamForReadAsync();
            await PlayAudioAsync(audioStream);
        }

        internal static Task PlayAudioAsync(Stream audioStream)
        {
            if (audioStream == null)
            {
                throw new ArgumentNullException(nameof(audioStream));
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
                var waveProvider = new VolumeSampleProvider(new WaveToSampleProvider(new MediaFoundationReaderUniversal(audioStream.AsRandomAccessStream())));
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