using CyborgApp.Model;
using CyborgApp.Model.Builder;
using CyborgApp.Model.Decorators;
using CyborgApp.Model.Singleton;


// decorator usage
IExtremity arm = new Arm();
arm = new BaseArmDecorator(arm);
arm = new LaserDecorator(arm);
arm = new SteelDecorator(arm);

// builder usage
Director director = new Director();
LegBuilder builder = new LegBuilder();
director.ConstructBaseLeg(builder);
Leg superLeg = builder.GetProduct();

// Singleton usage
Head head = Head.GetInstance();

IExtremity[] bodyparts =
{
    arm,
    superLeg,
    head
};

foreach (var part in bodyparts)
{
    part.Move();
}
