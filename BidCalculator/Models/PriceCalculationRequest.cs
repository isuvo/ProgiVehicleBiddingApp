namespace BidCalculatorApi.Models;

public class PriceCalculationRequest
{
    public decimal BasePrice { get; set; }
    public required string VehicleType { get; set; } // "Common" or "Luxury"
}