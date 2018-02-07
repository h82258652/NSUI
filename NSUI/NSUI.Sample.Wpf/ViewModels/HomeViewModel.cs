using System.Collections.Generic;
using System.Windows.Input;
using NSUI.Sample.Models;
using NSUI.Sample.Services;

namespace NSUI.Sample.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            _userService = new UserService();

            User = _userService.GetUser();

            Games = new List<Game>()
            {
                new Game()
                {
                    Name = "",
                    Icon = ""
                }
            };

        }



        private UserService _userService;

        public User User { get; }

        public List<Game> Games { get; }

        public IOperable Selected { get; set; }

        public ICommand UserProfileCommand { get; }
    }
}