namespace WeatherDataService
{
    /// <summary>
    /// Represent a specific coordination
    /// </summary>
    public class Coord
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
    }

    /// <summary>
    /// Represent sun rise and set times
    /// </summary>
    public class Sun
    {
        public string Rise { get; set; }
        public string Set { get; set; }
    }

    /// <summary>
    /// Represent city data
    /// </summary>
    public class City
    {
        public Coord Coord { get; set; }
        public Location Location { get; set; }
        public Sun Sun { get; set; }
    }

    /// <summary>
    /// Represent a single measure
    /// </summary>
    public class Measure
    {
        public string Value { get; set; }
        public string Unit { get; set; }
    }

    /// <summary>
    /// Represent tempreature measure
    /// </summary>
    public class Temperature
    {
        public Measure Measure { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
    }

    /// <summary>
    /// Represent a direction
    /// </summary>
    public class Direction
    {
        public string Value { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Represent wind measure
    /// </summary>
    public class Wind
    {
        public Measure Speed { get; set; }
        public Direction Direction { get; set; }
    }

    /// <summary>
    /// Represent weather description
    /// </summary>
    public class Weather
    {
        public string Number { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
    }

    /// <summary>
    /// Represent the needed weather data
    /// </summary>
    public class WeatherData
    {
        public City City { get; set; }
        public Temperature Temperature { get; set; }
        public Measure Humidity { get; set; }
        public Measure Pressure { get; set; }
        public Wind Wind { get; set; }
        public Measure Clouds { get; set; }
        public Weather Weather { get; set; }
    }

}
