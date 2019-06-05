using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherApp.Interfaces;
using WeatherApp.Models.Database;

namespace WeatherApp.Repositiries
{
    public class CitiesRepository : BaseRepository<CityModel, int>, ICitiesRepository
    {
        public CitiesRepository(SQLiteConnection databaseConnectionService) 
            : base(databaseConnectionService)
        {

        }

      
    }
}
