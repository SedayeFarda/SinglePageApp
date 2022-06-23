
function ShowImagePreview(imageUploader, previewImage)
{
  
    if (imageUploader.files && imageUploader.files[0])
    {
        var reader = new FileReader();
        reader.onload = function (e) {
            
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}
function del(id) {

    $.get("/admin/products/delete/" + id, function () {

        if (confirm("آیا از حذف مطمعنید؟")) {

            $("#item" + id).hide("slow");
        }


    });


}

$(document).on("submit","#FormEditProduct",function (event) {
    alert(2525);
    event.preventDefault();
    if ($(this).valid()) {

        $.ajax({
            url: "/admin/products/Edit/",
            type: "Post",
            data: new FormData(this),
            contentType: false,
            processData: false,
        }).done(function (res) {

            $("#list_data").html(res);
        });
    }
    else {

        return false;
    }

});


$(document).on("submit", "#FormCreateProduct",function (event) {
    event.preventDefault();
    if ($(this).valid()) {
        $.ajax({
            url: "/admin/products/Create/",
            type: "Post",
            data: new FormData(this),
            contentType: false,
            processData: false,
        }).done(function (res) {
           
            $("#list_data").html(res);

        });

    }
    else {
        return false;
    }

});










function edite(id) {
    alert(2);
    $.ajax({
        url: "/admin/products/Edit/" + id,
        type: "Get",


    }).done(function (res) {
        $("#add_data").html(res);



    });

}