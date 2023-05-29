namespace OCP.Model
{
    class Festival { 
        public void AsignarFestival(Grupo grupo) 
        {
            grupo.AsignarFestival();
            /*
            switch (grupo.genero) { 
                case GeneroMusical.Pop: //asignar a un festival
                    Console.WriteLine("Assignado un grupo Pop");
                    break;
                case GeneroMusical.Rock: //asignar a un festival
                    Console.WriteLine("Assignado un grupo Rock");
                    break;
                default:
                    Console.WriteLine("No apto");
                    break;//no contratar
    
            } 
            */
        }
    }
}
