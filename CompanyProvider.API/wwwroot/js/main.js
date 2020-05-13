$(document).ready(function () {
    $('.modal.reload').on('hidden.bs.modal', function () {
        location.reload();
    });
});

function deleteData(url, id) {

    $('#deleteModal').modal('toggle');

    $('#confirmDeleteButton').on('click', function () {
        $.post(url, { id: id }, function (view) {

            $.notify("Excluído com sucesso.", "success");

            $('#deleteModal').modal('toggle');

        }).fail(function (xhr) {
            $.notify(xhr.responseJSON.message);
        });
    });
}