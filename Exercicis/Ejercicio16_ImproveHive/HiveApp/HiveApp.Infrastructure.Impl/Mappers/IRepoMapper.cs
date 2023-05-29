using HiveApp.Infrastructure.Impl.Models;
using HiveApp.Library.Models;
using System.Collections.Generic;

namespace HiveApp.Infrastructure.Impl.Mappers
{
    public interface IRepoMapper
    {
        List<BeeEntity> ToBeeEntityList(List<BeeDTO> dto);
    }
}
