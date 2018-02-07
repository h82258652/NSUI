using System;
using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSFrame : Frame
    {
        static NSFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSFrame), new FrameworkPropertyMetadata(typeof(NSFrame)));
        }

        public void NavigateWithTransition(Uri source, object extraData)
        {
            // TODO
            base.Navigate(source, extraData);
        }

        public void NavigateWithTransition(Uri source)
        {
            NavigateWithTransition(source, null);
        }

        public void NavigateWithTransition(object content)
        {
            NavigateWithTransition(content, null);
        }

        public void NavigateWithTransition(object content, object extraData)
        {
            // TODO
            base.Navigate(content, extraData);
        }
    }
}