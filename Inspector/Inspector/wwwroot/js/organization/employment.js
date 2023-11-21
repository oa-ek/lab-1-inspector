var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/organization/employment/GetAllEmployments' },
        "columns": [
            { data: 'user.fullName', "width": "20%" },
            { data: 'user.email', "width": "30%" },
            {
                data: 'userId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/organization/employment/accept?userId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Accept</a>
                    </div>`;
                },

                "width": "10%"
            }
        ]
    });
}
