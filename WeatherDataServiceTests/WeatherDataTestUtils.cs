using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataService;

namespace WeatherDataService.Tests
{
    public class WeatherDataTestUtils
    {
        public static void AssertValidWeatherData(WeatherData data)
        {
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.City);
            Assert.IsNotNull(data.City.Location);
            Assert.IsNotNull(data.Clouds);
            Assert.IsNotNull(data.Humidity);
            Assert.IsNotNull(data.Pressure);
            Assert.IsNotNull(data.Temperature);
            Assert.IsNotNull(data.Temperature.Measure);
            Assert.IsNotNull(data.Weather);
            Assert.IsNotNull(data.Wind);
            Assert.IsNotNull(data.Wind.Direction);
            Assert.IsNotNull(data.Wind.Speed);
        }
    }
}
