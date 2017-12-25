AddCustomerPage = function () {
    return {
        OnBegin: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.ShowLoader($submit);

        },

        OnSuccess: function (data) {
            if (data.Success) {
                alert("customer added!");
            }
        },

        OnComplete: function () {
            var $submit = $(this).find("input[type='submit']");

            FormHelper.HideLoader($submit);
        }
    };
}();