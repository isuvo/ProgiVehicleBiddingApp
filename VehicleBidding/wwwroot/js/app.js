new Vue({
    el: '#app',
    data() {
        return {
            vehiclePrice: 0,
            vehicleType: 'Common',
            calculationResult: null,
        };
    },
    methods: {
        async calculateTotal() {
            if (this.vehiclePrice > 0) {
                try {
                    const result = await window.MyBiddingApp.apiService.calculatePrice(this.vehiclePrice, this.vehicleType);
                    this.calculationResult = result;
                } catch (error) {
                    console.error("There was an error calculating the total price:", error);
                    this.calculationResult = null; // Reset the result in case of error
                }
            } else {
                this.calculationResult = null; // Reset the result if price is 0 or not valid
            }
        },
        resetForm() {
            this.vehiclePrice = 0; // Reset to default or null
            this.vehicleType = 'Common'; // Reset to default type
            this.calculationResult = null; // Clear calculation result
        }
    },
    watch: {
        vehiclePrice(newVal, oldVal) {
            if (newVal !== oldVal && newVal > 0) {
                this.calculateTotal();
            }
        },
        vehicleType(newVal, oldVal) {
            if (newVal !== oldVal) {
                this.calculateTotal();
            }
        }
    }
});
