using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController: ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

       [HttpGet]
        public  ActionResult<IEnumerable<PlatformReadDto>> GetCommands()
        {
            Console.WriteLine("--> getting platforms from commandsservice");
            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }


        [HttpPost]
        public ActionResult test()
        {
            Console.WriteLine("-->  Inbound posts at comment service");
            return Ok("Inboud test OK from platforms controller");
        }
    }
}