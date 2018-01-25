using System.Windows.Input;

namespace NSUI.Sample.Models
{
    public class Operation
    {
        public string AccessKey { get; set; }

        public ICommand Command { get; set; }

        public string Name { get; set; }
    }
}