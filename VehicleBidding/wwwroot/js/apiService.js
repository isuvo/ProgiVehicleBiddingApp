// apiService.js declare golbal namespace
window.MyBiddingApp = window.MyBiddingApp || {};

const API_URL = "http://localhost:5238/BidCars/api/";
window.MyBiddingApp.apiService = {
    calculatePrice: async function(basePrice, vehicleType) {
        try {
            const response = await axios.post(API_URL + "pricecalculation",
                {
                    basePrice: basePrice,
                    vehicleType: vehicleType,
                });
            return response.data;
        } catch (error) {
            console.error("Error in API call:", error);
            throw error;
        }
    }
};