using Microsoft.Extensions.Configuration;
using AdAstra;

internal class Program
{
    private static async Task Main(string[] args)
    {
    // ==================  API KEY  ==================

        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("appsettings.json");
        IConfiguration Configuration = configurationBuilder.Build();

    // ================== Send requests ==================

        if (args.Length == 2 && args[0] == "apod")
        {
            if (!int.TryParse(args[1], out int n)) n = 0;
            INasaClient<int, Task<MediaOfToday[]>> ad_astra = new ApodClient(Configuration["ApiKey"]);
            var result = await ad_astra.GetAsync(n);
            foreach (var mediaOfToday in result)
            {
                Console.WriteLine($"{mediaOfToday.ToString()}");
            }
        }
    }
}
