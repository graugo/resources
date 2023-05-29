using Newtonsoft.Json;

namespace WCFHttpClient.Library.Entity
{
    public class PokemonTypes
    {    
        public int Id { get; set; }
        public PokemonType Type { get; set; }      
    }
}
