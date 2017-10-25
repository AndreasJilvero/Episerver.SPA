using System.Web.Mvc;
using EPiServer.Web.Mvc;
using StarRepublic.Episerver.SPA.Models.Pages;

namespace StarRepublic.Episerver.SPA.Controllers
{
    public class ContentPageController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            return View("~/Views/StartPage/Index.cshtml");
        }
    }
}