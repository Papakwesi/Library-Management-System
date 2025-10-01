$(document).ready(function () {
    $('#datatables').DataTable({
        responsive: true,
        dom: 'Bfrtip', // B = buttons, f = search, r = processing, t = table, i = info, p = paging
        buttons: [
            {
                extend: 'copy',
                className: 'btn btn-sm btn-outline-secondary'
            },
            {
                extend: 'csv',
                className: 'btn btn-sm btn-outline-secondary'
            },
            {
                extend: 'excel',
                className: 'btn btn-sm btn-outline-success'
            },
            {
                extend: 'pdf',
                className: 'btn btn-sm btn-outline-danger'
            },
            {
                extend: 'print',
                className: 'btn btn-sm btn-outline-primary'
            },
            {
                extend: 'colvis',
                className: 'btn btn-sm btn-outline-dark'
            }
        ]
    });
});
