namespace OCP.Model
{
    public class Grupo : IGrupo
    {
        GeneroMusical genero { get; }

        public Grupo(GeneroMusical musical)
        {
            this.genero = musical;
        }

        public void AsignarFestival()
        {
            Console.WriteLine($"Asignado a un festival {genero}");
        }
    }
}