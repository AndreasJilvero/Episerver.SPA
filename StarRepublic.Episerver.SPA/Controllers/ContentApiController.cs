using System.Web.Http;
using EPiServer;
using EPiServer.Core;

namespace StarRepublic.Episerver.SPA.Controllers
{
    public class ContentApiController : ApiController
    {
        private readonly IContentLoader _contentLoader;

        public ContentApiController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IHttpActionResult Get(string contentId)
        {
            var contentLink = ContentReference.Parse(contentId);
            var content = _contentLoader.Get<IContent>(contentLink);
            return Ok(content);
        }
    }
}