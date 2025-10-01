toastr.options = {
    "closeButton": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "timeOut": "3000"
};


$(function () {
    var success = $("#toastr-success").val();
    var error = $("#toastr-error").val();
    var info = $("#toastr-info").val();
    var warning = $("#toastr-warning").val();

    if (success) toastr.success(success);
    if (error) toastr.error(error);
    if (info) toastr.info(info);
    if (warning) toastr.warning(warning);
});
