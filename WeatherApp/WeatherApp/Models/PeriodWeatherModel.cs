using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models.Enums;

namespace WeatherApp.Models
{
    public class PeriodWeatherModel
    {
        public PartsOfDay Title { get; set; }
        public string Description { get; set; }
        public int Humidity { get; set; }
        public int Clouds { get; set; }
        public double WindSpeed { get; set; }
        public int Temperature { get; set; }
        public double Pressure { get; set; }
        public DateTime Date { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public double SeaLevel { get; set; }
        public double GroundLevel { get; set; }
    }
}
