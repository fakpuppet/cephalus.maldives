/// <reference path="../services/data-service.js" />
CustomerPartial = function () {
    return {
        Init: function () {

        },

        OnBegin: function () {

        },

        OnSuccess: function (data) {
            $("#customerListContainer").html(data);
        }
    };
}();

$(document).ready(function () {
    CustomerPartial.Init();
});