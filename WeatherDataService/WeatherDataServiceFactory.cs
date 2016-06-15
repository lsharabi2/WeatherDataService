namespace WeatherDataService
{
    /// <summary>
    /// A factory for weather data services
    /// </summary>
    public class WeatherDataServiceFactory
    {
        /// <summary>
        /// Enum of supported weather data services
        /// </summary>
        public enum WeatherDataServiceSource
        {
            OPEN_WEATHER_MAP
        }

        /// <summary>
        /// Returns a service instance for the given weather data service source
        /// </summary>
        /// <param name="source">The weather data source</param>
        /// <returns>IWeatherDataService implementation</returns>
        public static IWeatherDataService GetWeatherDataService(WeatherDataServiceSource source)
        {
            switch (source)
            {
                case WeatherDataServiceSource.OPEN_WEATHER_MAP:
                    return OWMWeatherDataService.Instance;
                default:
                    throw new WeatherDataServiceException("Unsupported weather data service source");
            }
        }
    }
}
