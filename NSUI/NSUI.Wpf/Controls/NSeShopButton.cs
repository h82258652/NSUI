using System.Windows;

namespace NSUI.Controls
{
    [TemplatePart(Name = RippleTemplateName, Type = typeof(UIElement))]
    public class NSeShopButton : NSCircleButton
    {
        private const string RippleTemplateName = "PART_Ripple";

        private UIElement _ripple;

        static NSeShopButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSeShopButton), new FrameworkPropertyMetadata(typeof(NSeShopButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _ripple = (UIElement)GetTemplateChild(RippleTemplateName);
        }
    }
}