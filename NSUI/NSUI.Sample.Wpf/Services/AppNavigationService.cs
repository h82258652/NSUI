using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NSUI.Controls;
using NSUI.Sample.Extensions;

namespace NSUI.Sample.Services
{
    public class AppNavigationService
    {

        public void XX()
        {
            var frame = Application.Current.MainWindow?.GetFirstDescendantOfType<NSFrame>();
            if (frame != null)
            {
                frame.Navigate("");
            }
        }


    }
}
