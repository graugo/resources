using HiveApp.Infrastructure.Contracts.Models;
using HiveApp.Library.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HiveApp.Infrastructure.Contracts.Mappers
{
    public class RepositoryMapper : IRepositoryMapper
    {
        public BeeDTO ToBeeDTO(BeeEntity beeEntity)
        {
            return new BeeDTO
            {
                Id = beeEntity.Id,
                Name = beeEntity.Name,
                Recollection = beeEntity.Recollection,
                Time = beeEntity.Time,
                State = beeEntity.State,
                Incidents = beeEntity.Incidents
            };
        }

        public BeeEntity ToBeeEntity(BeeDTO beeDTO)
        {
            return new BeeEntity
            {
                Id = beeDTO.Id,
                Name = beeDTO.Name,
                Recollection = beeDTO.Recollection,
                Time = beeDTO.Time,
                State = beeDTO.State,
                Incidents = beeDTO.Incidents
            };
        }

        public HiveDTO ToHiveDTO(HiveEntity hiveEntity)
        {
            List<BeeDTO> beeListDTO = new List<BeeDTO>();
            foreach (var bee in hiveEntity.BeeList)
            {
                beeListDTO.Add(ToBeeDTO(bee));
            }
            return new HiveDTO
            {
                BeeList = beeListDTO
            };
        }

        public HiveEntity ToHiveEntity(HiveDTO hiveDTO)
        {
            List<BeeEntity> beeListEntity = new List<BeeEntity>();
            foreach (var bee in hiveDTO.BeeList)
            {
                beeListEntity.Add(ToBeeEntity(bee));
            }
            return new HiveEntity
            {
                BeeList = beeListEntity
            };
        }
    }
}
