using LifeApp.Model;
using LifeApp.Steps.Concrete;

var birth = new Birth();
var childhood = new Childhood();
var adolescence = new Adolescence();
var adulthood = new Adulthood();
var oldAge = new OldAge();
var death = new Death();

birth.SetNext(childhood).SetNext(adolescence).SetNext(adulthood).SetNext(oldAge).SetNext(death);

Person john = new Person("John Doe", 49);
Person johana = new Person("Johana Doe", 51);

birth.Handle(john);
birth.Handle(johana);