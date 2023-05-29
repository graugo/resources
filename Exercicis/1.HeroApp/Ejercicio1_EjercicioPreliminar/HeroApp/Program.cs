using HeroApp.classes;
using HeroApp.controller;

Inn inn = new Inn();
bool exit = false;

Console.WriteLine("Welcome to the Inn.");

while (!exit)
{
    Console.WriteLine("What's your order?\n" +
    "1.Read\n" +
    "2.Add hero\n" +
    "3.Add ability to hero\n" +
    "4.Save registry\n" +
    "Exit");

    // TODO implement secure data input
    string? opAction = Console.ReadLine();

    switch (opAction){
    
        case "1":
            // TODO show all heroes
            Console.WriteLine(InnController.ListHeroes(inn));
            break;
        case "2":
             Console.WriteLine("Write the new hero's name");
            // TODO implement input controller
            string name = Console.ReadLine();
            Hero h = InnController.CreateHero(name);
            inn.AddHero(h);
            break;
        case "3":
            // TODO add ability
            break;
        case "4":
            // TODO save file
            break;
        case "exit":
            exit = true;
            break;
        default:
            // TODO error message
            break;
    }
}
