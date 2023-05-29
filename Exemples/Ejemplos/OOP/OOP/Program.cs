//using OOP.Encapsulacion;
//using OOP.Herencia;
//using OOP.Polimorfismo;

//Encapsulacion encap = new Encapsulacion(89);
//var a = encap.calc;

//var consumer = new OOP.Herencia.Consumer();
//consumer.method1();
//consumer.method2();
//consumer.method3();

//var base1 = new OOP.Herencia.Base();
//base1.method2();
//base1 = new OOP.Herencia.Consumer();
//base1.method2();
//base1 = new OOP.Polimorfismo.Polimorfismo();
//base1.method2();

//List<Base> list = new List<Base> { new Consumer(), new Polimorfismo(), new Base()};
//list.Add(base1);
//foreach (var item in list)
//{
//    Console.WriteLine(item.GetType());
//    if(item.GetType() == typeof(Consumer))
//        ((Consumer)item).method3();
//}

using OOP.EjercicioClase;

Console.WriteLine("primer numero");
var x = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("segundo numero");
var y = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Selecciona operacion");
var operacion = Console.ReadLine();

switch (operacion)
{
	case "+":
        var suma = new Suma
        {
            operator1 = x,
            operator2 = y
        };
        Console.WriteLine(suma.Calc());
		break;
	default:
		break;
}

List<CalculadoraAbst> list = new List<CalculadoraAbst>();
list.Add(new Suma { operator1 = x, operator2 = y });