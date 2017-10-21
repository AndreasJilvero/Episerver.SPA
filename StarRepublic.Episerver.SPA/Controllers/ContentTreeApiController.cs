using System.Linq;
using System.Web.Http;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using StarRepublic.Episerver.SPA.Models.WebApi;

namespace StarRepublic.Episerver.SPA.Controllers
{
    [RoutePrefix("api/tree")]
    public class ContentTreeApiController : ApiController
    {
        private readonly IContentLoader _contentLoader;
        private readonly UrlResolver _urlResolver;

        public ContentTreeApiController(IContentLoader contentLoader, UrlResolver urlResolver)
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
        }

        [HttpGet]
        [Route]
        public IHttpActionResult Get()
        {
            var linkItems = _contentLoader
                .GetChildren<PageData>(ContentReference.RootPage)
                .Select(CreateContentTreeLinkItem);

            return Ok(linkItems);
        }

        private ContentTreeLinkItem CreateContentTreeLinkItem(PageData page)
        {
            var url = _urlResolver.GetUrl(page.ContentLink);
            return new ContentTreeLinkItem(page.Name, url);
        }
    }
}