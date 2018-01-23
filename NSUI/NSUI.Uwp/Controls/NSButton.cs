using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace NSUI.Controls
{
    public class NSButton : Button
    {
        private const string FocusVisualTemplateName = "PART_FocusVisual";

        private NSFocusVisual _focusVisual;

        public NSButton()
        {
            DefaultStyleKey = typeof(NSButton);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
             
            _focusVisual = (NSFocusVisual)GetTemplateChild(FocusVisualTemplateName);
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
    }
}