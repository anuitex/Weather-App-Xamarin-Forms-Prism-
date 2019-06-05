using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models.Enums;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Constructors
        public MainPageViewModel(INavigationService navigationService
            ) : base(navigationService)
        {
            Title = "Main Page";
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
         
        }
        #endregion Constructors

        #region Commands
        public DelegateCommand<string> NavigateCommand { get; }

        public DelegateCommand LaunchDynamicTabbedPageCommand { get; }
        #endregion Commands

        #region Methods
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        private void OnNavigateCommandExecuted(string path) =>
            _navigationService.NavigateAsync(path);

        #endregion Methods
    }
}
