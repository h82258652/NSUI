using System.Collections.Generic;
using System.Windows.Input;
using NSUI.Sample.Models;

namespace NSUI.Sample.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Games = new List<Game>()
            {
                new Game()
                {
                    Name = "",
                    Icon = ""
                }
            };
        }

        public List<Game> Games { get; }

        public IOperable Selected { get; set; }

        public ICommand UserProfileCommand { get; }
    }
}