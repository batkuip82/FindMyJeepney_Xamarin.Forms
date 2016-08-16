using FJM_XF.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System;

namespace FJM_XF.ViewModels
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class MapPageViewModel : BindableBase
    {
        public DelegateCommand SearchChangedCommand { get; private set; }

        public DelegateCommand ItemTappedCommand { get; private set; }

        private string _currentSearch = string.Empty; 
        public string CurrentSearch
        {
            get { return _currentSearch; }
            set
            {
                SetProperty(ref _currentSearch, value); //try to set thirth param
            }
        }

        private List<LocationViewModel> _locationItems;
        public List<LocationViewModel> LocationItems
        {
            get { return this._locationItems; }
            set
            {
                SetProperty(ref this._locationItems, value);
            }
        }

        private ObservableCollection<string> _searchItems = new ObservableCollection<string>();
        public ObservableCollection<string> SearchItems
        {
            get { return _searchItems; }
            set
            {
                SetProperty(ref _searchItems, value);
            }
        }

        private string _addressSelected = "";
        public string AddressSelected
        {
            get { return _addressSelected; }
            set
            {
                SetProperty(ref _addressSelected, value);
            }
        }



        private bool _showMap;
        public bool ShowMap
        {
            get { return _showMap; }
            set
            {
                SetProperty(ref _showMap, value);
            }
        }

        private bool _showList;
        public bool ShowList
        {
            get { return _showList; }
            set
            {
                SetProperty(ref _showList, value);
            }
        }




        public MapPageViewModel()
        {
            //OnPropertyChanged(() => LocationItems);
            _locationItems = new List<LocationViewModel>();
            _locationItems.Add(setDefaultLocation());

            _showMap = true;
            SearchChangedCommand = new DelegateCommand(async () => await SearchGooglePlace());
            ItemTappedCommand = new DelegateCommand(async () => await SetGooglePin());
        }

        private async Task SetGooglePin()
        {
            ShowList = false;
            ShowMap = true;

            var positionLocation = await GoogleMapsApi.GetMapPositionFromAddress(AddressSelected);
            var location = new LocationViewModel
            {
                Latitude = positionLocation[0].Latitude,
                Longitude = positionLocation[0].Longitude,
                Title = AddressSelected,
                Description = ""
            };

            _locationItems.Add(location);
            OnPropertyChanged(() => LocationItems);
            CurrentSearch = AddressSelected;
        }

        private LocationViewModel setDefaultLocation()
        {
            var locations = new LocationViewModel { Title = "Makati", Latitude = 14.554729, Longitude = 121.02444, Description = "test" };
            return locations;
        }

        private bool canSearch()
        {
            if (string.IsNullOrEmpty(CurrentSearch))
            {
                return false;
            }

            return true;
        }

        private async Task SearchGooglePlace()
        {
            if (!string.IsNullOrWhiteSpace(CurrentSearch) && string.IsNullOrWhiteSpace(AddressSelected))
            {
                ShowMap = false;
                SearchItems = await GoogleMapsApi.LoadPlaces(CurrentSearch);
                ShowList = true;
            }
            else
            {
                ShowMap = true;
                ShowList = false;
            }

            AddressSelected = null;

            

            //if (!string.IsNullOrWhiteSpace(CurrentSearch))
            //{
            //    SearchItems = new ObservableCollection<LocationViewModel>(temp.Where(p => p.Title.ToLower().Contains(CurrentSearch.ToLower())).ToList());
            //}
            //else
            //{
            //    SearchItems = new ObservableCollection<LocationViewModel>(temp);
            //}

        }


    }
}
