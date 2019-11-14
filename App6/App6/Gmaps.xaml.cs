using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App6
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    public partial class Gmaps : ContentPage
    {
        public Gmaps()
        {
            InitializeComponent();
            UpdateMap();
        }


        List<Place> placesList = new List<Place>();

        private async void UpdateMap()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Gmaps)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("App6.Places.json");
                string text = string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }

                var resultObject = JsonConvert.DeserializeObject<Places>(text);

                foreach (var place in resultObject.results)
                {
                    placesList.Add(new Place
                    {
                        PlaceName = place.name,
                        Address = place.vicinity,
                        Location = place.geometry.location,
                        Position = new Position(place.geometry.location.lat, place.geometry.location.lng),
                        //Icon = place.icon,
                        //Distance = $"{GetDistance(lat1, lon1, place.geometry.location.lat, place.geometry.location.lng, DistanceUnit.Kiliometers).ToString("N2")}km",
                        //OpenNow = GetOpenHours(place?.opening_hours?.open_now)
                    });
                }

                MyMap.ItemsSource = placesList;
                //PlacesListView.ItemsSource = placesList;
                //var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-36.905807, 174.684850), Distance.FromKilometers(0.3)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }
    }
}
