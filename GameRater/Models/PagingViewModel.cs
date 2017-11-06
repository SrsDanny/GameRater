using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRater.Models
{
    public class PagingViewModel
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public Func<int, string> CreatePageUrl { get; set; }

        public bool IsFirstPage => CurrentPage == 1;
        public bool IsLastPage => CurrentPage == PageCount;

        public PagingViewModel(int pageCount, int currentPage, Func<int, string> createPageUrl)
        {
            PageCount = pageCount;
            CurrentPage = currentPage;
            CreatePageUrl = createPageUrl;
        }
    }
}