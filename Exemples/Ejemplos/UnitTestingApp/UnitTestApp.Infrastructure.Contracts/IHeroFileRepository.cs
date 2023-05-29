using System.Collections.Generic;

namespace UnitTestApp.Infrastructure.Contracts
{
    public interface IHeroFileRepository
    {
        bool Save(IEnumerable<string> heroes);
    }
}
