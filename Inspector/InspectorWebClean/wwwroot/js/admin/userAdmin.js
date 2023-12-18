var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/complaint/getalluser' },
        "columns": [
            { data: 'fullName', "width": "20%" },
            { data: 'email', "width": "30%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'organization.name', "width": "40%" }
        ]
    });
}