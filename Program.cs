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
            var geoKey = "AIzaSyDeOZwDv9PR7Wk5aL9l8KxUlTIDZzXmC4w";
            API googleUrl = new API($"https://maps.googleapis.com/maps/api/geocode/json?address={addInput}&key={geoKey}");
            darkSkyRO data = await googleUrl.GetData<darkSkyRO>();
            Console.WriteLine(data.results.Count());
            Console.WriteLine(JsonConvert.SerializeObject(data));

            //at this point we've pulled the lat and lng from google api and need to send it to dark sky to get the weather
            data = String.Format("{0},{1}", m.lat, m.lng);
            
            var darkSkyUrl = String.Format("https://api.darksky.net/forecast/{0}/{1}", darkSkyKey, latLng);
        }
    }
}

/*
        public static void Main(string[] args)
        {
            prompt().Wait();
   
            
            var googleUrl = String.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", addInput, geoKey);
            var newUser = new WebClient();
            string reply = newUser.DownloadString(googleUrl);
            Location m = JsonConvert.DeserializeObject<Location>(reply);

            var latLng= String.Format("{0},{1}", m.lat, m.lng);
            var darkSkyKey = "589b4821461ba16c289f8b67fe662445";
            var darkSkyUrl = String.Format("https://api.darksky.net/forecast/{0}/{1}", darkSkyKey, latLng);
            
        }

     
        // ask client for address/zip/city and state - DONE
        // take input and send that to geo locator which locates lng and lat - DONE?
        // take return from geolocator and input into darksky - DONE?
        // return forecast from darksky that includes the following: 
        //      currently, 
        //      daily for next 8 days, 
        //      sunrise and sunsetTime
        //      

        
        }
    }
}
*/
