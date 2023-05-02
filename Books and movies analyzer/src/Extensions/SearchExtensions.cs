namespace RestPlan
{
    public static class SearchExtension
    {
        public static T[] Search<T>(this IEnumerable<T> list, string search)
        where T : ISearchable
        {
            if (list.Count() == 0)
                return new T[0];

            var grouped = list.GroupBy(g => g.GetType());

            var books = grouped.ElementAtOrDefault(0);
            var movies = grouped.ElementAtOrDefault(1);
        
            if (search == "")
            {
                if (movies == null)
                    return books!.ToArray();
            
                return books!.Concat(movies).ToArray();
            }

            if (movies == null)
                return books!.Where(t => t.SearchableData.Title!.ToLower().Contains(search.ToLower())).ToArray();

            return books!.Concat(movies).Where(t => t.SearchableData.Title!.ToLower().Contains(search.ToLower())).ToArray();
        }

        public static T?[]? SearchBest<T>(this IEnumerable<T> list)
        where T : ISearchable
        {
            var grouped = list.GroupBy(g => g.GetType());
            
            var books = grouped.ElementAtOrDefault(0);
            var movies = grouped.ElementAtOrDefault(1);

            if (books is null) 
                return null;

            T? best_book = books.MinBy(r => r.SearchableData.Rank);

            T? best_movie = default(T);
            if (movies is not null)
                best_movie = movies.MaxBy(r => r.SearchableData.Rank);
            
            return new T?[2] { books.MinBy(r => r.SearchableData.Rank), best_movie! };
        }
    }
}
