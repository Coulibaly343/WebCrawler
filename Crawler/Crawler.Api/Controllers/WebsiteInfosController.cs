using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Core.Dtos;
using Crawler.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Api.Controllers
{
    public class WebsiteInfosController : ApiControllerBase
    {
        private readonly IWebsiteInfoService _websiteInfoService;

        public WebsiteInfosController(IWebsiteInfoService websiteInfoService)
        {
            _websiteInfoService = websiteInfoService;
        }

        /// <summary>
        /// Get all website infos  
        /// </summary>
        /// <returns>Website Infos.</returns>
        /// <response code="201">Website infos has been returned successfully.</response>
        /// <response code="400">Website infos hasn't been returned successfully.</response>
        /// <response code="500">Obtaining website infos failed.</response>
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<WebsiteInfoDto>>> GetAll()
        {
            var websiteInfos = await _websiteInfoService.GetAll();

            return websiteInfos.ToList();
        }

    }
}
