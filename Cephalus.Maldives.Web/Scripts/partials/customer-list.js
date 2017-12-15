/// <reference path="../services/data-service.js" />
CustomerPartial = function () {
    return {
        Init: function () {
            $(document).on("click", "#refreshCustomerView", function () {
                CustomerPartial.GetCustomers();
            });
        },

        GetCustomers: function () {
            DataService.MakeAjaxCall(
                ["4f38fb0c-906e-4dbb-9202-1bcccdf59ae3"],
                "POST",
                "/Home/GetCustomers",
                function (data) {
                    $("#customerListContainer").html(data);
                },
            );
        }
    };
}();

$(document).ready(function () {
    CustomerPartial.Init();
});