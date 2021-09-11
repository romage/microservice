using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController: ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
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
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            // var isValid = TryValidateModel(platformCreateDto);
            var model = _mapper.Map<Platform>(platformCreateDto);
            
                 _repository.CreatePlatform(model);
                 _repository.SaveChanges();
                 var platformReadDto = _mapper.Map<PlatformReadDto>(model);
                 return CreatedAtRoute(nameof(GetPlatformsById), new { id = platformReadDto.Id}, platformReadDto);
        }

    }
}