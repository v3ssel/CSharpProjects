using RestPlan;

internal class Program
{
    private static void SearchTesting(List<ISearchable> l)
    {
        Console.WriteLine($"> Input search text:");
        var search = Console.ReadLine();

        List<ISearchable> founded = l.Search(search!).ToList();
        if (founded.Count == 0) {
            Console.WriteLine($"\nThere are no \"{search}\" in media today.");
            return;
        }

        Console.WriteLine($"\nItems found: {founded.Count}\n");
        var groups = founded.GroupBy(g => g.GetType());
        var first_group = (groups.ElementAt(0).ElementAt(0).GetType().ToString() == "RestPlan.BookReview" ? "Book" : "Movie");

        Console.WriteLine($"{first_group} search result [{groups.ElementAt(0).Count()}]:");
        foreach (var i in groups.ElementAt(0))
                Console.WriteLine($"{i.ToString()}");
        
        if (groups.ElementAtOrDefault(1) == null)
        {
            Console.WriteLine($"{(first_group == "Movie" ? "Book" : "Movie")} search result [0]:");
            return;
        }

        Console.WriteLine($"Movie search result [{groups.ElementAt(1).Count()}]:");
        foreach (var i in groups.ElementAt(1))
                Console.WriteLine($"{i.ToString()}");
    }

    private static void SearchBestTest(string arg, List<ISearchable> l)
    {
        if (arg == "best")
        {
            var best = l.SearchBest();
            if (best is null) 
            {
                Console.WriteLine("The is no books and movies in todays list.");
                return;
            }
            string? where = best[0] is not null && best[0]!.GetType().ToString() == "RestPlan.BookReview" ? "books" : "movie reviews";
            Console.WriteLine($"Best in {where}:");
            Console.WriteLine(best[0] is null ? "0" : best[0]!.ToString());
            Console.WriteLine($"Best in {(where == "movie reviews" ? "books" : "movie reviews")}:");
            Console.WriteLine(best[1] is null ? "0" : best[1]!.ToString());
        }
    }

    private static void Main(string[] args)
    {
    // ==== Uncomment next lines to see every books and movies in json's ====

        List<ISearchable> l = new List<ISearchable>();
        var books = FileReader.ReadBooksFromFile();
        foreach (var i in books)
        {
            // Console.WriteLine(i.ToString());
            l.Add(i);
        }
            
        var movies = FileReader.ReadMoviesFromFile();
        foreach (var i in movies)
        {
            // Console.WriteLine(i.ToString());
            l.Add(i);
        }
        
    // =============================== Search ===============================

        if (args.Length == 0) {
            SearchTesting(l);
            return;
        }

    // ============================= Search Best =============================

        SearchBestTest(args.Length == 1 ? args[0] : "", l);
    }
}
