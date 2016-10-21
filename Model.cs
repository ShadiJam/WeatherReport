using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather2 {
// dark sky output
    public class darkSkyRO
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
    
// geo locator output 

public class GoogleRO
{
        public List<Result> results { get; set;}
}
public class Result
{
    public Geometry geometry { get; set; }
}
public class Geometry
{
    public Location location { get; set; }
}

public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}

}
