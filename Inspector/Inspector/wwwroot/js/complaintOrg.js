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
                    if (status === 'in process') {
                        return `<div class="w-75 btn-group" role="group">
                <a href="/organization/responce/create?ComplaintId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Responce</a>
                <a href="/organization/responce/ToArchive?ComplaintId=${data}" class="btn btn-warning mx-2"><i class="bi bi-file-earmark-zip"></i> Archive</a>
                <a href="#" class="btn btn-info mx-2" disabled><i class="bi bi-forward"></i> Give To</a>
            </div>`;
                    } else {
                        return `<div class="w-75 btn-group" role="group">
                <a href="/organization/responce/create?ComplaintId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Responce</a>
                <a href="/organization/responce/ToArchive?ComplaintId=${data}" class="btn btn-warning mx-2"><i class="bi bi-file-earmark-zip"></i> Archive</a>
                <a href="/organization/assignment/create?ComplaintId=${data}" class="btn btn-info mx-2"><i class="bi bi-forward"></i> Give To</a>
            </div>`;
                    }
                },
                "width": "45%"
            }
        ]
    });
}

function Arcgive(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toolbar.success(data.message);
                }

            })
        }
    })
}