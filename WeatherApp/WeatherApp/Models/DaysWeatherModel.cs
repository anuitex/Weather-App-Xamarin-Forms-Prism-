using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class DaysWeatherModel
    {
       public List<PeriodWeatherModel> WeatherInfos { get; set; }
       public DateTime Date { get; set; }
    }
}
