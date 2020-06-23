$('.user-srch').keypress(function (e) {
    let text_value = $('.user-srch').val();
    let SearchModel = {
        SearchValue: text_value
    };

    if (e.keyCode == 13) {
        $.ajax({
            url: '/Researches/PostResearchSearch',
            type: 'POST',
            data: SearchModel,
            success: function (response) {
                window.location.href = response.redirectToUrl;
            }
        });
    }
});
$('.admin-srch').keypress(function (e) {
    let text_value = $('.admin-srch').val();
    if (e.keyCode == 13) {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: '/Admin/PostResearchSearch',
            data: {
                val: text_value
            }
        });
    }
});