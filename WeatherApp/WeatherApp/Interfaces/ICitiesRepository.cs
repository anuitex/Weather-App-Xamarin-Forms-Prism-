using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherApp.Models.Database;

namespace WeatherApp.Interfaces
{
    public interface ICitiesRepository:IBaseRepository<CityModel,int>
    {
       
    }
}
