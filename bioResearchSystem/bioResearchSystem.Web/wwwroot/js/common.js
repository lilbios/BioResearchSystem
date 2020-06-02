function push() {
    $('.ghost').click();
}

function upload(input) {
    if (input.files[0]) {
        let type = input.files[0].type;
        if (type == "image/png" || type == "image/jpeg") {
            url(input);
            window.localStorage.setItem('picture', JSON.stringify(input));
        } else {
            $('.error-box').append('<small>We supprot only PNG and JPEG formats</small>');
        }
    }
}

function url(input) {
    let fileReader = new FileReader();
    fileReader.onload = function (displayImg) {
        $("#image").attr("src", displayImg.target.result)
    }
    fileReader.readAsDataURL(input.files[0])

}

function saveToLocalStorage(value) {
    window.localStorage.setItem('id', JSON.stringify(value));
}

