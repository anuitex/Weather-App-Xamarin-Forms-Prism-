using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Events;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class ForecastPageViewModel : ViewModelBase
    {
        #region Variables
        private IEventAggregator _eventAggregator;
        private IWeatherService _weatherService;
        private int _currentCityId;
        private static string _currentCity;
        private List<DaysWeatherModel> _forecastWeather;
        #endregion Variables

        #region Constructors
        public ForecastPageViewModel(INavigationService navigationService
            ,IWeatherService weatherService
            , IEventAggregator eventAggregator
            ) : base(navigationService)
        {
            _weatherService = weatherService;
            _eventAggregator = eventAggregator;
            Title = "Forecast Page";
            _eventAggregator.GetEvent<RaiseCityEvent>().Subscribe(CityPropertyChangedForecast);
            _eventAggregator.GetEvent<RaiseDegreeTypeEvent>().Subscribe(DegreeTypePropertyChangedForecast);
        }
        #endregion Constructors

        #region Properties
        public int CurrentCityId
        {
            get { return _currentCityId; }
            set { SetProperty(ref _currentCityId, value); }
        }

        public string CurrentCity
        {
            get
            {
                return _currentCity;
            }
            set
            {
                SetProperty(ref _currentCity, value);
                RaisePropertyChanged(CurrentCity);
            }
        }
 
        public List<DaysWeatherModel> ForecastWeathers
        {
            get { return _forecastWeather; }
            set { SetProperty(ref _forecastWeather, value); }
        }
        #endregion Properties

        #region Methods
        private async void GetForecastWeatherByCity()
        {
                ForecastWeathers = await _weatherService.GetForecastWeatherByCity(CurrentCityId);
        }

        private void CityPropertyChangedForecast(CityEventArgs obj)
        {
            if(obj.CityModel.Id != CurrentCityId)
            {
                CurrentCity = obj.CityModel.Name;
                CurrentCityId = obj.CityModel.Id;
                ForecastWeathers = null;
                GetForecastWeatherByCity();
            }

        }

        private void DegreeTypePropertyChangedForecast(DegreeEventArgs obj)
        {
            ForecastWeathers = null;
            GetForecastWeatherByCity();
        }

        #endregion Methods

    }
}
