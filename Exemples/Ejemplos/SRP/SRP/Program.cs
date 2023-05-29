

using SRP.LSP;
using SRP.OCP;
using SRP.SRP;

//var fabrica = new Fabrica();

//fabrica.CrearTablones();

//var ocp = new OCP();
//var ocp1 = new OCP1();

//var operation = ocp1.operation();
//var operation1 = ocp1.operation();

//Console.WriteLine($"{operation} {operation1}");

var superclass = new SuperClass();
superclass.method1();
superclass = new SubClass1();
superclass.method1();
superclass = new Subclass2();
superclass.method1();