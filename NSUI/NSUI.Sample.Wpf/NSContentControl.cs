using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace NSUI.Sample
{
    public class NSContentControl : ContentControl
    {
        static NSContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSContentControl), new FrameworkPropertyMetadata(typeof(NSContentControl)));
        }

        private bool _toggle;

        public void Toggle()
        {
            var border = GetTemplateChild("Border") as Border;

            var contentPresenter = GetTemplateChild("ContentPresenter") as ContentPresenter;

            if (!_toggle)
            {
                contentPresenter.Effect = new BlurEffect()
                {
                    KernelType= KernelType.Gaussian,
                    RenderingBias =  RenderingBias.Quality,
                    Radius = 4
                };

                border.Background = new SolidColorBrush()
                {
                    Color = Color.FromArgb(80,255,0,0)
                };
            }
            else
            {
                contentPresenter.Effect = null;

                border.Background = null;
            }

            _toggle = !_toggle;
        }
    }
}