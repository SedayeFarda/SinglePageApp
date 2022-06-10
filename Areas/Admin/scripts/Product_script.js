
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
function edite_post() {
    alert(2224)
    var data1 = $("#FormEditProduct");
    console.log(data1.valid());
    if ($(data1).valid()) {
        
        $.ajax({
            url: "/admin/products/Edit/",
            type: "Post",
            data: data1.serialize(),
          
        }).done(function (res) {

            $("#list_data").html(res);
        });
    }
    else {

        return false;
    }
   

}

$("#FormEditProduct").submit(function (event) {
    alert(2);
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


$("#FormCreateProduct").submit(function (event) {
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
    $.ajax({
        url: "/admin/products/Edit/" + id,
        type: "Get",


    }).done(function (res) {
        $("#add_data").html(res);



    });

}