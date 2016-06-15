namespace WeatherDataService
{
    /// <summary>
    /// Represents a specific location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The name of the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The name of the country (ISO 3166 country codes)
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Creates a new location instance
        /// </summary>
        /// <param name="city">The name of the city</param>
        /// <param name="country">The name of the country</param>
        public Location(string city, string country)
        {
            City = city;
            Country = country;
        }
    }
}