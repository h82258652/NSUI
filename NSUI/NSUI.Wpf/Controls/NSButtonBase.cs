using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NSUI.Controls
{
    [TemplatePart(Name = FocusVisualTemplateName, Type = typeof(INSFocusVisual))]
    public abstract class NSButtonBase : Button
    {
        public static readonly DependencyProperty ClickAudioSourceProperty = DependencyProperty.Register(nameof(ClickAudioSource), typeof(Uri), typeof(NSButtonBase), new PropertyMetadata(default(Uri)));
        public static readonly DependencyProperty FocusAudioSourceProperty = DependencyProperty.Register(nameof(FocusAudioSource), typeof(Uri), typeof(NSButtonBase), new PropertyMetadata(default(Uri)));

        private const string FocusVisualTemplateName = "PART_FocusVisual";

        private INSFocusVisual _focusVisual;

        protected NSButtonBase()
        {
            Click += NSButtonBase_Click;
        }

        public event EventHandler ClickEffectEnded;

        public Uri ClickAudioSource
        {
            get => (Uri)GetValue(ClickAudioSourceProperty);
            set => SetValue(ClickAudioSourceProperty, value);
        }

        public Uri FocusAudioSource
        {
            get => (Uri)GetValue(FocusAudioSourceProperty);
            set => SetValue(FocusAudioSourceProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _focusVisual = (INSFocusVisual)GetTemplateChild(FocusVisualTemplateName);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (_focusVisual == null)
            {
                return;
            }

            var key = e.Key;
            if (key == Key.Left)
            {
                var leftFocusableElement = PredictFocus(FocusNavigationDirection.Left);
                if (leftFocusableElement == null || ReferenceEquals(this, leftFocusableElement))
                {
                    _focusVisual.ShakeLeft();
                }
            }
            else if (key == Key.Up)
            {
                var upFocusableElement = PredictFocus(FocusNavigationDirection.Up);
                if (upFocusableElement == null || ReferenceEquals(this, upFocusableElement))
                {
                    _focusVisual.ShakeUp();
                }
            }
            else if (key == Key.Right)
            {
                var rightFocusableElement = PredictFocus(FocusNavigationDirection.Right);
                if (rightFocusableElement == null || ReferenceEquals(this, rightFocusableElement))
                {
                    _focusVisual.ShakeRight();
                }
            }
            else if (key == Key.Down)
            {
                var downFocusableElement = PredictFocus(FocusNavigationDirection.Down);
                if (downFocusableElement == null || ReferenceEquals(this, downFocusableElement))
                {
                    _focusVisual.ShakeDown();
                }
            }
        }

        protected Task PlayAudioAsync(Stream audioStream)
        {
            return NSAudioManager.PlayAudioAsync(audioStream);
        }

        protected Task PlayClickAudioAsync()
        {
            var audioSource = ClickAudioSource;
            if (audioSource == null)
            {
                return Task.CompletedTask;
            }

            return NSAudioManager.PlayAudioAsync(audioSource);
        }

        protected virtual Task PlayClickEffectAsync()
        {
            return PlayClickAudioAsync();
        }

        private async void NSButtonBase_Click(object sender, RoutedEventArgs e)
        {
            await PlayClickEffectAsync();

            ClickEffectEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}