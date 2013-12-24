using AirlineDemo.PortableBusiness.Utilities;
using AirlineDemo.PortableBusiness.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AirlineDemo.Win8App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlightsPage : Page
    {
        readonly FlightInfoViewModel flightViewModel;

        public FlightsPage()
        {
            this.InitializeComponent();

            flightViewModel = ServiceContainer.Resolve<FlightInfoViewModel>();
            flightViewModel.LoadFlights().ContinueOnCurrentThread(_ =>
            {
                this.flightsBox.ItemsSource = flightViewModel.Flights;
            });
        }
    }
}
