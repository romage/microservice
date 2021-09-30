using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController: ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsController(
            IPlatformRepo repository, 
            IMapper mapper,
            ICommandDataClient commandDataClient,
            IMessageBusClient messageBusClient)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._commandDataClient = commandDataClient;
            this._messageBusClient = messageBusClient;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platformItem =  _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name="GetPlatformsById")]
        public ActionResult<PlatformReadDto> GetPlatformsById(int id)
        {
            var platformItem =  _repository.GetPlatformById(id);
            if(platformItem != default)
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            // var isValid = TryValidateModel(platformCreateDto);
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            // Send Sync Message
             try
             {
                    await _commandDataClient.SendPlatformToCommand(platformReadDto);
             } catch(Exception ex)
             {
                    Console.WriteLine($"--> Could not send synchronos.. {ex.Message}.");
             }    

             // Send Async Message
             try
             {
                var platformPublishedDto = _mapper.Map<PlatformPublishedDto> (platformReadDto);
                platformPublishedDto.Event = "Platform_Published";
                _messageBusClient.PublishNewPlatform(platformPublishedDto);
             } catch(Exception ex)
             {
                    Console.WriteLine($"--> Could not send asynchronos.. {ex.Message}.");
             }

            return CreatedAtRoute(nameof(GetPlatformsById), new { id = platformReadDto.Id}, platformReadDto);
        }

    }
}