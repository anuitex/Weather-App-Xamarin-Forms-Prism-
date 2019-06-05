using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Models.Database;

namespace WeatherApp.Events
{
    public class CityEventArgs : EventArgs
    {
        public CityModel CityModel { get; set; }

        public CityEventArgs(CityModel city)
        {
            CityModel = city;
        }
    }

    public class DegreeEventArgs : EventArgs
    {
        public CityModel CityModel { get; set; }

        public DegreeEventArgs(CityModel city)
        {
            CityModel = city;
        }
    }

    public class RaiseCityEvent : PubSubEvent<CityEventArgs> { }
    public class RaiseDegreeTypeEvent : PubSubEvent<DegreeEventArgs> { }
}
