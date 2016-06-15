namespace WeatherDataService
{
    /// <summary>
    /// Interface to communicate with a REST weather service
    /// </summary>
    public interface IWeatherDataService
    {
        /// <summary>
        /// Get the weather data for a specific location
        /// </summary>
        /// <param name="location">the location to recieve weather data of</param>
        /// <returns>WeatherData object</returns>
        WeatherData GetWeatherData(Location location);
    }
}
