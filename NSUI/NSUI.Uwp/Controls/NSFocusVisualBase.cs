﻿using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NSUI.Controls
{
    [TemplatePart(Name = VisualElementTemplateName, Type = typeof(FrameworkElement))]
    public abstract class NSFocusVisualBase : Control, INSFocusVisual
    {
        public static readonly DependencyProperty ShakeAudioSourceProperty = DependencyProperty.Register(nameof(ShakeAudioSource), typeof(Uri), typeof(NSFocusVisualBase), new PropertyMetadata(default(Uri)));
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(NSFocusVisualBase), new PropertyMetadata(default(double)));

        private const string VisualElementTemplateName = "PART_VisualElement";

        private FrameworkElement _visualElement;

        public Uri ShakeAudioSource
        {
            get => (Uri)GetValue(ShakeAudioSourceProperty);
            set => SetValue(ShakeAudioSourceProperty, value);
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public void ShakeDown()
        {
            Shake(8, -4, "(UIElement.RenderTransform).(TranslateTransform.Y)");
        }

        public void ShakeLeft()
        {
            Shake(-8, 4, "(UIElement.RenderTransform).(TranslateTransform.X)");
        }

        public void ShakeRight()
        {
            Shake(8, -4, "(UIElement.RenderTransform).(TranslateTransform.X)");
        }

        public void ShakeUp()
        {
            Shake(-8, 4, "(UIElement.RenderTransform).(TranslateTransform.Y)");
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _visualElement = (FrameworkElement)GetTemplateChild(VisualElementTemplateName);
            Debug.Assert(_visualElement != null);
            ((Storyboard)_visualElement.Resources["VisualBrushStoryboard"]).Begin();
        }

        private void PlayShakeAudio()
        {
            var shakeAudioSource = ShakeAudioSource;
            if (shakeAudioSource == null)
            {
                return;
            }

            NSAudioManager.PlayAudio(shakeAudioSource);
        }

        private void Shake(double value1, double value2, string propertyPath)
        {
            PlayShakeAudio();

            if (_visualElement == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0),
                Value = 0
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.04),
                Value = value1
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.08),
                Value = value2
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = TimeSpan.FromSeconds(0.12),
                Value = 0
            });
            Storyboard.SetTarget(animation, _visualElement);
            Storyboard.SetTargetProperty(animation, propertyPath);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}