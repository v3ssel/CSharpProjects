using System.Reflection;
using Microsoft.OpenApi.Models;
using WeatherAPI.Models;

namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.Configure<ServiceSettings>(builder.Configuration);
            builder.Services.Add(new ServiceDescriptor(typeof(WeatherClient), typeof(WeatherClient), ServiceLifetime.Singleton));
            builder.Services.AddMemoryCache();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Weather API",
                    Description = "An ASP.NET Core Web API for monitoring weather.",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{xmlFilename}.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{xmlFilename}.WeatherClient.xml"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(c => c.SerializeAsV2 = true);
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}