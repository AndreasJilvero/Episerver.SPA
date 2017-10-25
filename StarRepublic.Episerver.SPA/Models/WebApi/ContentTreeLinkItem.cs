using EPiServer.Core;

namespace StarRepublic.Episerver.SPA.Models.WebApi
{
    public class ContentTreeLinkItem
    {
        public ContentTreeLinkItem(PageData pageData, string url)
        {
            Name = pageData.Name;
            ContentReference = pageData.ContentLink;
            Type = pageData.PageTypeName;
            Url = url;
        }

        public ContentReference ContentReference { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}