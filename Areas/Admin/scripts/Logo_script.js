

$("#FormCreateLogo").submit(function (model) {
    model.preventDefault();
    if ($(this).valid()) {
        $.ajax({
            $.ajax({
                url: "/Admin/logo/Create",
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

function deletee(id) {

    $.ajax({
        url: "/admin/logo/delete/" + id,
        type: "Get",
    }).done(function () {

        $("#item" + id).hide(2000);

    });



}