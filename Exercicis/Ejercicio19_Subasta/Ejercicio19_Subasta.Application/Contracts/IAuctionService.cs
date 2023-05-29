

using Ejercicio19_Subasta.Domain.Models;

namespace Ejercicio19_Subasta.Application.Contracts
{
    public interface IAuctionService
    {
        Task<bool> Register();
    }
}
