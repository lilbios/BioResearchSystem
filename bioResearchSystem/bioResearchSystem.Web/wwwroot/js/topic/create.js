function post() {

    let formData = new FormData();
    let file = document.getElementById("photoholder");
    let photo = file.files[0];
    let value = $(".form-input").val();

    formData.append("Title ",value);
    formData("Image", photo);

    $.ajax({
        type: "Post",
        url: "/Admin/CreateNewTopic",
        data: formData,
        contentType: false,
        processData: false
    });

}

