using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.EventProcessing

{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;

        }
        void IEventProcessor.ProcessEvent(string message)
        {

            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformPublished:

                    break;
                default:
                    break;
            }

        }
        private EventType DetermineEvent(string notfMessage)
        {
            Console.WriteLine("--> Determening Event");
            // If we wanted tou use NewtonSoft dynamic deserializer its end up with a non-typed message so we use type...
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notfMessage);

            switch (eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("Platf. publish event detected.");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }

        }
        //The reason behind the create new Repository class not use the depend. injc.
        //because lifetime of the repo. service in eventprocessor must same or greater lifetime than the service to injected class
        //so that makse some problem 

        private void addPlatform(string platformPublishedMessage)
        {

            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();
                var platformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);
                try
                {
                    var plat = _mapper.Map<Platform>(platformPublishedDto);
                    if (!repo.ExternalPlatformExists(plat.ExternalId))
                    {
                        repo.CreatePlatform(plat);
                        repo.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("--> Platform already exists!");
                     }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to DB {ex.Message}");
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