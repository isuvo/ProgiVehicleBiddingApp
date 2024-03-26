using BidCalculatorApi.Interfaces;

namespace BidCalculatorApi.Services
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        public decimal CalculateAssociationFee(decimal basePrice)
        {
            return basePrice <= 500 ? 5 :
                basePrice <= 1000 ? 10 :
                basePrice <= 3000 ? 15 : 20;
        }

        public decimal CalculateBasicUserFee(decimal basePrice, string vehicleType)
        {
            decimal feePercentage = 0.10m; // 10%
            return vehicleType == "Common" ?
                //Constrain between min and max value
                Math.Clamp(basePrice * feePercentage, 10, 50) : 
                Math.Clamp(basePrice * feePercentage, 25, 200);
        }

        public decimal CalculateSpecialFee(decimal basePrice, string vehicleType)
        {
            decimal feePercentage = vehicleType == "Common" ? 0.02m : 0.04m; // 2% for Common, 4% for Luxury
            return basePrice * feePercentage;
        }
    }
}
