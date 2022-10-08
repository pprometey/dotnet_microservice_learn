using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.EventProcessing;

public class EnventProcessor : IEventProcessor
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMapper _mapper;

    public EnventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _mapper = mapper;
    }

    public void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);
        
        switch(eventType)
        {
            case EventType.PlatformPublished:
                AddPlatform(message);
                break;
            default:
                break;
        }
    }

    private void AddPlatform(string platformPublishedMessage)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

            var platformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

            try
            {
                var platform = _mapper.Map<Platform>(platformPublishedDto);
                if(!repository.ExternalPlatformExist(platform.ExternalId))
                {
                    repository.CreatePlatform(platform);
                    repository.SaveChanges();
                    Console.WriteLine("--> Platform added!");
                }
                else
                {
                    Console.WriteLine("--> Platform already exists...");
                }
 
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> ould not add Platform to DB {ex.Message}");
            }
        }
    }

    private EventType DetermineEvent(string notificationMessage)
    {
        Console.WriteLine("--> Determining Event");

        var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

        switch(eventType.Event)
        {
            case "Platform_Published":
                Console.WriteLine("--> Platform Published Event Detected");
                return EventType.PlatformPublished;
            default:
                Console.WriteLine("--> Could not determine the event type");
                return EventType.Undetermined;
        }
    }
}

enum EventType
{
    PlatformPublished,
    Undetermined
}