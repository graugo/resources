using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.DTO.API;
using Ejercicio19_Subasta.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Ejercicio19_Subasta.Infrastructure.IntegrationTest.Profiles
{
    public class InfrastructureTestingProfile : Profile
    {
        public InfrastructureTestingProfile()
        {
            CreateMap<PokemonSpecieEntity, PokemonSpecieDTO>().ReverseMap();
            CreateMap<PokemonSpecieEntity, PokemonApiDTO>().ReverseMap();
            CreateMap<LocationEntity, LocationDTO>().ReverseMap();
            CreateMap<LocationEntity, LocationApiDTO>().ReverseMap();
            CreateMap<PokemonLocationEntity, PokemonLocationDTO>().ReverseMap();
            CreateMap<AuctionEntity, AuctionDTO>().ReverseMap();
            CreateMap<HistoricEntity, HistoricDTO>().ReverseMap();
            CreateMap<PokemonApiDTO, PokemonSpecieDTO>().ReverseMap();
            CreateMap<LocationApiDTO, LocationDTO>().ReverseMap();
            CreateMap<TransactionDTO, TransactionEntity>().ReverseMap();
        }
    }
}
