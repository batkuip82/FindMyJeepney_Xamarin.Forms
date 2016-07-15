using Prism.Unity;
using Prism.Navigation;
using Prism.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism;

using Xamarin.Forms;
using FJM_XF.ViewModels;
using FJM_XF.Views;

namespace FJM_XF
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<MapPage>();
        }
    }
}
