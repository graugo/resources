
Tuberculo zanahoria = new Patata(); 
zanahoria.ObtenerColor();
class Zanahoria : Tuberculo
{ 
    public override void ObtenerColor() 
    { 
        Console.WriteLine("Naranja"); 
    } 
}
class Patata : Zanahoria
{ 
    public override void ObtenerColor() 
    { 
        Console.WriteLine("Amarillo"); 
    } 
}
abstract class Tuberculo
{
    public abstract void ObtenerColor();
}