var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/complaint/getalluser' },
        "columns": [
            { data: 'fullName', "width": "20%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'organization.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                    <a class="btn btn-danger mx-2"><i class="bi bi-trash3"></i> Delete</a>
                    </div>`;
                },

                "width": "30%"
            }
        ]
    });
}