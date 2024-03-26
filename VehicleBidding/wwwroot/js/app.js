new Vue({
    el: "#app",
    data() {
        return {
            vehiclePrice: 0,
            vehicleType: "Common",
            calculationResult: null,
        };
    },
    methods: {
        async calculateTotal() {
            if (this.vehiclePrice > 0) {
                try {
                    const result =
                        await window.MyBiddingApp.apiService.calculatePrice(this.vehiclePrice, this.vehicleType);
                    this.calculationResult = result;
                } catch (error) {
                    console.error("There was an error calculating the total price:", error);
                    this.calculationResult = null;
                }
            } else {
                this.calculationResult = null;
            }
        },
        resetForm() {
            this.vehiclePrice = 0;
            this.vehicleType = "Common";
            this.calculationResult = null;
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