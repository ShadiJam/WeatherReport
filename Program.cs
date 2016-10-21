using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather2 {
    class Program {
        public static void Main(){
            prompt().Wait();
        }

        public static async Task prompt(){
            Console.WriteLine("Welcome to the Weather Report! Enter your city and state or your zip code:");
            string addInput = Console.ReadLine();
            API googleUrl = new API($"https://maps.googleapis.com/maps/api/geocode/json?address={addInput}&key=AIzaSyBRBZtk0JyJrAzmp2i9DklBHhjvKwoI0JE");
            // creates a variable called data and assigns it the value of the data being received from googleUrl (google API)
            GoogleRO data = await googleUrl.GetData<GoogleRO>();
            // pulls data returned from googleUrl (googles API) into two doubles, one for lat, and one for lng.
            var lat1 = data.results.ElementAt(0).geometry.location.lat;
            var lng1 = data.results.ElementAt(0).geometry.location.lng;
            var darkKey = "589b4821461ba16c289f8b67fe662445";
            // sending lat and lng to darkSkyUrl (darkSky API) 
            API darkSkyUrl = new API($"https://api.darksky.net/forecast/{darkKey}/{lat1},{lng1}");
            // creates variable called data2 and assigns it the value of the weather report being receives from darkSkyUrl (DarkSky API)
            darkSkyRO data2 = await darkSkyUrl.GetData<darkSkyRO>();
            // need to figure out how to print the correct info. Currently 
            // only printing Weather2.CurrentlyWeather2.Daily
            string currently = data2.currently.ToString();
            string daily = data2.daily.ToString();
            Console.WriteLine(currently+" "+daily);

    
        }    
    }
}     

