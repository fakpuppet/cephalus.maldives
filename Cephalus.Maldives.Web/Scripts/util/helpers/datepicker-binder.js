DatePickerBinder = function () {
    return {
        Init: function () {
            $('.datepicker').datepicker({
                format: "mm.dd.yyyy.",
                startView: 1,
                autoclose: true,
                todayHighlight: true,
                toggleActive: true,
                defaultViewDate: { year: 1977, month: 04, day: 25 }
            });
        },
    };
}();