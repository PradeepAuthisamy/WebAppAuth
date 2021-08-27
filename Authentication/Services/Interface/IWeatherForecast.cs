using Authentication.Models;
using System.Threading.Tasks;

namespace Authentication.Services.Interface
{
    public interface IWeatherForecast
    {
        Task<Weather> Get();
    }
}