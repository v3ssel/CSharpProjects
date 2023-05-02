using System.Text.Json;
using Microsoft.Extensions.Options;

namespace WeatherAPI.Models
{
    public class WeatherClient
    {
        public HttpClient client = new HttpClient();
        public ServiceSettings settings { get; }

        public WeatherClient(IOptions<ServiceSettings> options)
        {
            settings = options.Value;
        }

        public async Task<WeatherData> GetWeatherByCoordinates(double latitude, double longtitude)
        {
            var query = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longtitude}&appid={settings.API_KEY}";
            return await MakeResponse(query);
        }
        
        public async Task<WeatherData> GetWeatherByCity(string city)
        {
            var query = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={settings.API_KEY}";
            return await MakeResponse(query);
        }

        private async Task<WeatherData> MakeResponse(string query)
        {
            HttpResponseMessage response = await client.GetAsync(query);
            var response_to_string = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"GET {query} - {response.StatusCode}\n{response_to_string}");
            var json = JsonSerializer.Deserialize<WeatherData>(await response.Content.ReadAsStringAsync());
            return FormatJson(json);
        }

        private WeatherData FormatJson(WeatherData json)
        {
            json.Wind.Remove("deg");
            json.Wind.Remove("gust");
            json.Weather.ForEach(dict => { dict.Remove("id"); dict.Remove("main"); dict.Remove("icon"); });
            json.Main.Remove("feels_like");
            json.Main.Remove("temp_min");
            json.Main.Remove("temp_max");
            json.Main.Remove("sea_level");
            json.Main.Remove("grnd_level");
            return json;
        }
    }
}
