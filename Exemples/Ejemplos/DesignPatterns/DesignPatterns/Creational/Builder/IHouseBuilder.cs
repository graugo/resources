namespace DesignPatterns.Creational.Builder
{
    internal interface IHouseBuilder
    {
        void Reset();
        void BuildWindows();
        void BuildRoof();
        void BuildWalls();
        void BuildDoors();
        void BuildGarage();
    }
}
