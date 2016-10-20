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
            darkSkyRO data = await googleUrl.GetData<darkSkyRO>();
            Console.WriteLine(data.results.Count());
            Console.WriteLine(JsonConvert.SerializeObject(data));

            //at this point we've pulled the lat and lng from google api and need to send it to dark sky to get the weather
         //   var latLng= String.Format("{0},{1}", lat, lng);
         //   var darkSkyKey = "589b4821461ba16c289f8b67fe662445";
         //   var darkSkyUrl = String.Format("https://api.darksky.net/forecast/d353c94884828ab143c8633437f899aa/{1},{2}", darkSkyKey, m.lat, m.lng);
        }
    }
}

/*
        
            
            string reply = newUser.DownloadString(googleUrl);
            Location m = JsonConvert.DeserializeObject<Location>(reply);
            var newUser = new WebClient();
           

            
           
            
        }

     
        // ask client for address/zip/city and state - DONE
        // take input and send that to geo locator which locates lng and lat - DONE
        // take return from geolocator and input into darksky - 
        // return forecast from darksky that includes the following: 
        //      currently, 
        //      daily for next 8 days, 
        //      sunrise and sunsetTime
        //      

        
        }
    }
}
*/
