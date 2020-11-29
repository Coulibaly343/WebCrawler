using System.Collections.Generic;

namespace Crawler.Core.Dtos
{
    public class WebsiteInfoDto
    {
        public string Uri { get; set; }
        public IEnumerable<ImageInfoDto> Images { get; set; }
    }
}
