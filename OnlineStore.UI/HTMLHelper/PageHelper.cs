using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OnlineStore.UI.Models;

namespace OnlineStore.UI.HTMLHelper
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                PageInfo pageInfo,
                                                Func<int,string> pageUrl)
        {
            StringBuilder results = new StringBuilder();
            for(int i=1;i<=pageInfo.totalPages;i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i==pageInfo.currentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                results.Append(tag.ToString());
            }
            return MvcHtmlString.Create(results.ToString());
        }
    }
}