using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineDemo.PortableBusiness.Data
{
    public class FlightInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("flight_no")]
        public string FlightNo { get; set; }

        [JsonProperty("depart_airport")]
        public string DepartAirport { get; set; }

        [JsonProperty("arrival_airport")]
        public string ArrivalAirport { get; set; }

        [JsonProperty("depart_airport_terminal")]
        public string DepartAirportTerminal { get; set; }

        [JsonProperty("arrival_airport_terminal")]
        public string ArrivalAirportTerminal { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("craft_type")]
        public string CraftType { get; set; }

        [JsonProperty("etd")]
        public string Etd { get; set; }

        [JsonProperty("eta")]
        public string Eta { get; set; }
    }
}
