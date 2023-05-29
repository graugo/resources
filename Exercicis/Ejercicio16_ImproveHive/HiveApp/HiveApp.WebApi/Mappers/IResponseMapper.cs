using HiveApp.Library.Models;
using HiveApp.WebApi.Models.Request;
using HiveApp.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.WebApi.Mappers
{
    public interface IResponseMapper
    {
        BeeResponse ToBeeResponse(BeeEntity entity);
        List<BeeResponse> ToBeeResponseList(List<BeeEntity> entityList);
        BeeEntity ToBeeEntity(BeeRequest request);
    }
}
