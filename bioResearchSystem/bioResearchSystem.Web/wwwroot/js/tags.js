$('.reciever').keypress(function (e) {
    if (e.keyCode == 32) {

        let tagValue = $('.reciever').val().trim();
        let tagContainer = $(".tag-container");
        let content = $('.tg-holder').val().split(',').filter(value => value);

        if (tagValue) {
            tagValue = "#" + tagValue;
            if (content.length < 5) {
                $("#msg").remove();

                if (!content.includes(tagValue)) {

                    content.push(tagValue);

                    tagContainer.append('<h5 class="badge badge-pill badge-warning" style="margin-left: 5px">' + tagValue + '</h5>');
                    $('.tg-holder').val(content.join(','));
                    $(".reciever").val(null);
                } else {

                    if ($("#msg").length == 0) {
                        $('.errors').append('<div id="msg">Tag with this name already exsists!</div>');
                    }
                }
            } else {
                if ($("#msg").length == 0) {
                    $('.errors').append('<div id="msg">You cannot add more than 5 tags</div>');
                }
            }
        }
    }
});



$(document).click(function (event) {

    if ($(event.target).attr("class") == 'badge badge-pill badge-warning') {
        let content = $('.tg-holder').val().split(',').filter(value => value);

        for (let i = 0; i < content.length; i++) {

            if ($(event.target).text() == content[i]) {
                $("#msg").remove();

                content.splice(i, 1);
                $('.tg-holder').val(content.join(','));
                $(event.target).remove();
            }
        }

    }
});
