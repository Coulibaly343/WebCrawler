
using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Core.Dtos;

namespace Crawler.Core.Interfaces
{
    public interface IWebsiteInfoService
    {
        Task<IEnumerable<WebsiteInfoDto>> GetAll();
    }
}
