namespace BidCalculatorApi.Models;

public class PriceCalculationResponse
{
    public decimal BasePrice { get; set; }
    public decimal BasicFee { get; set; }
    public decimal SpecialFee { get; set; }
    public decimal AssociationFee { get; set; }
    public decimal StorageFee { get; set; } = 100; // Fixed
    public decimal TotalPrice { get; set; }
}