using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace FJM_XF.Models
{
    class JeepneyDetail
    {
        public string DriverName { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string Image { get; set; }

        public Position Position { get; set; }

        public static List<JeepneyDetail> GetJeepneyList()
        {
            var jeepneyList = new List<JeepneyDetail>()
            {
                new JeepneyDetail
                {
                    DriverName = "Kees",
                    Description = "Lorum ipsum",
                    Route = "Ayala - Zapote",
                    Image = "This should be an image",
                    Position = new Position()

                },
                new JeepneyDetail
                {
                    DriverName = "Jan",
                    Description = "Lorum ipsum",
                    Route = "Ayala - Zapote",
                    Image = "This should be an image"

                },
                new JeepneyDetail
                {
                    DriverName = "Piet",
                    Description = "Lorum ipsum",
                    Route = "Ayala - Zapote",
                    Image = "This should be an image"

                }
            };

            return jeepneyList;
            
        }
    }
}
