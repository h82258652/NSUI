using System.Windows.Input;

namespace NSUI.Sample.Models
{
    public class Game : IOperable
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public Game()
        {
            Operations = new Operation[]
            {
                new Operation()
                {
                    Name = "OK"
                }, 
            };
        }

        public Operation[] Operations { get;  }
    }
}