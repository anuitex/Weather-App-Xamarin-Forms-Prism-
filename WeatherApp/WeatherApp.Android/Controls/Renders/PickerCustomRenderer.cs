using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.Droid.Controls.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(PickerCustomRenderer))]
namespace WeatherApp.Droid.Controls.Renders
{
    public class PickerCustomRenderer : PickerRenderer
    {
        public PickerCustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var picker = e.NewElement;
            Picker bp = (Picker)this.Element;

            if (this.Control != null)
            {
                var pickerStyle = new Style(typeof(Picker))
                {

                    Setters =
                {
                }
                };
                picker.Style = pickerStyle;
            }
        }
    }
}