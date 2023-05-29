namespace EX.First.Library.Entities
{
    public class RouteEntity
    {
        public string Origin { get; set; }
        public string OriginCode { get; set; }
        public string Destination { get; set; }
        public string DestinationCode { get; set; }
        public decimal Distance { get; set; }
    }
}
