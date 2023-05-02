using System.Collections;
using System.Text.Json.Serialization;

namespace RestPlan
{
    public struct ResultForSearch
    {
        public string Title { get; set; }
        public int Rank { get; set; }
        public ResultForSearch(string title, int rank) 
        {
            Title = title;
            Rank = rank;
        }
    }

    public struct ResultList<T>
    {
        public List<T> Results { get; set; }
    }

    public struct BooksDetails
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }

    public struct BookResult
    {
        public List<BooksDetails> BookDetails { get; set; }
        public string Status { get; set; }
        public int Rank { get; set; }
        public string ListName { get; set; }
        [JsonPropertyName("amazon_product_url")]
        public string Url { get; set; }
    }

    public struct MovieResult
    {
        public string Title { get; set; }
        public int CriticsPick { get; set; }
        public string SummaryShort { get; set; }
        public Hashtable Link { get; set; }
    }
}
