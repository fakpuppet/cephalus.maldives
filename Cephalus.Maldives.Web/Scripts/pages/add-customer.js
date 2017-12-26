AddCustomerPage = function () {
    return {
        OnBegin: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.ShowLoader($submit);
        },

        OnSuccess: function (data) {
            if (data.ResultType = "JsonRedirectResult") {
                alert("customer added!");
            }
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