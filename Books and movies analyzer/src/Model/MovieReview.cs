using System.Text;

namespace RestPlan
{
    public class MovieReview : ISearchable
    {
        public ResultForSearch SearchableData { get; set; }
        public MovieResult movie;

        public override string ToString()
        {
            var all_books = new StringBuilder();
            all_books.Append($"- {movie.Title} {(movie.CriticsPick == 1 ? "[NYT critic’s pick]" : "")}\n");
            all_books.Append($"{movie.SummaryShort}\n{movie.Link["url"]}\n\n");
            return all_books.ToString();
        }
    }
}
