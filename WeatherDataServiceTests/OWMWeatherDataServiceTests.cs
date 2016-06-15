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
    public class OWMWeatherDataServiceTests
    {
        [TestMethod()]
        public void GetWeatherDataTest()
        {
            IWeatherDataService service = OWMWeatherDataService.Instance;

            var location = new Location("London", "uk");
            var data = service.GetWeatherData(location);

            WeatherDataTestUtils.AssertValidWeatherData(data);
            Assert.AreEqual(data.City.Location.City, location.City);
        }

        
    }
}