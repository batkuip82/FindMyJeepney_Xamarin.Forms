using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM_XF.ViewModels
{

    public class MainPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        private string _title = "Find My Jeepney v0.1";
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }


        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
            }
        }

        public DelegateCommand NavigateCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(NavigateLoginCommand);
        }

        private void NavigateLoginCommand()
        {
            _navigationService.NavigateAsync("LoginPage");
        }

    }
}
