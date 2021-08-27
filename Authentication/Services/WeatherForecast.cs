using Authentication.Models;
using Authentication.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class WeatherForecast : IWeatherForecast
    {
        private readonly IConfiguration _config;

        public WeatherForecast(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Weather> Get()
        {
            var weather = new Weather();
            var url = _config.GetValue<string>("ApplicationServices:WeatherForecastAPI");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlByYWRlZXAiLCJuYmYiOjE2MzAwNTE1MTEsImV4cCI6MTYzMDA1NTExMSwiaWF0IjoxNjMwMDUxNTExfQ.d3XEe1P-iaevonWF4GUu2FAI__Xq91HxN08lo918duo");
            using (var response = await httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    weather.WeatherTypes.AddRange(JsonConvert.DeserializeObject<List<WeatherInfo>>(result));

                    return weather;
                }
            }
            return null;
        }
    }
}