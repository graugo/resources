namespace EX.First.WebApi.Models.Response
{
    public class RouteCostResponse
    {
        public decimal TotalAmount { get; set; }
        public decimal PricesPerLunarDay { get; set; }
        public TaxResponse Taxes { get; set; }
    }
}