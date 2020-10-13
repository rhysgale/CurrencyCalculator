﻿var vm = new Vue({
    el: '#currencyConverter',
    data: {
        message: 'Hello Vue!',
        numberInput: 0,
        supportedCurrencies: ["EUR", "USD", "GBP"],
        selectedFromCurrency: "",
        selectedToCurrency: "",
        currencyModel: null,
        conversionAmount: 0
    },
    methods: {
        submit: function () {
            $.ajax({
                url: "/CurrencyConvert/GetCurrencyRates/" + vm.selectedFromCurrency,
                method: "GET",
                type: "JSON",
                success: function (result) {
                    vm.currencyModel = JSON.parse(result);
                    vm.getConvertedAmount();
                }
            });
        },
        getConvertedAmount: function () {
            var conversionRate = vm.currencyModel.rates[vm.selectedToCurrency];

            vm.conversionAmount = vm.numberInput * conversionRate;
        }
    }
});