function filterProvider() {
    $("#filterProviderModal").modal('toggle');
    $("#cpfCnpj").mask("99.999.999/9999-99");

    $('#filterProviderModal :radio[name=PersonType]').on("change", function () {
        $("#cpfCnpj").val("");

        if ($(this).val() == "Physical") {
            $("#cpfCnpj").mask("999.999.999-99");
        }
        else {
            $("#cpfCnpj").mask("99.999.999/9999-99");
        }
    });
}

function createProvider() {
    $("#providerModal").modal('toggle');

    $.get("Home/CreateProvider", function (view) {
        loadProviderForm(view);
    });
}

function loadProviderForm(view) {
    $("#providerModalContent").html(view);

    $('#rg').mask('99.999.999-9');
    $("#cpfCnpj").mask("99.999.999/9999-99");

    $('#providerModal :radio[name=PersonType]').on("change", function () {
        $("#cpfCnpj").val("");

        if ($(this).val() == "Physical") {
            $("#physicalPersonInformation").removeClass("hidden");
            $("#cpfCnpj").mask("999.999.999-99");
        }
        else {
            $("#rg").val("");
            $("#physicalPersonInformation").addClass("hidden");
            $("#cpfCnpj").mask("99.999.999/9999-99");
        }
    });

    $("#saveProviderButton").on("click", function (e) {
        $.post("Home/SaveProvider", $('#providerForm').serialize(), function (view) {

            $.notify("Salvo com sucesso.", "success");

            $('#providerModal').modal('toggle');

        }).fail(function (xhr) {
            $.notify(xhr.responseJSON.message);
        });
    });
}

function deleteProvider(id) {
    deleteData("Home/Delete", id);
}

function editProvider(id) {
    $("#providerModal").modal('toggle');

    $.get("Home/EditProvider", { id: id }, function (view) {
        loadProviderForm(view);
    });
}

function deletePhone(obj, id) {
    var phoneItem = $(obj).parent().parent();

    if (id)
    {
        phoneItem.find(".to-delete").val(true);
        phoneItem.addClass("hidden");
    }
    else if ($(".phone-item").length > 1) {
        phoneItem.remove();
    }

    $("#contactList").find(".fa-trash-alt").removeClass("hidden");
    $("#contactList").find(".fa-trash-alt").last().addClass("hidden");
    $("#contactList").find(".fa-plus-circle").addClass("hidden");
    $("#contactList").find(".fa-plus-circle").last().removeClass("hidden");
}

function newContact() {
    $("#contactList").find(".fa-trash-alt").removeClass("hidden");

    var index = $(".phone-item").length;

    var newContact = $('<div class="inline-item phone-item"></div>');

    newContact.append($('<input type="text" name="Contacts[' + index + '].PhoneNumber"/>'));

    newContact.append($('<div><i class="fas fa-trash-alt hidden" onclick="deletePhone(this)"></i></div>'));
    newContact.append($('<div><i class="fas fa-plus-circle" onclick="newContact()"></i></div>'));

    $("#contactList").append(newContact);

    $("#contactList").find(".fa-plus-circle").addClass("hidden");
    $("#contactList").find(".fa-plus-circle").last().removeClass("hidden");
}

