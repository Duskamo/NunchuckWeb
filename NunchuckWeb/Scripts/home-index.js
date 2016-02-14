$(document).ready(function () {
    $('li:first-child()').click(function () {
        var currentDot = $('.pagination .active');
        var prevDot = currentDot.prev();

        var currentSlide = $('.active-slide');
        var prevSlide = currentSlide.prev();

        if (prevDot.prev().length === 0) {
            prevDot = $('.pagination li:nth-child(5)');
            //prevSlide = $('');
        }

        currentDot.removeClass('active');
        prevDot.addClass('active');

        currentSlide.removeClass('active-slide');
        prevSlide.addClass('active-slide');
    });

    $('li:last-child()').click(function () {
        var currentDot = $('.pagination .active');
        var nextDot = currentDot.next();

        var currentSlide = $('.active-slide');
        var nextSlide = currentSlide.next();

        if (nextDot.next().length === 0) {
            nextDot = $('.pagination li:nth-child(2)');
            //nextSlide = $('');
        }

        currentDot.removeClass('active');
        nextDot.addClass('active');

        currentSlide.removeClass('active-slide');
        nextSlide.addClass('active-slide');
    });
});