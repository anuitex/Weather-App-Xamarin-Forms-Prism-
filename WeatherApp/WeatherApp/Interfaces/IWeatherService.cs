using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IWeatherService
    {
        Task<PeriodWeatherModel> GetCurrentWeatherByCity(int id);
        Task<List<DaysWeatherModel>> GetForecastWeatherByCity(int id);
    }
}
