using EFHibrid.WebApi.Infrastructure.Context;
using EFHibrid.WebApi.Infrastructure.Models;
using EFHibrid.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFHibrid.WebApi.Infrastructure
{
    public class EFRepository
    {
        private readonly AdoSampleDbContext _adoSampleDbEntity;

        public EFRepository()
        {
            _adoSampleDbEntity = new AdoSampleDbContext();
        }

        public IEnumerable<AdoResponse> GetAll()
        {
            var data = _adoSampleDbEntity.AdoTables.OrderBy(x => x.Id);

            return data.Select(x => new AdoResponse
            {
                Id = x.Id,
                Age = x.Age ?? 0,
                Name = x.Name
            });
        }

        public int Insert(AdoRequest request)
        {
            var data = _adoSampleDbEntity.AdoTables.Add(new AdoTable
            {
                Age = request.Age,
                Name = request.Name
            });

            _adoSampleDbEntity.SaveChanges();

            return data.Id;
        }

        public int Update(int id, AdoRequest request)
        {
            var data = _adoSampleDbEntity.AdoTables.FirstOrDefault(x => x.Id == id);
            data.Name = request.Name;
            data.Age = request.Age;

            _adoSampleDbEntity.SaveChanges();
            return data.Id;
        }

        public int Delete(int id)
        {
            var deleteObject = _adoSampleDbEntity.AdoTables.FirstOrDefault(_x => _x.Id == id);
            var data = _adoSampleDbEntity.AdoTables.Remove(deleteObject);

            _adoSampleDbEntity.SaveChanges();
            return data.Id;
        }
    }
}