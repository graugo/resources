using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Infrastructure.Contracts.Mappers;
using HiveApp.Library.Model;
using HiveApp.ServiceLibrary.Contracts.Contracts;

namespace HiveApp.ServiceLibrary.Impl.Implementations
{
    public class BeeCreateService : IBeeCreateService
    {
        IHiveRepository _repository;
        IRepositoryMapper _mapper;
        public BeeCreateService(IHiveRepository hiveRepository, IRepositoryMapper mapper)
        {
            _repository = hiveRepository;
            _mapper = mapper;

        }
        public void Create(BeeEntity bee)
        {
            var hive = _repository.ReadHive();
            hive.AddBee(bee);
            _repository.WriteHive(_mapper.ToHiveDTO(hive));
        }
    }
}
