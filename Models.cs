using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather2
{
    public struct Config
    {
        [JsonProperty("darkKey")]
        public string DarkKey { get; private set; }

        [JsonProperty("googleKey")]
        public string GoogleKey { get; private set; }
    }

    // dark sky output
    public class DarkSkyRO
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("currently")]
        public Currently Currently { get; set; }

        [JsonProperty("minutely")]
        public Minutely Minutely { get; set; }

        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }

        [JsonProperty("daily")]
        public Daily Daily { get; set; }
    }

    public class Minutely
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("precipIntensity")]
        public int PrecipIntensity { get; set; }

        [JsonProperty("precipProbability")]
        public int PrecipProbability { get; set; }
    }

    public class Currently : Minutely
    {
        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("apparentTemperature")]
        public double ApparentTemperature { get; set; }

        [JsonProperty("dewPoint")]
        public double DewPoint { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty("windBearing")]
        public int WindBearing { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("cloudCover")]
        public double CloudCover { get; set; }
    }

    public class Hourly : Minutely
    {
        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("apparentTemperature")]
        public double ApparentTemperature { get; set; }

        [JsonProperty("dewPoint")]
        public double DewPoint { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty("windBearing")]
        public int WindBearing { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("cloudCover")]
        public double CloudCover { get; set; }
    }

    public class Daily : Hourly
    {
        [JsonProperty("sunriseTime")]
        public int SunriseTime { get; set; }

        [JsonProperty("sunsetTime")]
        public int SunsetTime { get; set; }

        [JsonProperty("moonPhase")]
        public double MoonPhase { get; set; }

        [JsonProperty("temperatureMin")]
        public double TemperatureMin { get; set; }

        [JsonProperty("temperatureMax")]
        public double TemperatureMax { get; set; }
    }
}