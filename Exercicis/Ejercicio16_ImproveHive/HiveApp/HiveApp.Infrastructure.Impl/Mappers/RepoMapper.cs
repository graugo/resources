using HiveApp.Infrastructure.Impl.Models;
using HiveApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.Infrastructure.Impl.Mappers
{
    public class RepoMapper : IRepoMapper
    {
        public List<BeeEntity> ToBeeEntityList(List<BeeDTO> dto)
        {
            return dto.Select(x => new BeeEntity
            {
                Id = x.Id,
                Name = x.Name,
                Recolection = x.Recolection,
                Time = x.Time,
                State = x.State,
                Incidents = x.Incidents,
            }).ToList();
        }
    }
}
