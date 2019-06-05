using System;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class ForecastPage : ContentPage
    {
        public ForecastPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (ForecastPageViewModel)BindingContext;

            var revertI = cardLayout.Children.Count-1;
            for (int i = 0; i < cardLayout.Children.Count; i++)
            {
                cardLayout.Children[i].BindingContext = vm.ForecastWeathers[revertI];
                revertI -= 1;
            }
        }
    }
}
