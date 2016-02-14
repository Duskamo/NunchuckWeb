$(document).ready(function () {
    $('.fun').mouseover(function () {
        $(this).animate({
            height: "+=10"
        }, 200);
    });

    $('.fun').mouseleave(function () {
        $(this).animate({
            height: "-=10"
        }, 200);
    });
});