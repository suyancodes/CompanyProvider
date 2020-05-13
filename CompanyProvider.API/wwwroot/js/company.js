function deleteCompany(id) {
    deleteData("Company/Delete", id);
}

function createCompany() {
    $("#companyModal").modal('toggle');

    $.get("Company/CreateCompany", function (view) {
        loadCompanyForm(view);
    });
}

function editCompany(id) {
    $("#companyModal").modal('toggle');

    $.get("Company/EditCompany", { id: id }, function (view) {
        loadCompanyForm(view);
    });
}

function loadCompanyForm(view) {
    $("#companyModalContent").html(view);

    $("#companyCnpj").mask("99.999.999/9999-99");

    $("#saveCompanyButton").on("click", function (e) {
        $.post("Company/SaveCompany", $('#companyForm').serialize(), function (view) {

            $.notify("Salvo com sucesso.", "success");

            $('#companyModal').modal('toggle');

        }).fail(function (xhr) {
            $.notify(xhr.responseJSON.message);
        });
    });
}
