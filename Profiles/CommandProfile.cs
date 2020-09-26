using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            //       source -> destination
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}