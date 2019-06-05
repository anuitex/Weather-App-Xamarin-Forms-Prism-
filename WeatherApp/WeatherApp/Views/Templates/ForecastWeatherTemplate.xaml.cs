using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForecastWeatherTemplate : Grid
	{
		public ForecastWeatherTemplate ()
		{
			InitializeComponent ();
        }

    }
}