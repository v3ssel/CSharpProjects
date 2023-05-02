using System.Text.Json;

namespace AdAstra
{
    public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
    {
        private static readonly HttpClient client = new HttpClient();
        private static string? Token { get; set; }

        public async Task<MediaOfToday[]> GetAsync(int n)
        {
            var query = "https://api.nasa.gov/planetary/apod?api_key=" + Token + $"&count={n}";
            HttpResponseMessage response = await client.GetAsync(query);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"GET “{query}” returned {((int)response.StatusCode)}:\n{await response.Content.ReadAsStringAsync()}");
                return new MediaOfToday[0];
            }
            return JsonSerializer.Deserialize<MediaOfToday[]>(await response.Content.ReadAsStringAsync())!;
        }

        public ApodClient(string token)
        {
            Token = token;
        }
    }
}