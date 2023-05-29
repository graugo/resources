namespace EX.First.Library.Entities
{
    public class TaxEntity
    {
        public decimal OriginDefenseCost { get; set; }
        public decimal DestinationDefenseCost { get; set; }
        public decimal EliteDefenseCost => GetEliteDefenseCost();

        public decimal GetTotal() 
        {
            return OriginDefenseCost + DestinationDefenseCost + EliteDefenseCost;
        }

        private decimal GetEliteDefenseCost() 
        {
            var defenseCost = OriginDefenseCost + DestinationDefenseCost;
            return defenseCost > 40 ? defenseCost - (defenseCost * 0.4M) : 0;
        }
    }
}