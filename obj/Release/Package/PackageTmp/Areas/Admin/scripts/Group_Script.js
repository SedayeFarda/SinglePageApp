function Create(id) {
    $.get("/admin/Groups/Create/"+id, function (res) {
        $(".modal").show();
        $(".modal-title").html("ایجاد  سر گروه");
        $(".modal-body").html(res);


    });



};

function edite(id) {
    $.get("/admin/Groups/Edit/" + id, function (res) {

        $(".modal").show();
        $(".modal-title").html("ویرایش زیر گروه");
        $(".modal-body").html(res);


    });



};
function delet(id) {

    $.get("/admin/Groups/delete/" + id, function () {
        
            $("#item" + id).hide("slow");
       


    });

}
function delet2(id) {

    $.get("/admin/Groups/delete/" + id, function () {

        $("#item_tr" + id).hide("slow");



    });

}