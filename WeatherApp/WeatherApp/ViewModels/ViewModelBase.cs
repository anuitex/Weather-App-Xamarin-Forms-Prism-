using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        #region Variables
        protected INavigationService _navigationService { get; private set; }
        private string _title;
        #endregion Variables

        #region Constructors
        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
          
        }
        #endregion Constructors

        #region Properties
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion Properties

        #region Methods
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
        #endregion Methods
    }
}
