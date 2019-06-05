using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.Api
{
    public class WeatherInfo
    {
        public int Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public DateTime Dt_txt { get; set; }
        public Rain Rain { get; set; }
    }
}
