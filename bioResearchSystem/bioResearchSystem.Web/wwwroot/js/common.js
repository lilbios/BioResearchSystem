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

function find_user() {

    let searchValue = $("search-field").val();
    $.ajax({
        type: "post",
        dataType: "json",
        url: "/Research/SearchUser",
        data: {
            value: searchValue
        }
    })
}
function find_research() {
    let value = $(".search-field-research").val();
    $.ajax({
        type: "post",
        dataType: "json",
        url: "/Research/SearchResult",
        data: {
            searchValue: value
        }
    })
}
