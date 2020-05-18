function push() {
    $('.ghost').click();
}

function upload(input) {
    if (input.files[0]) {
        let reader = new FileReader();
        let type = input.files[0].type;
        if (type == "image/png" || type == "image/jpeg") {
            reader.onload = function (displayImg) {
                $(".card-img-top").attr("src", displayImg.target.result)
            }
            reader.readAsDataURL(input.files[0])
        } else {
            $('.error-box').append('<small>We supprot only PNG and JPEG formats</small>');
        }
    }
}