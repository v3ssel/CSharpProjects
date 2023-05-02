using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace RestPlan
{
    public static class FileReader
    {
        private static ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        
        private static void BuildConfiguration()
        {
            configurationBuilder.AddJsonFile("appsettings.json");
        }

        public static ResultList<T> Reader<T>(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException();

            ResultList<T> Results = JsonSerializer.Deserialize<ResultList<T>>(
                new StreamReader(file).BaseStream,
                new JsonSerializerOptions {
                    PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            });
            return Results;
        }

        public static List<BookReview> ReadBooksFromFile()
        {
            BuildConfiguration();
            IConfiguration Configuration = configurationBuilder.Build();
         
            ResultList<BookResult> Results = Reader<BookResult>($"{Configuration["book_reviews"]}");
            List<BookReview> books = new List<BookReview>();
            foreach (var i in Results.Results)
            {
                books.Add(new BookReview() { book = i, SearchableData = new ResultForSearch(i.BookDetails.Last().Title, i.Rank) });
            }
            return books;
        }

        public static List<MovieReview> ReadMoviesFromFile()
        {
            BuildConfiguration();
            IConfiguration Configuration = configurationBuilder.Build();
            ResultList<MovieResult> Results = Reader<MovieResult>($"{Configuration["movie_reviews"]}");
            List<MovieReview> movies = new List<MovieReview>();
            foreach (var i in Results.Results)
            {
                movies.Add(new MovieReview() { movie = i, SearchableData = new ResultForSearch(i.Title, i.CriticsPick) });
            }
            return movies;
        }
    }
}
