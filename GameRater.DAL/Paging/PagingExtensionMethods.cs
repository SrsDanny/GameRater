using System.Linq;

namespace GameRater.DAL.Paging
{
    public static class PagingExtensionMethods
    {
        public static PagedQueryable<T> PageBy<T>(this IQueryable<T> source, int pageSize)
        {
            return new PagedQueryable<T>(source, pageSize);
        }
    }
}
