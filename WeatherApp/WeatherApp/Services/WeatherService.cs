using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helpers;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Models.Api;
using WeatherApp.Models.Enums;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClientHelper _httpClientHelper = new HttpClientHelper();
           
        public async Task<PeriodWeatherModel> GetCurrentWeatherByCity(int id)
        {
            try
            {
                string templateUrl = $"{Constants.ApiUrl}/weather/?id={id}&appid={Constants.ApiKey}";
                var degreeType = await SecureStorage.GetAsync("DegreeType");
                if (degreeType == DegreeType.Celsius.ToString())
                {
                    templateUrl = $"{templateUrl}&units=metric";
                }
                WeatherInfo response = await _httpClientHelper.PerformGet<WeatherInfo>(templateUrl);
                PeriodWeatherModel periodWeatherModel = GetPeriodWeatherModel(PartsOfDay.defaultPart, response);
                return periodWeatherModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<DaysWeatherModel>> GetForecastWeatherByCity(int id)
        {
            try
            {
                string templateUrl = $"{Constants.ApiUrl}/forecast?id={id}&appid={Constants.ApiKey}";
                var degreeType = await SecureStorage.GetAsync("DegreeType");
                if (degreeType == DegreeType.Celsius.ToString())
                {
                    templateUrl = $"{templateUrl}&units=metric";
                }
                ForecastWeather response = await _httpClientHelper.PerformGet<ForecastWeather>(templateUrl);
                List<DaysWeatherModel> listDays = GetListDaysWeather(response);
                return listDays;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        } 
        
        private List<DaysWeatherModel> GetListDaysWeather(ForecastWeather forecastWeather)
        { 
            List<DaysWeatherModel> days = new List<DaysWeatherModel>();

            List<WeatherInfo> templateList = forecastWeather.List;
            var daysWeathers = templateList.GroupBy(x => x.Dt_txt.Date);  

            foreach (var group in daysWeathers)
            {
                DaysWeatherModel day = new DaysWeatherModel();
                day.WeatherInfos = new List<PeriodWeatherModel>();

                day.Date = group.Key;
                day.WeatherInfos.Add(group.Where(item => item.Dt_txt.Hour <= 6).Select(period => GetPeriodWeatherModel(PartsOfDay.Night, period)).FirstOrDefault());
                day.WeatherInfos.Add(group.Where(item => item.Dt_txt.Hour >= 7 && item.Dt_txt.Hour <= 11).Select(period => GetPeriodWeatherModel(PartsOfDay.Morning, period)).FirstOrDefault());
                day.WeatherInfos.Add(group.Where(item => item.Dt_txt.Hour >= 12 && item.Dt_txt.Hour <= 18).Select(period => GetPeriodWeatherModel(PartsOfDay.Day, period)).FirstOrDefault());
                day.WeatherInfos.Add(group.Where(item => item.Dt_txt.Hour >= 19 && item.Dt_txt.Hour <= 24).Select(period => GetPeriodWeatherModel(PartsOfDay.Evening, period)).FirstOrDefault());

                for (int i = 3; i >=0; i--)
                {
                    if (day.WeatherInfos[i] == null)
                        day.WeatherInfos.Remove(day.WeatherInfos[i]); 
                }
                days.Add(day);
            }
           
            return days;
        }

        private PeriodWeatherModel GetPeriodWeatherModel(PartsOfDay title, WeatherInfo item)
        {
            PeriodWeatherModel period = new PeriodWeatherModel
            {
                Title = title,
                Description = item.Weather[0].Description,
                Humidity = item.Main.Humidity,
                Clouds = item.Clouds.All,
                WindSpeed = item.Wind.Speed,
                Temperature = Convert.ToInt32(item.Main.Temp),
                Date = item.Dt_txt,
                GroundLevel = item.Main.Grnd_level,
                SeaLevel = item.Main.Sea_level,
                TempMax = Convert.ToInt32(item.Main.Temp_max),
                TempMin = Convert.ToInt32(item.Main.Temp_min),
                Pressure = item.Main.Pressure
            };
            return period;
        }

    }
}
