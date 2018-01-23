using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace NSUI.Controls
{
    [TemplatePart(Name = FocusVisualTemplateName, Type = typeof(NSCircleFocusVisual))]
    public class NSCircleButton : Button
    {
        private const string FocusVisualTemplateName = "PART_FocusVisual";

        private NSCircleFocusVisual _focusVisual;

        public NSCircleButton()
        {
            DefaultStyleKey = typeof(NSCircleButton);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _focusVisual = (NSCircleFocusVisual)GetTemplateChild(FocusVisualTemplateName);
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);

            var key = e.Key;
            if (key == VirtualKey.Left)
            {
                var focusableElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Left);
                // TODO
            }
            else if (key == VirtualKey.Up)
            {
                // TODO
            }
            else if (key == VirtualKey.Right)
            {
                // TODO
            }
            else if (key == VirtualKey.Down)
            {
                // TODO
            }
        }
    }
}