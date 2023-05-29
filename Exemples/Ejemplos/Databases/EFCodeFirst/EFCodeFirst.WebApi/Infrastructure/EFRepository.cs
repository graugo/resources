using EFCodeFirst.WebApi.Infrastructure.Context;
using EFCodeFirst.WebApi.Infrastructure.Models;
using EFCodeFirst.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirst.WebApi.Infrastructure
{
    public class EFRepository
    {
        private readonly EFCodeFirstContext _adoSampleDbEntity;

        public EFRepository()
        {
            _adoSampleDbEntity = new EFCodeFirstContext();
        }

        public IEnumerable<EFResponse> GetAll()
        {
            var data = _adoSampleDbEntity.EfCodeFists.OrderBy(x => x.Id);

            return data.Select(x => new EFResponse
            {
                Id = x.Id,
                Age = x.Age,
                Name = x.Name
            });
        }

        public int Insert(EFRequest request)
        {
            var data = _adoSampleDbEntity.EfCodeFists.Add(new EfCodeFistModel
            {
                Age = request.Age,
                Name = request.Name
            });

            _adoSampleDbEntity.SaveChanges();

            return data.Id;
        }

        public int Update(int id, EFRequest request)
        {
            var data = _adoSampleDbEntity.EfCodeFists.FirstOrDefault(x => x.Id == id);
            data.Name = request.Name;
            data.Age = request.Age;

            _adoSampleDbEntity.SaveChanges();
            return data.Id;
        }

        public int Delete(int id)
        {
            var deleteObject = _adoSampleDbEntity.EfCodeFists.FirstOrDefault(_x => _x.Id == id);
            var data = _adoSampleDbEntity.EfCodeFists.Remove(deleteObject);

            _adoSampleDbEntity.SaveChanges();
            return data.Id;
        }
    }
}