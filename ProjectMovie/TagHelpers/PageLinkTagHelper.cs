using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ProjectMovie.Models;
using System.Data;

namespace ProjectMovie.TagHelpers
{
    public class PageLinkTagHelper(IUrlHelperFactory urlHelperFactory) : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;
        public PageViewModel? PageModel { get; set; }
        public string PageAction { get; set; } = "";

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = [];

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PageModel == null)
            {
               throw new InvalidOperationException("PageModel is not set");
            }
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            // A set of links will be for the post ul
            TagBuilder tag = new("ul");
            tag.AddCssClass("pagination justify-content-center");

            // Create a link to first page
            TagBuilder firsItem = CreateTag("\u00AB", urlHelper);
            tag.InnerHtml.AppendHtml(firsItem);

            // Create three links - to the current, previous and next
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);

            // Create a link to the previous page, if there is one
            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }

            tag.InnerHtml.AppendHtml(currentItem);

            // Create a link to the next page, if there is one
            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }

            // Create a link to last page
            TagBuilder lastItem = CreateTag("\u00BB", urlHelper);
            tag.InnerHtml.AppendHtml(lastItem);

            output.Content.AppendHtml(tag);
        }

        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new("li");
            TagBuilder link = new("a");

            if (pageNumber == PageModel?.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                PageUrlValues["page"] = pageNumber;
                link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            }

            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }

        TagBuilder CreateTag(string symbol, IUrlHelper urlHelper)
        {
            TagBuilder item = new("li");
            TagBuilder link = new("a");

            PageUrlValues["page"] = symbol switch
            {
                "\u00AB" => 1,
                "\u00BB" => PageModel!.TotalPages,
                _ => throw new ArgumentException("Unexpected valueю")
            };
            link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(symbol);
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }
}
