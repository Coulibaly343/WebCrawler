using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Core.Dtos;
using Crawler.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Core.Services
{
    public class WebsiteInfoService : IWebsiteInfoService
    {
        private readonly IApplicationDbContext _context;

        public WebsiteInfoService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WebsiteInfoDto>> GetAll()
        {
            var websiteInfos = await _context.WebsiteInfos
                .Include(x => x.ImageInfos)
                .Select(x => new WebsiteInfoDto
                {
                    Uri = x.Uri,
                    Images = x.ImageInfos.Select(y => new ImageInfoDto {Uri = y.Uri})
                }).ToListAsync();

            return websiteInfos;
        }

    }
}
