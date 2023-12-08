var dataTable;

$(document).ready(function () {
    loadDataTable();

    $('#newFileInput').change(function () {
        updateSelectedFilesList(this); // Call the function to update selected files list
        loadDataTable();
    });
});

function updateSelectedFilesList(input) {
    var selectedFilesList = $('#selectedFilesList');
    selectedFilesList.empty();

    for (var i = 0; i < input.files.length; i++) {
        var fileName = input.files[i].name;
        selectedFilesList.append('<li>' + fileName + '</li>');
    }
}

function loadDataTable() {
    var complaintId = window.complaintId;

    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/customer/complaint/GetAllFiles',
            data: { complaintID: complaintId },
        },
        "destroy": true, 
        "columns": [
            {
                data: 'filePath',
                "render": function (data) {
                    var fileName = data.substring(data.lastIndexOf('/') + 1);

                    return `<div class="mb-3 row p-1">
                    <label class="p-0"><a href="${data}" target="_blank">${fileName}</a></label>
                </div>`;
                },
                "width": "35%"
            },
            {
                data: 'createDate',
                "render": function (data) {
                    return `<div>${formatDate(data)}</div>`;
                },
                "width": "20%"
            },
            {
                data: 'fileName',
                "render": function (data) {
                    var fileExtension = data.split('.').pop().toLowerCase();
                    return `<div>${fileExtension}</div>`;
                },
                "width": "5%"
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/customer/complaint/removefile?id=${data}" class="btn btn-danger mx-2"><i class="bi bi-trash"></i></a>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}

function formatDate(dateString) {
    var options = { year: 'numeric', month: 'short', day: 'numeric' };
    return new Date(dateString).toLocaleDateString(undefined, options);
}
