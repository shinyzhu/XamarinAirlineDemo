using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDemo.PortableBusiness.Data
{
    public class FlightService : IFlightService
    {
        public Task<List<FlightInfo>> SearchFlightsAsync(string fromCityCode, string toCityCode, DateTime departDay)
        {
            string serviceURL = "https://airline.azure-mobile.net/api/flights";

            return GetFlights(serviceURL);
        }

        async Task<List<FlightInfo>> GetFlights(string serviceURL)
        {
            var client = new HttpClient();

            var flights = JsonConvert.DeserializeObject<List<FlightInfo>>(await client.GetStringAsync(serviceURL));

            return flights;
        }
    }
}
