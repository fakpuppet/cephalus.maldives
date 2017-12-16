/// <reference path="../services/data-service.js" />
CustomerPartial = function () {
    return {
        Init: function () {
            $(document).on("click", "#refreshCustomerView", function () {
                var tagTypes = $("#tagType").val();

                CustomerPartial.GetCustomersByTagType(tagTypes);
            });
        },

        GetCustomersByTagType: function (tagTypes) {
            DataService.MakeAjaxCall(
                { tagTypes: tagTypes },
                "POST",
                "/Home/GetCustomersByTagType",
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