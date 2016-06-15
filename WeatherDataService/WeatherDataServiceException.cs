using System;

namespace WeatherDataService
{
    /// <summary>
    /// Represents an exception specific for the WeatherDataService
    /// </summary>
    public class WeatherDataServiceException : Exception
    {
        /// <summary>
        /// Wraps an unhandled exception with WeatherDataServiceException
        /// </summary>
        /// <param name="ex">The inner exception to set</param>
        public WeatherDataServiceException(Exception ex)
            : base("Unhandled exception", ex)
        {}

        /// <summary>
        /// Creates a new exception with a specific message
        /// </summary>
        /// <param name="message">The exception message</param>
        public WeatherDataServiceException(string message)
            : base(message)
        {}
    }
}
