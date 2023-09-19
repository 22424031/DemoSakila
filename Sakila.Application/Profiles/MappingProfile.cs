using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Sakila.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Actor, Dtos.Actors.ActorDto>().ReverseMap();
            CreateMap<Domain.Actor, Dtos.Actors.CreateActor>().ReverseMap();

            CreateMap<Domain.City, Dtos.Citys.CityDto>().ReverseMap();
        }
    }
}
