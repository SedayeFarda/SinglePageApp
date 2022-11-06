
    
 

$("#FormCreateGallery").submit(function (event) {
    event.preventDefault();
    if ($(this).valid())
    {


        $.ajax({
            url: "/admin/Gallery/Create",
            type: "Post",
            data: new FormData(this),
            contentType: false,
            processData: false,

            success: function (res) {
                
                $("#Gallery").html(res);

            }

        });
    }
    else {
        return false;
    }
    
});


    $("#FormEditGallery").submit(function (event) {

        event.preventDefault();
        if ($(this).valid()) {
            $.ajax({
                url: "/Admin/Gallery/Edit",
                type: "Post",
                data: new FormData(this),
                contentType: false,
                processData: false,
                success: function (res) {
                   
                    $("#Gallery").html(res);

                }



            });
        }
        else {
            return false;
        }
    });

function delet(id) {

    if (confirm("آیا از حذف مطمعنید؟"))
    {
        $.ajax({

            url: "/admin/Gallery/delete/" + id,
            type:"Get",

        }).done(function () {

            $("#item" + id).fadeOut(1000);

        });

    }
}


function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}


function edit(id) {

    $.ajax({
        url: "/admin/Gallery/Edit/" + id,
        type: "Get",

    }).done(function (res) {

        $("#div_form").html(res);


    });



}

