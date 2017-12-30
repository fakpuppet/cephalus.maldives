/// <reference path="../util/helpers/ajax-json-response-handler.js" />
/// <reference path="../util/helpers/form-helper.js" />
AddCustomerPage = function () {
    return {
        OnBegin: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.ShowLoader($submit);
        },

        OnSuccess: function (data) {
            AjaxJsonResponseHandler.HandleAjaxResult(data, null);
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