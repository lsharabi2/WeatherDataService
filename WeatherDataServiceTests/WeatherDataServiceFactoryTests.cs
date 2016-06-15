using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService.Tests
{
    [TestClass()]
    public class WeatherDataServiceFactoryTests
    {
        [TestMethod()]
        public void GetWeatherDataServiceTest()
        {
            IWeatherDataService service = WeatherDataServiceFactory.
                GetWeatherDataService(WeatherDataServiceFactory.WeatherDataServiceSource.OPEN_WEATHER_MAP);

            var location = new Location("London", "uk");
            var data = service.GetWeatherData(location);

            WeatherDataTestUtils.AssertValidWeatherData(data);
            Assert.AreEqual(data.City.Location.City, location.City);
        }

        [TestMethod()]
        [ExpectedException(typeof(WeatherDataServiceException))]
        public void GetWeatherDataServiceFailureTest()
        {
            WeatherDataServiceFactory.WeatherDataServiceSource invalidSource = (WeatherDataServiceFactory.WeatherDataServiceSource) 1000;
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(invalidSource);
        }
    }
}