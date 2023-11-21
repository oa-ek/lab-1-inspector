var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/customer/employment/getallorg' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'description', "width": "30%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/customer/employment/apply?Orgid=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Apply</a>
                    </div>`;
                },

                "width": "10%"
            }
        ]
    });
}
