using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Models.Database;
using WeatherApp.Repositiries;

namespace WeatherApp.Services
{
    public class CitiesService : ICitiesService
    {
        ICitiesRepository citiesRepository;

        public CitiesService(SQLiteConnection databaseConnectionService)
        {
            citiesRepository = new CitiesRepository(databaseConnectionService);
        }

        public List<CityModel> GetAllCities()
        {
            return citiesRepository.GetAll();
        }
    }
}
