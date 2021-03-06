﻿using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using NSUI.Sample.Models;
using NSUI.Sample.Services;

namespace NSUI.Sample.ViewModels
{
    public class HomeViewModel
    {
        private readonly AppNavigationService _appNavigationService;

        private readonly UserService _userService;

        private ICommand _userProfileCommand;

        public HomeViewModel(AppNavigationService appNavigationService)
        {
            _appNavigationService = appNavigationService;

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

        public List<Game> Games { get; }

        public IOperable Selected { get; set; }

        public User User { get; }

        public ICommand UserProfileCommand
        {
            get
            {
                _userProfileCommand = _userProfileCommand ?? new RelayCommand(() =>
                {
                    _appNavigationService.NavigateTo(ViewModelLocator.UserProfileViewKey);
                });
                return _userProfileCommand;
            }
        }
    }
}