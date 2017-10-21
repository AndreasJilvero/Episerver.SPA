using System.Web.Http;
using EPiServer;
using EPiServer.Core;

namespace StarRepublic.Episerver.SPA.Controllers
{
    [RoutePrefix("api/content")]
    public class ContentApiController : ApiController
    {
        private readonly IContentLoader _contentLoader;

        public ContentApiController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        [HttpGet]
        [Route]
        public IHttpActionResult Get(string contentId)
        {
            var contentLink = ContentReference.Parse(contentId);
            var content = _contentLoader.Get<IContent>(contentLink);
            return Ok(content);
        }
    }
}