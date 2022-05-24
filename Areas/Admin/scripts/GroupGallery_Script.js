function edit(id) {
    $.ajax({

        url: "/admin/GroupGallery/Edit/" + id,
        type: "Get",
    }).done(function (response) {
        $(".modal").show();
        $(".modal-title").html("ویرایش");
        $(".modal-body").html(response);


    });



}

function create() {
    $.ajax({

        url: "/admin/GroupGallery/Create",
        type: "Get"
    }).done(function (response) {

        $(".modal").show();
        $(".modal-title").html("ایجاد");
        $(".modal-body").html(response);

    })



}
function close_modal() {

    $(".modal").fadeOut(1000);
}

function sucssess() {

    $(".modal").fadeOut(1000);
}