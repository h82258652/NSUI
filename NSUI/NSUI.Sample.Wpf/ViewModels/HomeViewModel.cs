using System.Collections.Generic;
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

        public IOperable Selected { get; set; }

        public List<Game> Games { get; }
    }
}