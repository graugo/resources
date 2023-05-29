using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using EJ15.Tournament.Library.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon
{
    public interface ITrainerMapper
    {
        IEnumerable<TrainerEntity> ToTrainerEntityList(IEnumerable<TrainerDto> dto);
        TrainerEntity ToTrainerEntity(TrainerDto dto);
        TrainerDto ToTrainerDto(TrainerEntity entity); 
    }
}
