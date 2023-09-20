$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/complaint/getall' },
        "columns": [
            { data: 'userName', "width": "25%" },
            { data: 'organization.name', "width": "15%" },
            { data: 'description', "width": "10%" },
            { data: 'status', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/complaint/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                    <a onClick=Delete('/admin/complaint/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash3"></i> Delete</a>
                    </div>`;
                },

                "width": "30%"
            }
        ]
    });
}