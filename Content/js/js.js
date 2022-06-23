var slideIndex = 1;
var pt;
var items;
slideShow(slideIndex);
// setInterval(function () {
//     slideIndex++;
//     slideShow(slideIndex);
// }, 1000)

function slideShow(n) {
    console.log('n = ' + n);
    var slides = $('.slide').toArray();
    // console.log(slides);
    if (n > slides.length) {
        slideIndex = 1;
    }
    if (n < 1) {
        slideIndex = slides.length;
    }
    console.log('slideIndex  = ' + slideIndex);
    $('.slide').css('display', 'none');
    $(slides[slideIndex - 1]).css('display', 'flex');
    progressbar(slideIndex - 1);
    return slideIndex

}

function move(n) {
    //slideIndex 1 | 2 | 3
    // next -- > n  1
    //slideIndex = 3 + 1 = 4

    //slideIndex 3 | 2 | 1
    // prev ---> n -1
    //slideIndex =  1 + -1 --> 1 - 1 = 0
    clearInterval(pt);
    items[slideIndex - 1].style.width = '0%';
    slideIndex = slideIndex + n;
    slideShow(slideIndex);

}
function progressbar(slideId) {

    items = document.getElementsByClassName('item-inner');

    var width = 0;
    pt = setInterval(frame, 10);

    function frame() {
        if (width >= 100) {
            clearInterval(pt);
            items[slideId].style.width = '0%';
            slideIndex++;
            slideIndex = slideShow(slideIndex);
        } else {
            width++;
            items[slideId].style.width = width + '%';

        }
    }


}