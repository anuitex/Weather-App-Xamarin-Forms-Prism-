using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.Database
{
    public class CityModel:BaseModel<int>
    {
        public string Country { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
