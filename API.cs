using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather2 {
    class API {
        private string url;

        public API(string url){
            this.url = url;
        }

        public virtual async Task<string> GetJSON(){
            var http = new HttpClient();
            string reply = await http.GetStringAsync(this.url);
            return reply;
        }

        public async Task<T> GetData<T>(){
            string json = await GetJSON();
            T instance = JsonConvert.DeserializeObject<T>(json);
            return instance;
        }
    }




}

/*
        public static void Main(string[] args)
        {
            prompt().Wait();
            Console.WriteLine("Welcome to the Weather Report! Please enter your city and state, or your zip code to see the weather forecast!");
            string addInput = Console.ReadLine();
            Console.ReadLine();
            var geoKey = "AIzaSyDeOZwDv9PR7Wk5aL9l8KxUlTIDZzXmC4w";
            
            var googleUrl = String.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", addInput, geoKey);
            var newUser = new WebClient();
            string reply = newUser.DownloadString(googleUrl);
            Location m = JsonConvert.DeserializeObject<Location>(reply);

            var latLng= String.Format("{0},{1}", m.lat, m.lng);
            var darkSkyKey = "589b4821461ba16c289f8b67fe662445";
            var darkSkyUrl = String.Format("https://api.darksky.net/forecast/{0}/{1}", darkSkyKey, latLng);
            
        }

        public static async Task prompt(){
            string input = Console.ReadLine();
            string result = await getUrl("http://google.com"+input);
            

            Console.WriteLine(result);
        }

        public static async Task<string> getUrl(string url){
            var http = new HttpClient();
            string reply = await http.GetStringAsync(url);
            return reply;
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