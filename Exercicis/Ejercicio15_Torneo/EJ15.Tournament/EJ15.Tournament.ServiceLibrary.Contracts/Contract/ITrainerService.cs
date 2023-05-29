using System;
using System.Threading.Tasks;

namespace EJ15.Tournament.ServiceLibrary.Contracts.Contract
{
    public interface ITrainerService
    {
        Task<Guid> CreateTrainer();
    }
}
