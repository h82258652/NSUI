﻿using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace NSUI.Controls
{
    [TemplatePart(Name = FocusVisualTemplateName, Type = typeof(NSCircleFocusVisual))]
    public class NSCircleButton : Button
    {
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(NSCircleButton), new PropertyMetadata(default(double)));

        private const string FocusVisualTemplateName = "PART_FocusVisual";

        private INSFocusVisual _focusVisual;

        public NSCircleButton()
        {
            DefaultStyleKey = typeof(NSCircleButton);
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _focusVisual = (INSFocusVisual)GetTemplateChild(FocusVisualTemplateName);
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