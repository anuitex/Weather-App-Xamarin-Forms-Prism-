using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.Api
{
    public class ForecastWeather
    {
        public string Cod { get; set; }
        public double Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherInfo> List { get; set; }
        public City City { get; set; }
    }
}

