using Ejercicio19_Subasta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Application.Contracts
{
    public interface IBidService
    {
        bool BidOnAuction(int id, int value);

        List<AuctionEntity> GetAliveAuctions();
        AuctionEntity GetAuctionById(int id);
    }
}
