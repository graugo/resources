using System.Runtime.Serialization;

namespace WCFHttpClient.Models.Request
{
    [DataContract]
    public class PokemonRequest
    {
        [DataMember(IsRequired = false)]
        public int Id { get; set; }
        [DataMember(IsRequired = false)]
        public string Name { get; set; }
    }
}