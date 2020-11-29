using Crawler.Core.Interfaces;
using Crawler.Core.Processers;
using Crawler.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICrawlerProcesser, ImagesCrawlerProcesser>();
            services.AddScoped<IWebsiteInfoService, WebsiteInfoService>();

            return services;
        }
    }
}
