/// <reference path="../../main/constants.js" />
AjaxJsonResponseHandler = function () {
    return {
        HandleAjaxResult: function (response, handler) {
            if (response.JsonResultType === Constants.JsonResultType.JsonRedirectResult) {
                window.location = response.RedirectUrl;
            }
            else if (response.JsonResultType === Constants.JsonResultType.JsonResultWithView) {
                if (typeof handler === "function") {
                    handler(response.ViewResult);
                }
            }
        }
    };
}();