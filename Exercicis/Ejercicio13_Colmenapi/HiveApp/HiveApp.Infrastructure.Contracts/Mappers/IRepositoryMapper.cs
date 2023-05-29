using HiveApp.Infrastructure.Contracts.Models;
using HiveApp.Library.Model;

namespace HiveApp.Infrastructure.Contracts.Mappers
{
    public interface IRepositoryMapper
    {
        BeeEntity ToBeeEntity(BeeDTO beeDTO);
        BeeDTO ToBeeDTO(BeeEntity beeEntity);
        HiveEntity ToHiveEntity(HiveDTO hiveDTO);
        HiveDTO ToHiveDTO(HiveEntity hiveEntity);
    }
}
