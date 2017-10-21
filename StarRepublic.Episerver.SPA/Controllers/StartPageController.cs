using System.Web.Mvc;
using EPiServer;
using EPiServer.Web.Mvc;
using StarRepublic.Episerver.SPA.Models.Pages;

namespace StarRepublic.Episerver.SPA.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            return View();
        }
    }
}