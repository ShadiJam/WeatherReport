using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather2
{
    class Program
    {
        private HttpClient _http = new HttpClient();

        public static async Task Main()
        {
            var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keys.json")));
            Console.WriteLine("Welcome to the Weather Report! Enter your city and state or your zip code:");
            string addInput = Console.ReadLine();

            var response = await _http.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={addInput}&key={config.GoogleKey}");
            var jgoogle = JObject.Parse(await response.Content.ReadAsStringAsync());

            // pulls data returned from googleUrl (googles API) into two doubles, one for lat, and one for lng.
            var lat1 = jgoogle["results"]["geometry"]["location"]["lat"].ToString();
            var lng1 = jgoogle["results"]["geometry"]["location"]["lng"].ToString();
            // sending lat and lng to darkSkyUrl (darkSky API) 
            var darkdata = await _http.GetAsync($"https://api.darksky.net/forecast/{config.DarkKey}/{lat1},{lng1}");
            // printing results from darkSky API
            var tempNow = data2.Currently.ApparentTemperature.ToString();
            string summary = data2.Currently.Summary.ToString();
            string hourly = data2.Hourly.Summary.ToString();
            string sunRise = data2.Daily.SunriseTime.ToString();
            string sunSet = data2.Daily.SunsetTime.ToString();
            Console.WriteLine(string.Format(@"The temperature is currently {0} degrees. 
            The forecast is {1} and will be {2}. 
            Sunrise will be at {3} and sunset will be at {4}", tempNow, summary, hourly, sunRise, sunSet));
        }
    }
}