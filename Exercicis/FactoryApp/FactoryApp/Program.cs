using FactoryApp.Model.Factory;
using FactoryApp.Service;

IGuiFactory factory;
Console.WriteLine("Choose OS");
string? config = Console.ReadLine();

if (config == "windows")
    factory = new WinFactory();
else if (config == "mac")
    factory = new MacFactory();
else
    throw new Exception("RIP");

AppService service = new AppService(factory);
service.Initialize();