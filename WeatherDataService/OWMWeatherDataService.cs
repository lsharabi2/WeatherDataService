using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace WeatherDataService
{
    /// <summary>
    /// Implementation of IWeatherDataService for the www.openweathermap.com REST api
    /// </summary>
    public class OWMWeatherDataService : IWeatherDataService
    {
        private static readonly string OWM_API_KEY = "c88bdadce596ef676bc2df46adcf0fb6";

        private static readonly string OWM_REQUEST_URL_FORMAT = "http://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid={2}&mode=xml";

        /// <summary>
        /// The weather data service singleton
        /// </summary>
        private static readonly OWMWeatherDataService instance = new OWMWeatherDataService();

        /// <summary>
        /// Private ctor so the class won't be instantiated out side of the class
        /// </summary>
        private OWMWeatherDataService() {}

        /// <summary>
        /// Specific implementation of the IWeatherDataService for open weather map
        /// </summary>
        /// <param name="location">The specific location</param>
        /// <returns>The weather data from open weather map</returns>
        public WeatherData GetWeatherData(Location location)
        {
            try
            {
                string xmlString;

                // Download the json answer from open weather map
                using (var client = new WebClient())
                {
                    xmlString = client.DownloadString(string.Format(
                        OWM_REQUEST_URL_FORMAT,
                        location.City,
                        location.Country,
                        OWM_API_KEY));
                }

                return XmlToWeatherData(xmlString);
            }
            catch (Exception ex)
            {
                throw new WeatherDataServiceException(ex);
            }
        }

        /// <summary>
        /// Parse the given xml string according to open weather map answer xml format
        /// </summary>
        /// <param name="xmlString">A valid OWM answer xml string</param>
        /// <returns>A WeatherData object built from the OWM answer xml string</returns>
        private WeatherData XmlToWeatherData(string xmlString)
        {
            XElement root = XElement.Parse(xmlString);

            return (from weatherData in root.DescendantsAndSelf("current")
                    select new WeatherData()
                    {
                        City = new City()
                        {
                            Coord = new Coord()
                            {
                                Lat = weatherData.Descendants("coord").First().Attribute("lat").Value,
                                Lon = weatherData.Descendants("coord").First().Attribute("lon").Value
                            },

                            Location = new Location(
                                    weatherData.Descendants("city").First().Attribute("name").Value,
                                    weatherData.Descendants("country").First().Value),

                            Sun = new Sun()
                            {
                                Rise = weatherData.Descendants("sun").First().Attribute("rise").Value,
                                Set = weatherData.Descendants("sun").First().Attribute("set").Value
                            }
                        },

                        Temperature = new Temperature()
                        {
                            Measure = new Measure()
                            {
                                Unit = weatherData.Descendants("temperature").First().Attribute("unit").Value,
                                Value = weatherData.Descendants("temperature").First().Attribute("value").Value
                            },
                            Max = weatherData.Descendants("temperature").First().Attribute("max").Value,
                            Min = weatherData.Descendants("temperature").First().Attribute("min").Value
                        },

                        Humidity = new Measure()
                        {
                            Unit = weatherData.Descendants("humidity").First().Attribute("unit").Value,
                            Value = weatherData.Descendants("humidity").First().Attribute("value").Value
                        },

                        Pressure = new Measure()
                        {
                            Unit = weatherData.Descendants("pressure").First().Attribute("unit").Value,
                            Value = weatherData.Descendants("pressure").First().Attribute("value").Value
                        },      
                                          
                        Wind = new Wind()
                        {
                            Speed = new Measure()
                            {
                                Unit = weatherData.Descendants("speed").First().Attribute("name").Value,
                                Value = weatherData.Descendants("speed").First().Attribute("value").Value
                            },

                            Direction = new Direction()
                            {
                                Code = weatherData.Descendants("direction").First().Attribute("code").Value,
                                Name = weatherData.Descendants("direction").First().Attribute("name").Value,
                                Value = weatherData.Descendants("direction").First().Attribute("value").Value
                            }
                        },

                        Clouds = new Measure()
                        {
                            Unit = weatherData.Descendants("clouds").First().Attribute("name").Value,
                            Value = weatherData.Descendants("clouds").First().Attribute("value").Value
                        },

                        Weather = new Weather()
                        {
                            Icon = weatherData.Descendants("weather").First().Attribute("icon").Value,
                            Value = weatherData.Descendants("weather").First().Attribute("value").Value,
                            Number = weatherData.Descendants("weather").First().Attribute("number").Value
                        }
                    }).First();
        }

        /// <summary>
        /// Member which holds the single OWMWeatherDataService single instance
        /// </summary>
        public static OWMWeatherDataService Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
