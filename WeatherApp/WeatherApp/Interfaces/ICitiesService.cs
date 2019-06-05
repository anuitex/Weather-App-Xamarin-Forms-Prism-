using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models.Database;

namespace WeatherApp.Interfaces
{
    public interface ICitiesService
    {
        List<CityModel> GetAllCities();
    }
}
