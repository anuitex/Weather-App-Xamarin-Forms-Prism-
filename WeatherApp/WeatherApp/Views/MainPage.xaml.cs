using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class MainPage : TabbedPage, INavigatingAware
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            foreach (var child in Children)
            {
                (child as INavigatingAware)?.OnNavigatingTo(parameters);
                (child?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);
            }
        }
    }
}