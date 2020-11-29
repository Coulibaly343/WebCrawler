using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Core.Commands;
using Crawler.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Api.Controllers
{
    public class CrawlersController : ApiControllerBase
    {
        private readonly ICrawlerProcesser _crawlerProcesser;

        public CrawlersController(ICrawlerProcesser crawlerProcesser)
        {
            _crawlerProcesser = crawlerProcesser;
        }

        /// <summary>
        /// Download images from website of given url 
        /// </summary>
        /// <param name="command">Url of website to crawl</param>
        /// <returns>Url of saved images.</returns>
        /// <response code="201">Website has been crawled successfully.</response>
        /// <response code="400">Website hasn't been crawled successfully.</response>
        /// <response code="500">Crawling failed.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<string>>> Crawl(CrawlWebsite command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var urls = await _crawlerProcesser.Process(new Uri(command.Uri));

            return urls.ToList();
        }

    }

}
