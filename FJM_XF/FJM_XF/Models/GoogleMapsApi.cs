using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace FJM_XF.Models
{
    public class GoogleMapsApi
    {
        public Map map = new Map();
        static readonly string _autoCompleteGoogleApi = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
        static readonly string _googleApiKey = "AIzaSyDtbJWjyNAXHR6jDTHnYs_0KBsnBMkYVrA";
        readonly string _geoCodingUrl = "https://maps.googleapis.com/maps/api/geocode/json";
        static private string[] _predictiveText;
        static private int _index;

        public static async Task<ObservableCollection<string>> LoadPlaces(string term)
        {
            var stringResult = await DownloadGooglePlacesString(_autoCompleteGoogleApi + term + "&key=" + _googleApiKey);
            if (!string.IsNullOrEmpty(stringResult) && stringResult != "Exception")
            {
                var jsonResult = JsonConvert.DeserializeObject<GooglePlaces>(stringResult);
                if (jsonResult.status == "OK")
                {
                    List<Prediction> predictions = jsonResult.predictions;
                    // make an array with length the number of predictions
                    _predictiveText = new string[jsonResult.predictions.Count];
                    _index = 0;
                    foreach (Prediction p in jsonResult.predictions)
                    {
                        //fill the array with the descriptions
                        _predictiveText[_index] = p.description;
                        _index++;
                    }
                    return new ObservableCollection<string>(_predictiveText);
                }
            }
            return null;
        }

        private static async Task<string> DownloadGooglePlacesString(string url)
        {
            var result = new HttpResponseMessage();
            var httpClient = new HttpClient();
            try
            {
                result = await httpClient.GetAsync(new Uri(url));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                httpClient.Dispose();
                httpClient = null;
            }

            if (!result.IsSuccessStatusCode)
            {
                return "Exception";
            }

            return await result.Content.ReadAsStringAsync();
        }

        public static async Task<List<Position>> GetMapPositionFromAddress(string address)
        {
            var geoCoder = new Geocoder();
            var pos = await geoCoder.GetPositionsForAddressAsync(address);
            return pos.ToList();
        }

        public static List<MapSpan> GetMapSpan(List<Position> pos, Distance distance)
        {
            var mapSpans = new List<MapSpan>();
            foreach (Position p in pos)
            {
                GetMapSpan(p, distance);
            }

            return mapSpans;
        }

        public static MapSpan GetMapSpan(Position pos, Distance distance)
        {
            return MapSpan.FromCenterAndRadius(pos, distance);
        }

        public static void SetMoveToRegion(Map map, Position pos, Distance distance)
        {
            map.MoveToRegion(GetMapSpan(pos, distance));
        }








        //private static LatLngBounds getBounds(LatLng[] latLng)
        //{
        //    LatLngBounds.Builder b = new LatLngBounds.Builder();

        //    for (int i = 0; i < latLng.Length; i++)
        //    {
        //        b.Include(latLng[i]);
        //    }

        //    LatLngBounds bounds = b.Build();
        //    return bounds;
        //}

        //private static LatLng getCenterPosition(LatLng[] position)
        //{
        //    var lat = new double[position.Length];
        //    var lng = new double[position.Length];

        //    var index = 0;
        //    foreach (var p in position)
        //    {
        //        lat[index] = p.Latitude;
        //        lng[index] = p.Longitude;
        //        index++;
        //    }

        //    var centeredLat = lat.Average();
        //    var centeredLng = lng.Average();

        //    LatLng centeredPosition = new LatLng(centeredLat, centeredLng);
        //    return centeredPosition;
        //}

        //private static async Task<string> getGoogleMapsApiUrl(string searchText)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(_geoCodingUrl);
        //    sb.Append("?address=").Append(searchText);
        //    string stringResult = await DownloadGooglePlacesString(sb.ToString());

        //    return stringResult;
        //}

        //private static void updateCameraPosition(Latlng pos, LatLngBounds bounds = null)
        //{


        //    int w = mapFrag.View.Width;
        //    int h = mapFrag.View.Height;
        //    CameraUpdate cu = CameraUpdateFactory.NewLatLngBounds(bounds, w, h, 100);
        //    map.AnimateCamera(cu);
        //}

        //private static void markOnMap(string title, LatLng pos, string status)
        //{
        //    float icon = status == "to" ? 240 : 0;
        //    RunOnUiThread(() =>
        //    {
        //        var marker = new MarkerOptions();
        //        marker.SetTitle(title);
        //        marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(icon));
        //        marker.SetPosition(pos);
        //        map.AddMarker(marker);
        //    });
        //}



    }
}
