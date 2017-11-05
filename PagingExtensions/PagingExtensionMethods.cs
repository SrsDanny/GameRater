using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingExtensions
{
    public static class PagingExtensionMethods
    {
        public static PagedQueryable<T> PageBy<T>(this IQueryable<T> source, int pageSize)
        {
            return new PagedQueryable<T>(source, pageSize);
        }
    }
}
