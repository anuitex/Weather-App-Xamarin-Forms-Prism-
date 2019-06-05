using Prism;
using Prism.Ioc;
using SQLite;
using WeatherApp.Helpers;
using WeatherApp.Interfaces;
using WeatherApp.Repositiries;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {

        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTAxMDk0QDMxMzcyZTMxMmUzME5YR2tiaEQyaEdLc3IxbG5MK2ZRWmlyaDRzZ3lzWUhQUThIdlMrOGNtQ1E9");
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            SQLiteConnection connection = DatabaseConnectionHelper.GetDatebaseConnection();
            containerRegistry.RegisterInstance<ICitiesRepository>(new CitiesRepository(connection));
            containerRegistry.RegisterInstance<ICitiesService>(new CitiesService(connection));

            containerRegistry.RegisterInstance<IWeatherService>(new WeatherService());

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CurrentWeatherPage, CurrentWeatherPageViewModel>();
            containerRegistry.RegisterForNavigation<ForecastPage, ForecastPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
        }
    }
}
