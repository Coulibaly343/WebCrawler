using System;
using System.Collections.Generic;

namespace Crawler.Core.Entities
{
    public class WebsiteInfo
    {
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public ICollection<ImageInfo> ImageInfos { get; set; }
    }
}