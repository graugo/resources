using System.Runtime.Serialization;

namespace WCFHttpClient.Models.Response
{
    [DataContract]
    public class PokemonResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PokemonType { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
}