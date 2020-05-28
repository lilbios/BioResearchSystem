$(document).ready(function () {
    $(document).on('mouseenter', '.card-block', function () {
        $(this).find(':a').show();
    }).on('mouseleave', '.card-block', function () {
        $(this).find(':a').hide();
    });
});