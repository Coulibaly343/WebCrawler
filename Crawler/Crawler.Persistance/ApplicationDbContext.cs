using System.Threading;
using System.Threading.Tasks;
using Crawler.Core.Entities;
using Crawler.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<ImageInfo> ImageInfos { get; set; }
        public DbSet<WebsiteInfo> WebsiteInfos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsiteInfo>()
                .HasMany(x => x.ImageInfos)
                .WithOne(x => x.WebsiteInfo);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
