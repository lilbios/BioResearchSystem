function remove() {

    let data = JSON.parse(window.localStorage.getItem('id'));
    $.ajax({
        cache: false,
        type: "Post",
        url: "/Admin/RemoveUser",
        dataType:'json',
        data: {
            id: data
        },
        success: function (data, status, xhr) {
            location.reload();
        },
        error: function (jqXhr, textStatus, errorMessage) { 

            $('.error-box').append('Something went wrong :(' + errorMessage);
        }
    });
}