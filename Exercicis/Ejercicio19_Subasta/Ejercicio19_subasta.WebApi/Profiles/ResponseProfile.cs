using AutoMapper;
using Ejercicio19_subasta.WebApi.Models;
using Ejercicio19_Subasta.Domain.Models;

namespace Ejercicio19_subasta.WebApi.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<AuctionEntity, PokemonDetailResponse>().ReverseMap();
            CreateMap<AuctionEntity, PokemonResponse>().ReverseMap();
            
        }
    }
}
