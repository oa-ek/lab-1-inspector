var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/organization/complaint/getallorg' },
        "columns": [
            { data: 'user.fullName', "width": "20%" },
            { data: 'organization.name', "width": "15%" },
            { data: 'description', "width": "10%" },
            { data: 'status', "width": "10%" },
            {
                data: 'id',
                "render": function (data, type, row) {
                    const status = row.status.toLowerCase();
                    const orgid = row.organization.id;
                    const usertakeid = row.user.id;
                    if (status === 'done') {
                        return `<div class="w-75 btn-group" role="group">
                        <a href="/organization/response/create?ComplaintId=${data}&OrganizationId=${orgid}&UserTakeId=${usertakeid}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Responce</a>
                        <a href="/organization/response/ToArchive?ComplaintId=${data}" class="btn btn-warning mx-2"><i class="bi bi-file-earmark-zip"></i> Archive</a>
                        <a href="#" onclick="ComplaintFulfilled()" class="btn btn-info mx-2" style="opacity: 0.6"><i class="bi bi-forward"></i> Give To</a>

                         </div>`; 
                    } else {
                        return `<div class="w-75 btn-group" role="group">
                        <a href="/organization/response/create?ComplaintId=${data}&OrganizationId=${orgid}&UserTakeId=${usertakeid}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Responce</a>
                        <a href="/organization/response/ToArchive?ComplaintId=${data}" class="btn btn-warning mx-2"><i class="bi bi-file-earmark-zip"></i> Archive</a>
                        <a href="/organization/assignment/create?ComplaintId=${data}" class="btn btn-info mx-2"><i class="bi bi-forward"></i> Give To</a>
                    </div>`;
                    }
                },
                "width": "45%"
            }
        ]
    });
}


    function ComplaintFulfilled() {
        Swal.fire('The complaint has already been fulfilled!');
}