using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Events;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherPageViewModel : ViewModelBase
    {
        #region Variables
        private static string _currentCity;
        private int _currentCityId;

        private PeriodWeatherModel _currentWeather;
        private IEventAggregator _eventAggregator;
        private IWeatherService _weatherService; 
        #endregion Variables

        #region Constructors
        public CurrentWeatherPageViewModel(INavigationService navigationService
            , IWeatherService weatherService
            , IEventAggregator eventAggregator
            ) : base(navigationService)
        {
            Title = "Current Weather";

            _eventAggregator = eventAggregator;
            _weatherService = weatherService;

            _eventAggregator.GetEvent<RaiseCityEvent>().Subscribe(CityPropertyChangedCurrent);
            _eventAggregator.GetEvent<RaiseDegreeTypeEvent>().Subscribe(DegreeTypePropertyChangedForecast);

            GetWeatherByCity().ConfigureAwait(false);
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
                if (_currentCity == null)
                {
                    _currentCity = "London";
                }
                return _currentCity;
            }
            set
            {
                SetProperty(ref _currentCity, value);
                RaisePropertyChanged(CurrentCity);
            }
        }
      
        public PeriodWeatherModel CurrentWeather
        {
            get { return _currentWeather; }
            set { SetProperty(ref _currentWeather, value); }
        } 
        #endregion Properties

        #region Commands
        #endregion Commands

        #region Methods
        private async Task GetWeatherByCity()
        {
            if (CurrentCityId != 0)
            { 
                CurrentWeather = new PeriodWeatherModel { Temperature = 10 };

                CurrentWeather = await _weatherService.GetCurrentWeatherByCity(CurrentCityId);
            }
        }

        private void CityPropertyChangedCurrent(CityEventArgs obj)
        {
            if (obj.CityModel.Id != CurrentCityId)
            {
                CurrentCity = obj.CityModel.Name;
                CurrentCityId = obj.CityModel.Id;
                GetWeatherByCity().ConfigureAwait(false);
            }
        }

        private void DegreeTypePropertyChangedForecast(DegreeEventArgs obj)
        {
            CurrentWeather = null;
            GetWeatherByCity().ConfigureAwait(false);
        }
        #endregion Methods

    }
}
