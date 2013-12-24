using AirlineDemo.PortableBusiness.Data;
using AirlineDemo.PortableBusiness.Utilities;
using AirlineDemo.PortableBusiness.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDemo.PortableBusiness
{
    public static class ServiceRegistrar
    {
        /// <summary>
        /// Call on startup of the app, it configures ServiceContainer
        /// </summary>
        public static void Startup()
        {
            ServiceContainer.Register<IFlightService>(() => new FlightService());

#if !NETFX_CORE
            //Only do these on iOS or Android
            ServiceContainer.Register<FlightInfoViewModel>();
#endif
        }
    }
}
