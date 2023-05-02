using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    /// <summary>
    /// Data from JSON is filled to this structure.
    /// </summary>
    public struct WeatherData
    {
        /// <summary>
        /// Information about wind in area.
        /// </summary>
        /// <example>"{'speed':'4.47'}"</example>
        [JsonPropertyName("wind")]
        public Dictionary<string, double> Wind { get; set; }
        
        /// <summary>
        /// Weather short description.
        /// </summary>
        /// <example>"[{'description': 'overcast clouds'}]"</example>
        [JsonPropertyName("weather")]
        public List<Dictionary<string, object>> Weather { get; set; }

        /// <summary>
        /// Main weather information: temprature, pressure and humidity.
        /// </summary>
        /// <example>"{'temp': '29.27', 'pressure': '1007', 'humidity': '57'}"</example>
        [JsonPropertyName("main")]
        public Dictionary<string, double> Main { get; set; }

        /// <summary>
        /// Area name.
        /// </summary>
        /// <example>London</example>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
