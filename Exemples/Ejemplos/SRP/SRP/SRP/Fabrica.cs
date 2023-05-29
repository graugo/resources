namespace SRP.SRP
{
    internal class Fabrica
    {
        public void Partir() { Console.WriteLine("partir"); } 
        public void CrearTablones() { Console.WriteLine("tablones"); }   
        public void LiniaProduccion() { Console.WriteLine("linia produccion"); }
    }

    internal class Almacen 
    {
        public void RecibirMercancia() { Console.WriteLine("tronco"); }
        public void TransportarMercancia() { Console.WriteLine("transportar almacen"); }
    }

    internal class Carpinteria 
    {
        public void Ajustar() { Console.WriteLine("ajustar cortes"); }
    }
}
