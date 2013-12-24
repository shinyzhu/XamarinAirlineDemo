using AirlineDemo.PortableBusiness.Data;
using AirlineDemo.PortableBusiness.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDemo.PortableBusiness.ViewModels
{
    public class FlightInfoViewModel : ViewModelBase
    {
        readonly IFlightService service;
        List<FlightInfo> flights;

        public FlightInfoViewModel()
        {
            service = ServiceContainer.Resolve<IFlightService>();
        }

        public List<FlightInfo> Flights
        {
            get { return flights; }
            set
            {
                flights = value;

                OnPropertyChanged("Flights");
            }
        }

        public Task LoadFlights()
        {
            return service.SearchFlightsAsync("SHA", "PEK", DateTime.Today.AddDays(1))
                .ContinueWith(t => { Flights = t.Result; });
        }
    }
}
