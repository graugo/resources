using CinrelApp.Model;

IKing[] kings =
{
    new KingFifth(),
    new KingSeventh(),
    new KingNinth(),
    new Cerelon()
};

foreach (var king in kings)
{
    king.TakeThrone();
    king.PublicManagement();
    king.Abdicate();
}