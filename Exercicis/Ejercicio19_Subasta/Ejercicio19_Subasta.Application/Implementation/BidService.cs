using Ejercicio19_Subasta.Application.Contracts;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Application.Implementation
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public bool BidOnAuction(int id, int value)
        {
            var auctions = _bidRepository.GetActualAuctions();
            auctions = CheckAliveAuctions(auctions);
            foreach (var a in auctions)
            {
                if (a.AuctionId == id)
                {         
                    if (a.ActualPrice >= value)
                    {
                        return false;
                    }
                    else
                    {
                        // Insert transaction
                        _bidRepository.SaveTransaction(new TransactionEntity
                        {
                            AuctionId = a.AuctionId,
                            OriginalValue = a.ActualPrice,
                            Increment = value - a.ActualPrice,
                            FinalValue = value
                        });
                        a.ActualPrice = value;
                        a.NumberBid++;
                        _bidRepository.UpdateCache(auctions);
                        return true;
                    }                    
                }
            }            
            return false;
        }

        public List<AuctionEntity> GetAliveAuctions()
        {
            var auctions = _bidRepository.GetActualAuctions();
            return CheckAliveAuctions(auctions);
        }

        public AuctionEntity GetAuctionById(int id)
        {
            var auction = _bidRepository.GetById(id);
            return auction;
        }

        private List<AuctionEntity> CheckAliveAuctions(List<AuctionEntity> auctions)
        {
            List<AuctionEntity> result = new List<AuctionEntity>();
            foreach (AuctionEntity a in auctions)
            {
                var start = a.Created;
                var now = DateTime.Now.TimeOfDay;
                var fiveMin = new TimeSpan(0, 5, 0);
                if (now - start > fiveMin)      //Han passat 5min
                {
                    if (a.NumberBid != 0)
                    {
                        _bidRepository.SaveAuction(a);
                    }
                } else
                {
                    result.Add(a);
                }
            }

            _bidRepository.UpdateCache(result);

            return result;
        }
    }
}
