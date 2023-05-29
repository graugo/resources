using AutoMapper;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.DTO;
using Ejercicio19_Subasta.Infrastructure.DTO.API;


namespace Ejercicio19_Subasta.Infrastructure.Profiles
{
    public class PokemonDtoProfile : Profile
    {
        public PokemonDtoProfile() 
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
