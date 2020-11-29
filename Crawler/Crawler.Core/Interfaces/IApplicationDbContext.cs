using System.Threading;
using System.Threading.Tasks;
using Crawler.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ImageInfo> ImageInfos { get; set; }
        DbSet<WebsiteInfo> WebsiteInfos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
