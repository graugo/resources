using UnitTestApp.ServiceLibrary.Contracts.Models;

namespace UnitTestApp.ServiceLibrary.Contracts
{
    public interface ISaveService
    {
        bool Save(Hero hero);
    }
}
