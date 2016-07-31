using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FJM_XF.ViewModels
{
    public class LocationViewModel : ILocationViewModel
    {
        public ICommand Command
        {
            get;
        }

        public string Description
        {
            get; set;
        }

        public double Latitude
        {
            get; set;
        }

        public double Longitude
        {
            get; set;
        }

        public string Title
        {
            get;

            set;
        }
    }
}
