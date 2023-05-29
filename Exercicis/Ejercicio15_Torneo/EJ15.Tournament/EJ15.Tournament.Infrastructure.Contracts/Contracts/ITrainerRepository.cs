using EJ15.Tournament.Library.Models.Pokemon;
using System.Collections.Generic;

namespace EJ15.Tournament.Infrastructure.Contracts.Contracts
{
    public interface ITrainerRepository
    {
        IEnumerable<TrainerEntity> GetTrainers();
        bool SetTrainer(TrainerEntity entity);
        bool RemoveTrainer(TrainerEntity entity);
    }
}
