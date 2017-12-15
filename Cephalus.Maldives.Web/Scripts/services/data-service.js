DataService = function () {
    return {
        MakeAjaxCall: function (data, method, endpoint, onSuccess, onError, onComplete) {
            $.ajax(endpoint, {
                data: data,
                cache: false,
                method: method || "GET",
                success: onSuccess,
                error: onError,
                complete: onComplete
            });
        }
    };
}();