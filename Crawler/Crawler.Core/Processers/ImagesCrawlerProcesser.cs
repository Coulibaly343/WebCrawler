using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Crawler.Core.Entities;
using Crawler.Core.Helpers;
using Crawler.Core.Interfaces;
using HtmlAgilityPack;

namespace Crawler.Core.Processers
{
    public class ImagesCrawlerProcesser : ICrawlerProcesser
    {
        private readonly IApplicationDbContext _context;
        private static string _imageFolder => "wwwroot";
        private static string _imageUri => "http://localhost:5000/staticFiles/";

        public ImagesCrawlerProcesser(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> Process(Uri uri)
        {
            var httpClient = new HttpClient();

            var urls = await GetImageUrls(uri, httpClient);

            var folder = Path.Combine(_imageFolder, uri.Host);

            var imagePaths = new List<string>();

            foreach (var url in urls)
            {
                var path = new Uri(uri, url);

                var fullPath = await DownloadImage(path, folder, httpClient);

                imagePaths.Add(fullPath);
            }

            await SaveAsync(uri, imagePaths);

            return imagePaths;
        }

        private async Task<List<string>> GetImageUrls(Uri uri, HttpClient httpClient)
        {
            var html = await httpClient.GetStringAsync(uri);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var imgs = htmlDocument.DocumentNode.Descendants("img").ToList();

            var urls = imgs.Select(x => x.ChildAttributes("src").FirstOrDefault()?.Value).ToList();
            return urls;
        }

        private async Task<string> DownloadImage(Uri url, string destination, HttpClient httpClient)
        {
            var data = await httpClient.GetByteArrayAsync(url);

            var fileName = FileHelper.GetFileName(url);

            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            var fullPath = Path.Combine(destination, fileName);

            if (!File.Exists(fullPath))
                await File.WriteAllBytesAsync(fullPath, data);
            return fullPath;
        }

        private async Task SaveAsync(Uri uri, IEnumerable<string> imagePaths)
        {
            var website = new WebsiteInfo
            {
                Uri = uri.OriginalString,
                ImageInfos = imagePaths.Select(x => new ImageInfo
                {
                    Uri = $"{_imageUri}{x}"
                }).ToList()
            };

            await _context.WebsiteInfos.AddAsync(website);
            await _context.SaveChangesAsync(new CancellationToken());
        }

    }
}