using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameRater.Models;

namespace GameRater.Helpers
{
    public static class PagingHtmlHelper
    {
        private static string BuildNextOrPreviousPageLi(string linkText, string linkUrl, bool enabled)
        {
            var li = new TagBuilder("li");
            if (enabled)
            {
                li.AddCssClass("disabled");
            }

            var a = new TagBuilder("a");
            a.MergeAttribute("href", linkUrl);
            a.SetInnerText(linkText);
            li.InnerHtml = a.ToString();

            return li.ToString();
        }

        private static string BuildPageButton(int page, string linkUrl, bool active)
        {
            var li = new TagBuilder("li");
            if (active)
            {
                li.AddCssClass("active");
            }

            var a = new TagBuilder("a");
            a.SetInnerText(page.ToString());
            a.MergeAttribute("href", linkUrl);
            li.InnerHtml = a.ToString();

            return li.ToString();
        }

        public static IHtmlString Paging(this HtmlHelper helper, PagingViewModel paging, int pagesToDisplay = 5)
        {
            var nav = new TagBuilder("nav");

            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            var previousPageLink = paging.IsFirstPage
                ? "#"
                : paging.CreatePageUrl(paging.CurrentPage - 1);
            var nextPageLink = paging.IsLastPage
                ? "#"
                : paging.CreatePageUrl(paging.CurrentPage + 1);

            var firstPageToDisplay = Math.Max(paging.CurrentPage - pagesToDisplay / 2, 1);
            var lastPageToDisplay = firstPageToDisplay + pagesToDisplay - 1;
            if (lastPageToDisplay > paging.PageCount)
            {
                firstPageToDisplay -= lastPageToDisplay - paging.PageCount;
                lastPageToDisplay = paging.PageCount;
            }
            
            ul.InnerHtml += BuildNextOrPreviousPageLi("Previous", previousPageLink, paging.IsFirstPage);

            for (var i = firstPageToDisplay; i <= lastPageToDisplay; i++)
            {
                ul.InnerHtml += BuildPageButton(i, paging.CreatePageUrl(i), i == paging.CurrentPage);
            }

            ul.InnerHtml += BuildNextOrPreviousPageLi("Next", nextPageLink, paging.IsLastPage);

            nav.InnerHtml = ul.ToString();
            return new MvcHtmlString(nav.ToString());
        }
    }
}