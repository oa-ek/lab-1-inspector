var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/employee/complaint/getall' },
        "columns": [
            { data: 'user.fullName', "width": "20%" },
            { data: 'organization.name', "width": "15%" },
            { data: 'description', "width": "10%" },
            { data: 'status', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/employee/responce/create?ComplaintId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Report</a>
                     <a href="/employee/complaint/info?ComplaintId=${data}" class="btn btn-info mx-2"><i class="bi bi-file-earmark-zip"></i> Info</a>
                    </div>`;
                },

                "width": "30%"
            }
        ]
    });
}

function Delete(url) {
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