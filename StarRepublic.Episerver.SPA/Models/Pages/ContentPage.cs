using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace StarRepublic.Episerver.SPA.Models.Pages
{
    [ContentType(DisplayName = "Content page", GUID = "1136B242-62D5-4BFD-97BA-2954E47CC428")]
    public class ContentPage : PageData
    {
        [Display(Name = "Content area")]
        public virtual ContentArea ContentArea { get; set; }
    }
}