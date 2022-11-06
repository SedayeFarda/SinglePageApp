function Create(id) {
    $.get("/admin/PropertyProducts/Create/" + id, function (res) {

        $(".modal").show();
        $(".modal-title").html("ایجاد");
        $(".modal-body").html(res);



    });

}

function edit(id) {


    $.get("/admin/PropertyProducts/Edit/" + id, function (res) {

        $(".modal").show();
        $(".modal-title").html("ویرایش");
        $(".modal-body").html(res);



    });


}

function delet(id) {

    $.get("/admin/propertyproducts/delete/" + id, function () {

        $("#item" + id).hide("slow");


    });


}