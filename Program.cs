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
            // creates variable called data2 and assigns it the value of the weather report being received from darkSkyUrl (DarkSky API)
            darkSkyRO data2 = await darkSkyUrl.GetData<darkSkyRO>();
            // printing results from darkSky API
            var tempNow = data2.currently.apparentTemperature.ToString();
            string summary = data2.currently.summary.ToString();
            string hourly = data2.hourly.summary.ToString();
            string sunRise = data2.daily.sunriseTime.ToString();
            string sunSet = data2.daily.sunsetTime.ToString();
            Console.WriteLine(@"The temperature is currently {tempNow} degrees. 
            The forecast is {summary} and will be {hourly}. 
            Sunrise will be at {sunRise} and sunset will be at {sunSet}");

    
        }    
    }
}     

