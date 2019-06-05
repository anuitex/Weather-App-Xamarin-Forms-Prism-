using Newtonsoft.Json;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Linq;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using Prism.Events;
using WeatherApp.Events;
using WeatherApp.Models.Database;
using WeatherApp.Models.Enums;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace WeatherApp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Variable
        private readonly ICitiesService _citiesService;
       private IEventAggregator _eventAggregator;
        private ObservableCollection<CityModel> _cities;
        private string _selectedCountry;
        private List<string> _regions;
        private List<CityModel> _citiesInCountry;
        private CityModel _selectedCity;
        private DegreeType _selectedDegreeType;
        private List<DegreeType> _degreeTypes = new List<DegreeType>() { DegreeType.Celsius, DegreeType.Kelvins };
        #endregion Variable

        #region Constructors
        public SettingsPageViewModel(INavigationService navigationService
            , ICitiesService citiesService
             , IEventAggregator eventAggregator
            ) : base(navigationService)
        {
            _citiesService = citiesService;
            _eventAggregator = eventAggregator;
            Title = "Settings Page";
            GetDegreeType();
            LoadCitiesFromDatabase();
          
        }
        #endregion Constructors

        #region Property
        public ObservableCollection<CityModel> Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new ObservableCollection<CityModel>();
                }
                return _cities;
            }
            set { SetProperty(ref _cities, value); }
        }

        public List<string> Regions
        {
            get { return _regions; }
            set { SetProperty(ref _regions, value); }
        }

        public List<CityModel> CitiesInCountry
        {
            get { return _citiesInCountry; }
            set { SetProperty(ref _citiesInCountry, value); }
        } 

        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                //SelectedCity = null;
                var cities = Cities.Where(x => x.Country == value).ToList();
                CitiesInCountry = new List<CityModel>();
                foreach (var city in cities)
                {
                    CitiesInCountry.Add(city);
                }
                SelectedCity = CitiesInCountry[0];
                SetProperty(ref _selectedCountry, value);
                
            }
        }

        public CityModel SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _selectedCity, value);
                    _eventAggregator.GetEvent<RaiseCityEvent>().Publish(new CityEventArgs(value));
                }
            }
        }
        
        public DegreeType SelectedDegreeType
        {
            get { return _selectedDegreeType; }
            set {
                SetProperty(ref _selectedDegreeType, value);
                try
                {
                    SecureStorage.SetAsync("DegreeType", value.ToString());
                    _eventAggregator.GetEvent<RaiseDegreeTypeEvent>().Publish(new DegreeEventArgs(null));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;
            }
        }
        
        public List<DegreeType> DegreeTypes
        {
            get { return _degreeTypes; }
            set { SetProperty(ref _degreeTypes, value); }
        }
        #endregion Property

        #region Methods
        public void LoadCitiesFromDatabase()
        {
            var cities = _citiesService.GetAllCities();
            Cities = new ObservableCollection<CityModel>(cities);

            var countries = from cityModel in Cities
                              group cityModel by cityModel.Country;
            
            Regions = new List<string>();
            foreach (IGrouping<string, CityModel> group in countries)
            {
                Regions.Add(group.Key);
            }
            SelectedCountry = Regions[0];
        }

        public async void GetDegreeType()
        {
            try
            {
                var degreeType = await SecureStorage.GetAsync("DegreeType");
                if (degreeType == DegreeType.Celsius.ToString())
                {
                    SelectedDegreeType = DegreeTypes[0];
                    _eventAggregator.GetEvent<RaiseDegreeTypeEvent>().Publish(new DegreeEventArgs(null));

                    return;
                }
                SelectedDegreeType = DegreeTypes[1];
                _eventAggregator.GetEvent<RaiseDegreeTypeEvent>().Publish(new DegreeEventArgs(null));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion Methods
    }
}
