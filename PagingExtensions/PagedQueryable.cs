using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingExtensions
{
    public class PagedQueryable<T>
    {
        private IQueryable<T> _sourceQueryable;
        private int _pageSize;

        public PagedQueryable(IQueryable<T> sourceQueryable, int pageSize)
        {
            _sourceQueryable = sourceQueryable;
            _pageSize = pageSize;
        }

        public async Task<int> GetPageCountAsync()
        {
            double elemCount = await _sourceQueryable.CountAsync();
            return (int)Math.Ceiling(elemCount / _pageSize);
        }

        public IQueryable<T> GetPage(int page)
        {
            return _sourceQueryable.Skip((page - 1) * _pageSize).Take(_pageSize);
        }
    }
}
