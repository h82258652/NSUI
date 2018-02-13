using System;
using System.Windows;
using System.Windows.Controls;

namespace NSUI.Controls
{
    public class NSContentControl : ContentControl
    {
        private const string ContentPresenterTemplateName = "PART_ContentPresenter";

        private ContentPresenter _contentPresenter;

        static NSContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NSContentControl), new FrameworkPropertyMetadata(typeof(NSContentControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _contentPresenter = (ContentPresenter)GetTemplateChild(ContentPresenterTemplateName);
        }

        public void ShowDialog(INSDialog dialog)
        {
            if (dialog == null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            var grid = new Grid();

            throw new NotImplementedException();
        }
    }
}