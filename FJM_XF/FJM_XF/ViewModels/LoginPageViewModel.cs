using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM_XF.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        private string _usernameLabel = "Username";
        private string _passwordLabel = "Password";

        public string UsernameLabel
        {
            get { return _usernameLabel; }
            set
            {
                SetProperty(ref _usernameLabel, value);
            }
        }

        public string PasswordLabel
        {
            get { return _passwordLabel; }
            set
            {
                SetProperty(ref _passwordLabel, value);
            }
        }

        public DelegateCommand NavigateToMapCommand { get; private set; }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToMapCommand = new DelegateCommand(NavigationMap);

        }

        public void NavigationMap()
        {
            _navigationService.NavigateAsync("MapPage");
        }

    }
}
