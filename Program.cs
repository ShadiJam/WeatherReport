using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApplication
{
    public class Program
    {
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
        // take input and send that to geo locator which locates lng and lat
        // take return from geolocator and input into darksky
        // return forecast from darksky that includes the following:
        //      currently, 
        //      daily for next 8 days, 
        //      sunrise and sunsetTime
        //      

        
        }
// dark sky output
    public class RootObject
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string timezone { get; set; }
    public int offset { get; set; }
    public Currently currently { get; set; }
    public Minutely minutely { get; set; }
    public Hourly hourly { get; set; }
    public Daily daily { get; set; }
 
}
public class Minutely
{
    public string summary { get; set; }
    public string icon { get; set; }
     public int time { get; set; }
    public int precipIntensity { get; set; }
    public int precipProbability { get; set; }


}
public class Currently : Minutely
{
   
    public double temperature { get; set; }
    public double apparentTemperature { get; set; }
    public double dewPoint { get; set; }
    public double humidity { get; set; }
    public double windSpeed { get; set; }
    public int windBearing { get; set; }
    public double visibility { get; set; }
    public double cloudCover { get; set; }
  
}

public class Hourly : Minutely
{
    public double temperature { get; set; }
    public double apparentTemperature { get; set; }
    public double dewPoint { get; set; }
    public double humidity { get; set; }
    public double windSpeed { get; set; }
    public int windBearing { get; set; }
    public double visibility { get; set; }
    public double cloudCover { get; set; }

}
public class Daily : Hourly
{
    public int sunriseTime { get; set; }
    public int sunsetTime { get; set; }
    public double moonPhase { get; set; }
  
    public double temperatureMin { get; set; }
    public double temperatureMax { get; set; }

}
    }
}
// geo locator output 
public class AddressComponent
{
    public string long_name { get; set; }
    public string short_name { get; set; }
    public List<string> types { get; set; }
}

public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Northeast
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Southwest
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Viewport
{
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
}

public class Geometry
{
    public Location location { get; set; }
    public string location_type { get; set; }
    public Viewport viewport { get; set; }
}

public class Result
{
    public List<AddressComponent> address_components { get; set; }
    public string formatted_address { get; set; }
    public Geometry geometry { get; set; }
    public string place_id { get; set; }
    public List<string> types { get; set; }
}

public class RootObject
{
    public List<Result> results { get; set; }
    public string status { get; set; }
}


