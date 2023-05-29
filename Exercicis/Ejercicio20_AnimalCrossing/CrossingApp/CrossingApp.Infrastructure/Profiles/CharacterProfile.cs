using AutoMapper;
using CrossingApp.Domain.Models;
using CrossingApp.Infrastructure.Models.Deserialize;
using CrossingApp.Infrastructure.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingApp.Infrastructure.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile() 
        { 
            CreateMap<CharacterDTO, CharacterEntity>().ReverseMap();
            CreateMap<CharacterDeserialize, CharacterDTO>()
                .ForMember(
                x => x.Name,
                y => y.MapFrom(z => z.NamesList.UsName)
                ).ReverseMap();
        }
    }
}
