using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace NSUI.Extensions
{
    public static class StoryboardExtensions
    {
        public static Task BeginAsync(this Storyboard storyboard)
        {
            if (storyboard == null)
            {
                throw new ArgumentNullException(nameof(storyboard));
            }

            var tcs = new TaskCompletionSource<object>();

            void Completed(object sender, EventArgs e)
            {
                storyboard.Completed -= Completed;
                tcs.SetResult(null);
            }
            storyboard.Completed += Completed;
            storyboard.Begin();

            return tcs.Task;
        }
    }
}