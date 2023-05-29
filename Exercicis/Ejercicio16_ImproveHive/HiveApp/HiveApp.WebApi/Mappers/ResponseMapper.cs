using HiveApp.Library.Models;
using HiveApp.WebApi.Models.Request;
using HiveApp.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveApp.WebApi.Mappers
{
    public class ResponseMapper : IResponseMapper
    {
        public BeeEntity ToBeeEntity(BeeRequest request)
        {
            return new BeeEntity
            {
                Id = default,
                Name = request.Name,
                Recolection = request.Recolection,
                Time = request.Time,
                State = request.State,
                Incidents = request.Incidents,
            };
        }

        public BeeResponse ToBeeResponse(BeeEntity entity)
        {
            return new BeeResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Recolection = entity.Recolection,
                Time = entity.Time,
                State = entity.State,
                Incidents = entity.Incidents,
            };
        }

        public List<BeeResponse> ToBeeResponseList(List<BeeEntity> entityList)
        {
            return entityList.Select( x =>  ToBeeResponse(x)).ToList();
        }
    }
}