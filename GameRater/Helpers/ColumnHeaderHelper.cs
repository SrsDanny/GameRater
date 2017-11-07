using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameRater.DAL;

namespace GameRater.Helpers
{
    public static class ColumnHeaderHelper
    {
        public static IHtmlString SortingColumnHeader(this HtmlHelper helper, SortBy columnTitle,
            SortGamesOptions options, Func<object, string> linkUrl)
        {
            var a = new TagBuilder("a");
            var title = columnTitle.ToString();
            var active = options.SortBy == columnTitle;
            if (active)
            {
                title += " " + (options.Ascending ? "↑" : "↓");
            }
            a.SetInnerText(title);

            var sortOptions = new
            {
                sortBy = columnTitle.ToString(),
                sortOrder = options.Ascending && active ? "descending" : "ascending"
            };
            a.MergeAttribute("href", linkUrl(sortOptions));
            return new MvcHtmlString(a.ToString());
        }
    }
}