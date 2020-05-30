using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace bioResearchSystem.Web.Helpers
{
    public class PagLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageModel PageModel { get; set; }
        public string PageAction { get; set; }
        public PagLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            var tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            var currentItem =  CreateTag(PageModel.PageNumber,urlHelper);


            if (PageModel.HasPreviousPage) {
                var prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }

            tag.InnerHtml.AppendHtml(currentItem);


            if (PageModel.HasNextPage) {
                var nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }

            output.Content.AppendHtml(tag);

        }
        private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {

            var liTag = new TagBuilder("li");
            var linkTag = new TagBuilder("a");

            if (pageNumber == PageModel.PageNumber)
            {
                liTag.AddCssClass("active");
            }
            else
            {
                linkTag.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            }

            liTag.AddCssClass("page-item");
            linkTag.AddCssClass("page-link");
            linkTag.InnerHtml.Append(pageNumber.ToString());
            liTag.InnerHtml.AppendHtml(linkTag);
            return liTag;

        }

    }
}
