/// <reference path="../util/helpers/ajax-json-response-handler.js" />
/// <reference path="../util/helpers/form-helper.js" />
EditCustomerPage = function () {
    return {
        OnBegin: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.ShowLoader($submit);
        },

        OnSuccess: function (data) {
            AjaxJsonResponseHandler.HandleAjaxResult(data, function (data) {
                $("#editCustomerFormContainer").html(data.ViewResult);
            });
        },

        OnComplete: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.HideLoader($submit);
        },

        OnFailure: function (e) {
            console.log(e);
        }
    };
}();