using Newtonsoft.Json;
using System.Collections.Generic;

namespace Authentication.Models
{
    public class Weather
    {
        public List<WeatherInfo> WeatherTypes { get; set; }

        public Weather()
        {
            WeatherTypes = new List<WeatherInfo>();
        }
    }

    public class WeatherInfo
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("temperatureC")]
        public string TemperatureC { get; set; }

        [JsonProperty("temperatureF")]
        public string TemperatureF { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}