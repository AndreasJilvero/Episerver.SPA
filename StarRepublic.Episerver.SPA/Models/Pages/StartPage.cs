using EPiServer.DataAnnotations;

namespace StarRepublic.Episerver.SPA.Models.Pages
{
    [ContentType(DisplayName = "Start page", GUID = "871DE926-8E97-4ED0-8537-5B8E4D25FD51")]
    public class StartPage
    {
        public virtual string Title { get; set; }
    }
}