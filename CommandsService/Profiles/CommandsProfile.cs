using System.Runtime.ConstrainedExecution;
using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.Profiles
{

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target dont forget
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<PlatformPublishedDto, Platform>().ForMember(x => x.ExternalId,opt=>opt.MapFrom(src=>src.Id));  
        }
    }
}