using System;

namespace Crawler.Core.Entities
{
    public class ImageInfo
    {
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public Guid WebsiteInfoId { get; set; }
        public WebsiteInfo WebsiteInfo { get; set; }
    }
}
