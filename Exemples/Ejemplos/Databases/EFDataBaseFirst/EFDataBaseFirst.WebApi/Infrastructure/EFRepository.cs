using EFDataBaseFirst.WebApi.EFContext;
using EFDataBaseFirst.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFDataBaseFirst.WebApi.Infrastructure
{
    public class EFRepository
    {
        private readonly AdoSampleDBEntities _adoSampleDbEntity;

        public EFRepository()
        {
            _adoSampleDbEntity = new AdoSampleDBEntities();
        }

        public IEnumerable<AdoResponse> GetAll() 
        {
            var data = _adoSampleDbEntity.AdoTable.OrderBy(x => x.Id);

            return data.Select(x => new AdoResponse 
            {
                Id= x.Id,
                Age = x.age ?? 0,
                Name = x.Name
            });
        }

        public int Insert(AdoRequest request) 
        {
            var data = _adoSampleDbEntity.AdoTable.Add(new AdoTable 
            { 
                age = request.Age,
                Name= request.Name
            });

            _adoSampleDbEntity.SaveChanges();

            return data.Id;
        }

        public int Update(int id, AdoRequest request) 
        {
            var data = _adoSampleDbEntity.AdoTable.FirstOrDefault(x => x.Id == id);
            data.Name = request.Name;
            data.age = request.Age;

            _adoSampleDbEntity.SaveChanges();
            return data.Id;
        }

        public int Delete(int id) 
        {
            var deleteObject = _adoSampleDbEntity.AdoTable.FirstOrDefault(_x => _x.Id == id);
            var data = _adoSampleDbEntity.AdoTable.Remove(deleteObject);

            _adoSampleDbEntity.SaveChanges();
            return data.Id;
        }
    }
}