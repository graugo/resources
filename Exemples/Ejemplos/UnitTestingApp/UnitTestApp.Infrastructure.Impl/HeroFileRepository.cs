using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using UnitTestApp.Infrastructure.Contracts;

namespace UnitTestApp.Infrastructure.Impl
{
    public class HeroFileRepository : IHeroFileRepository
    {
        private string route = "/results/Heroes.txt";

        public HeroFileRepository()
        {

        }

        public HeroFileRepository(string route)
        {
            this.route = route;
        }

        public bool Save(IEnumerable<string> heroes)
        {
            var result = false;
            try
            {
                ValidateDirectory();
                File.AppendAllLines(route, heroes);
                result = true;
            }
            catch (Exception)
            {
                throw;
                //TODO - Log
            }

            return result;
        }

        private void ValidateDirectory() 
        {
            if (!Directory.Exists("/results"))
                Directory.CreateDirectory("/results");
        }
    }
}
