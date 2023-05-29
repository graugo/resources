
//3 fabricas con 3 tipos de muebles
using DesignPatterns.Behravior.ChainOfResponsability.Model;
using DesignPatterns.Behravior.ChainOfResponsability.Steps;
using DesignPatterns.Behravior.Iterator;
using DesignPatterns.Behravior.Iterator.Nodes;
using DesignPatterns.Behravior.Strategy;
using DesignPatterns.Behravior.Strategy.Strategies;
using DesignPatterns.Creational.Builder;
using DesignPatterns.Creational.Factory.Creators;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Structurals.Adapter;
using DesignPatterns.Structurals.Composite;
using DesignPatterns.Structurals.Decorator;

#region .: Factory :.

IFurnitureCreator creator = null;
string tipology = Console.ReadLine();
switch (tipology)
{
    case "Victorian":
        creator = new VictorianFurnitureCreator();
        break;
    case "Modern":
        creator = new ModernFurnitureCreator();
        break;
    case "ArtDeco":
        creator = new ArtDecoFurnitureCreator();
        break;
    default:
        break;
}

Console.WriteLine(creator.CreateChair());
Console.WriteLine(creator.CreateTable());
Console.WriteLine(creator.CreateCloset());

#endregion

#region .: Builder :.

IHouseBuilder builder = new HouseBuilder();
Director director = new Director(builder);
director.Make();

House house = ((HouseBuilder)builder).Build();

Console.WriteLine(house.HasGarage+","+house.HasDoors+","+house.HasRoof+","+house.HasWindows+","+house.HasWalls);

#endregion

#region .: Singleton :.

var goberment = Goberment.Instance();

#endregion

#region .: Adapter :.

var peg = new SquarePeg(3);
var pegAdapter = new SquarePegAdapter(peg);
RoundHole roundHole = new RoundHole(4);
Console.WriteLine(roundHole.Fits(pegAdapter));

#endregion

#region .: Composite :.

var composite = new CompositeGraphic();
var dot = new Dot(3, 4);
composite.Add(dot);
var subComposite = new CompositeGraphic();
subComposite.Add(new Circle(6, 9, 34));
composite.Add(subComposite);
composite.Add(new Circle(8,2,90));
composite.Remove(dot);

composite.Draw();

#endregion

#region .: Decorator :.

IDataSource dataSource = new FileDataSource("File");
dataSource = new CompressionDataSource(dataSource);
dataSource = new EncryptionDataSource(dataSource);

dataSource.WriteData("some data");

#endregion

#region .: Strategy :.

var input = Console.ReadLine();
var context = new StringStrategyContext();
switch (input)
{
    case "Reverse": 
        context.SetStrategy(new ReverseStrategy()); 
        break;
    case "Random": 
        context.SetStrategy(new RandomStrategy()); 
        break;
    case "Ordered": 
        context.SetStrategy(new OrderedStrategy()); 
        break;
    default: 
        break;
}

context.Execute(input);

#endregion

#region .: Chain of responsability :.

var week1 = new Week1();
var week2 = new Week2();
var week3 = new Week3();
var week4 = new Week4();
var exam1 = new Exam1();

week1.SetNext(week2);
week2.SetNext(week3);
week3.SetNext(week4);
week4.SetNext(exam1);

var student = new Student { Name = "adrian", Knowledge = 0};
var student1 = new Student { Name = "Maria", Knowledge = 0 };

var worker = week1.HandlerStudent(student);
var worker1 = week1.HandlerStudent(student1);

Console.WriteLine(worker.Success);

#endregion

#region .: Iterator :.

var listOfValues = new List<int> { 8, 19, 25, 2, 4 };
var listAggregate = new ListAggregate();

foreach (var value in listOfValues)
{
    listAggregate.Insert(value);
}
var listIterator = listAggregate.CreateIterator();
while (listIterator.MoveNext()) 
{ 
    Console.WriteLine(listIterator.GetCurrent()); 
}

var treeAggregate = new NodeCollection();
foreach (var value in listOfValues) 
{ 
    treeAggregate.Insert(value); 
}

var treeIterator = treeAggregate.CreateIterator();

while (treeIterator.MoveNext()) 
{ 
    Console.WriteLine(treeIterator.GetCurrent()); 
}

#endregion