using System.Text;

namespace RestPlan
{
    public class BookReview : ISearchable
    {
        public ResultForSearch SearchableData { get; set; }

        public BookResult book;

        public override string ToString()
        {
            var all_books = new StringBuilder();
            all_books.Append($"- {book.BookDetails.Last().Title} by {book.BookDetails.Last().Author}"); 
            all_books.Append($"[{book.Rank} on NYT's {book.ListName}]\n");
            all_books.Append($"{book.BookDetails.Last().Description}\n{book.Url}\n");
            return all_books.ToString();
        }
    }
}
