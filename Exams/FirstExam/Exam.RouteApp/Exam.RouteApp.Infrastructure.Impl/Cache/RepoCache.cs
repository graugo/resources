using Exam.RouteApp.Infrastructure.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Cache
{
    public class RepoCache : IRepoCache
    {
        public List<PlanetDTO> Planets => _planets;
        private List<PlanetDTO> _planets;
        public double BasePrice => _basePrice;
        private double _basePrice;
        public RepoCache()
        {
            _planets = _planets ?? new List<PlanetDTO>();
        }
        public List<PlanetDTO> SetPlanets(List<PlanetDTO> planets)
        {
            if (_planets == null)
            {
                _planets = planets;
            }
            return _planets;
        }
        public double SetBasePrice(double basePrice)
        {
            if (_basePrice <= 0)
            {
                _basePrice = basePrice;
            }
            return _basePrice;
        }
    }
}
