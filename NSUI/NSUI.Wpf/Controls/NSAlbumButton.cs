using System.Threading.Tasks;
using System.Windows;

namespace NSUI.Controls
{
    [TemplatePart(Name = RippleTemplateName, Type = typeof(UIElement))]
    public class NSAlbumButton : NSCircleButton
    {
        private const string RippleTemplateName = "PART_Ripple";

        private UIElement _ripple;

        static NSAlbumButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSAlbumButton), new FrameworkPropertyMetadata(typeof(NSAlbumButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _ripple = (UIElement)GetTemplateChild(RippleTemplateName);
        }

        protected override Task PlayClickEffectAsync()
        {
            return base.PlayClickEffectAsync();
        }
    }
}