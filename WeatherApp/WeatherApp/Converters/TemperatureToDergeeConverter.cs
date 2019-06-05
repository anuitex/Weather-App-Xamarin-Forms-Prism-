using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WeatherApp.Models.Enums;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
    public class TemperatureToDergeeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var degreeType = SecureStorage.GetAsync("DegreeType");
                if (degreeType.Result == DegreeType.Celsius.ToString())
                {
                    return $"{value} °C";
                }
                if (degreeType.Result == DegreeType.Kelvins.ToString())
                {
                    return $"{value} K";
                }
                return this;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
