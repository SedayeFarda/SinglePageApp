$("#FormCreateLogo").submit(function (event) {
    event.preventDefault();
    if ($(this).valid()) {
        
            $.ajax({
                url: "/Admin/logo/_Create",
                type: "Post",
                data: new FormData(this),
                contentType: false,
                processData: false
            }).done(function (res) {

                $("#div_list").html(res);

            });
    }
    else {
                return false;
            }
});
function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

$(document).on("click", "#edit", function () {



  $.ajax({
        url: "/admin/logo/Edit" + id,
        type: "Get",



    }).done(function (res) {

        $("#div_form").html(res);



    });



}) 
  
function deletee(id) {

    $.ajax({
        url: "/admin/logo/delete/" + id,
        type: "Get",
    }).done(function () {

        $("#item" + id).hide(2000);

    });



}