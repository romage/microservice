

using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Text.Json;
using CommandsService.Dtos;
using CommandsService.Data;
using CommandsService.Models;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly AutoMapper.IMapper _mapper;

        public EventProcessor(
            IServiceScopeFactory scopeFactory,
            AutoMapper.IMapper mapper)
        {
            this._scopeFactory = scopeFactory;
            this._mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);
            switch(eventType)
            {
                case EventType.PlatformPublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> determining event");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
            switch(eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform published event detected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> could not determine event type");
                    return EventType.Undetermined;
            }
        }

        private void addPlatform(string platformPublishedMessage)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();
                var platformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);
                try
                {
                    var plat = _mapper.Map<Platform>(platformPublishedDto);
                    if(!repo.ExternalPlatformExists(plat.ExternalId))
                    {
                        repo.CreatePlatform(plat);
                        repo.SaveChanges();
Console.WriteLine("--> platform added");

                    }else
                    {
                    Console.WriteLine("--> platform already exists");

                    }
                } catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not add platform: {ex.Message}");
                }
            }
        }       
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}