using Exam.RouteApp.Library.Models;
using Exam.RouteApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.WebApi.Mappers
{
    public interface IMapper
    {
        List<PlanetResponse> ToPlanetResponseList(List<PlanetEntity> entities);
        List<RouteResponse> ToRouteResponseList(List<RouteEntity> entities);
        PriceResponse ToPriceResponse(PriceEntity entity);
        TaxesResponse ToTaxesResponse(TaxesEntity entity);
    }
}
