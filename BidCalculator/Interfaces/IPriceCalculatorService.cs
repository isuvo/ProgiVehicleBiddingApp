namespace BidCalculatorApi.Interfaces;

public interface IPriceCalculatorService
{
    decimal CalculateBasicUserFee(decimal basePrice, string vehicleType);
    decimal CalculateSpecialFee(decimal basePrice, string vehicleType);
    decimal CalculateAssociationFee(decimal basePrice);
}