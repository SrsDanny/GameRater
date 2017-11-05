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
        private readonly IQueryable<T> _sourceQueryable;
        private readonly int _pageSize;
        private int? _pageCount;

        public PagedQueryable(IQueryable<T> sourceQueryable, int pageSize)
        {
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            _sourceQueryable = sourceQueryable ?? throw new ArgumentNullException(nameof(sourceQueryable));
            _pageSize = pageSize;
        }

        public async Task<int> GetPageCountAsync(bool getCached = true)
        {
            if (getCached && _pageCount != null) return _pageCount.Value;

            double elemCount = await _sourceQueryable.CountAsync();

            _pageCount = (int) Math.Ceiling(elemCount / _pageSize);
            return _pageCount.Value;
        }

        public IQueryable<T> GetPage(int page)
        {
            if(page < 1) throw new ArgumentOutOfRangeException(nameof(page));
            return _sourceQueryable.Skip((page - 1) * _pageSize).Take(_pageSize);
        }
    }
}
