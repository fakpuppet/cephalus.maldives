/// <reference path="../services/data-service.js" />
/// <reference path="../util/helpers/form-helper.js" />
CustomersPage = function () {
    return {
        Init: function () {

        },

        OnBegin: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.ShowLoader($submit);
        },

        OnSuccess: function (data) {
            $("#customerListContainer").html(data);
        },

        OnComplete: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.HideLoader($submit);
        }
    };
}();

$(document).ready(function () {
    CustomersPage.Init();
});