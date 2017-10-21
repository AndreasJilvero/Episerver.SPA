namespace StarRepublic.Episerver.SPA.Models.WebApi
{
    public class ContentTreeLinkItem
    {
        public ContentTreeLinkItem(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; set; }
        public string Url { get; set; }
    }
}