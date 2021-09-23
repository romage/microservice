using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/platforms/{platformId}/[controller]")]
    public class CommandsController: ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        [HttpGet("{commandId}")]
        public  ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Commands GetCommands {platformId}");
            
            if(!_repository.PlaformExits(platformId))
            {
                return NotFound();
            }
            
            var commandItems = _repository.GetCommandsForPlatform(platformId);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{commandId}", Name="GetCommand")]
        public ActionResult<CommandReadDto> GetCommand(int platformId, int commandId)
        {
            if(!_repository.PlaformExits(platformId))
            {
                return NotFound();
            }
            var commandItem = _repository.GetCommand(platformId, commandId);
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }

        [HttpPost()]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
        {
            Console.WriteLine($"--> Hit createCommandForPlatform {platformId}");
            if(!_repository.PlaformExits(platformId))
            {
                return NotFound();
            }
            var command = _mapper.Map<Command>(commandDto);
            _repository.CreateCommand(platformId, command);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetCommand), new { platformId = platformId, commandId = commandReadDto.Id}, commandReadDto);
        }



    }
}