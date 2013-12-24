using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDemo.PortableBusiness
{
    public interface IFlightService
    {
        /// <summary>
        /// 搜索航班信息。
        /// </summary>
        /// <param name="fromCityCode">出发城市三字码。</param>
        /// <param name="toCityCode">到达城市三字码。</param>
        /// <param name="departDay">出发日期。</param>
        /// <returns></returns>
        Task<List<Data.FlightInfo>> SearchFlightsAsync(string fromCityCode, string toCityCode, DateTime departDay);
    }
}
