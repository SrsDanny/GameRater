using System;

namespace GameRater.DAL
{
    public enum SortBy
    {
        Title, Score
    }

    public class SortGamesOptions
    {
        public SortBy SortBy { get; set; }
        public bool Ascending { get; set; }

        public SortGamesOptions(string sortBy, string order)
        {
            if (string.IsNullOrEmpty(order))
                Ascending = true;
            else
                Ascending = order.ToLower() != "descending";
            SortBy = Enum.TryParse(sortBy, true, out SortBy sortByEnum) ? sortByEnum : SortBy.Title;
        }
    }
}