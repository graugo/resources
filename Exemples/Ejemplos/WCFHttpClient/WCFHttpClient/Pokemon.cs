using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFHttpClient
{
    public class Pokemon
    {
        public List<PokemonTypes> Types { get; set; }
    }

    public class PokemonTypes
    {
        [JsonProperty("slot")]
        public int Id { get; set; }
        public PokemonType Type { get; set; }
    }

    public class PokemonType
    {
        public string Name { get; set; }
        public string URL { get; set; }
    }
}