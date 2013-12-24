using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AirlineDemo.PortableBusiness.ViewModels;
using AirlineDemo.PortableBusiness.Utilities;

namespace AirlineDemo.AndroidApp
{
    [Activity(Label = "AirlineDemo.AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class FlightsActivity : Activity
    {
        readonly FlightInfoViewModel flightViewModel;
        ListView flightsListView;

        public FlightsActivity()
        {
            this.flightViewModel = ServiceContainer.Resolve<FlightInfoViewModel>();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.FlightsLayout);

            this.flightViewModel.LoadFlights()
                .ContinueWith(_ =>
                {
                    RunOnUiThread(() =>
                    {
                        this.flightsListView = this.FindViewById<ListView>(Resource.Id.flightsListView);
                        this.flightsListView.Adapter = new FlightsAdapter(this, this.flightViewModel.Flights);
                    });
                });
        }
    }
}

