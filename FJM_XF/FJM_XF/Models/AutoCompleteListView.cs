using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FJM_XF.Models
{
    public class AutoCompleteListView<T> : ListView
    {
        ObservableCollection<string> entity;

        public AutoCompleteListView()
        {
            entity = new ObservableCollection<string>();
            var cell = new DataTemplate(typeof(TextCell));

            cell.SetBinding(TextCell.TextProperty, ".");

            ItemTemplate = cell;

            ItemsSource = entity;

        }

        public async Task FilterGooglePlaces(string typeName, string filter)
        {
            this.BeginRefresh();

            entity = await GoogleMapsApi.LoadPlaces(filter);
            ItemsSource = entity;

            this.EndRefresh();
        }

    }

}
