using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherDataService service = WeatherDataServiceFactory.
            GetWeatherDataService(WeatherDataServiceFactory.WeatherDataServiceSource.OPEN_WEATHER_MAP);

            var data = service.GetWeatherData(new Location("London", "uk"));
        }
    }
}
