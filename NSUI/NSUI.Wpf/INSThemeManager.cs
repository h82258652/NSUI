using System.ComponentModel;

namespace NSUI
{
    public interface INSThemeManager : INotifyPropertyChanged
    {
        NSTheme CurrentTheme { get; set; }
    }
}