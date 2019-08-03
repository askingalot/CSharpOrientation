using System;
using System.Diagnostics;
using CSharpOrientation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpOrientation.Controllers
{
    [Route("api/[controller]")]
    public class ArtDataController : Controller
    {
        private readonly IArtService _artService;

        public ArtDataController(IArtService artService)
        {
            _artService = artService;
        }

        [HttpGet("[action]/{searchCriteria?}")]
        public IActionResult GetTitles(string searchCriteria)
        {
            Debug.WriteLine(searchCriteria);
            if (string.IsNullOrWhiteSpace(searchCriteria))
            {
                searchCriteria = null;
            }

            var titles = _artService.SearchTitles(searchCriteria);
            return Ok(titles);
        }
    }
}
