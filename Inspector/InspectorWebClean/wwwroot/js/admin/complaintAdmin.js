var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: 'complaint/getall' },
        "columns": [
            { data: 'user.fullName', "width": "20%" },
            { data: 'organization.name', "width": "30%" },
            { data: 'description', "width": "40%" },
            { data: 'status', "width": "10%" }
        ]
    });
}