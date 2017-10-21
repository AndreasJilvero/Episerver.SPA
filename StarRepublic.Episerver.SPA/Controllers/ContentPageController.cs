using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using StarRepublic.Episerver.SPA.Models.Pages;

namespace StarRepublic.Episerver.SPA.Controllers
{
    public class ContentPageController : PageController<ContentPage>
    {
        private readonly UrlResolver _urlResolver;

        public ContentPageController(UrlResolver urlResolver)
        {
            _urlResolver = urlResolver;
        }

        public ActionResult Index(ContentPage currentPage)
        {
            var url = _urlResolver.GetUrl(ContentReference.StartPage);
            return Redirect(url);
        }
    }
}