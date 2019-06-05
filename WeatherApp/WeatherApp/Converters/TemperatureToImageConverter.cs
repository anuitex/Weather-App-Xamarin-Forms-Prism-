using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WeatherApp.Models.Enums;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
   public class TemperatureToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var degreeType = SecureStorage.GetAsync("DegreeType");
                if (degreeType.Result == DegreeType.Kelvins.ToString())
                {
                    value =(int)((int)value - 273.15);   
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if ((int)value > 25)
            {
                return "SummerWeather";
            }
            if ((int)value < 25 && (int)value>0)
            {
                return "SprintWeather";
            }
            if ((int)value < 0)
            {
                return "WinterWeather";
            }

            return this;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
