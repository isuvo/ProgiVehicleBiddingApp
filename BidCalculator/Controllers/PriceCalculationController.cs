using BidCalculatorApi.Interfaces;
using BidCalculatorApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculatorApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("BidCars/api/[controller]")]
    public class PriceCalculationController : ControllerBase
    {
        private readonly IPriceCalculatorService _priceCalculatorService;

        // Constructor injection for the price calculator service
        // we can use the primary constructor, but I prefer this way. 
        public PriceCalculationController(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService = priceCalculatorService;
        }

        [HttpPost]
        public ActionResult<PriceCalculationResponse> CalculateTotal(PriceCalculationRequest request)
        {
            var response = new PriceCalculationResponse
            {
                BasePrice = request.BasePrice,
                BasicFee = _priceCalculatorService.CalculateBasicUserFee(request.BasePrice, request.VehicleType),
                SpecialFee = _priceCalculatorService.CalculateSpecialFee(request.BasePrice, request.VehicleType),
                AssociationFee = _priceCalculatorService.CalculateAssociationFee(request.BasePrice),
                StorageFee = 100 // Fixed
            };

            response.TotalPrice = request.BasePrice + response.BasicFee + response.SpecialFee + response.AssociationFee + response.StorageFee;

            return response;
        }
       
    }
}
