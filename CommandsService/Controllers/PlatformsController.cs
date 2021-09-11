using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController: ControllerBase
    {
        private readonly ILogger<PlatformsController> _logger;

        public PlatformsController(ILogger<PlatformsController> logger)
        {
            this._logger = logger;
        }

        [HttpPost]
        public ActionResult test()
        {
            Console.WriteLine("-->  Inbound posts at comment service");
            return Ok("Inboud test OK from platforms controller");
        }
    }
}