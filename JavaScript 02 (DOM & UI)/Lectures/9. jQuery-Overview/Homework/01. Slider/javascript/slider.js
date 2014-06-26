$(document).ready(function() {

    var images =
    [
        "cartoon.jpg", 
        "avatar-jungle.jpg", 
        "church-landscape.jpg"
    ];

    var headings =
    [
        "Alice in Wonderland", 
        "Avatar Jungle", 
        "Church Landscape"
    ];

    var pathToImages = "images/";
    var slidesBoxWidth = $("#slides-box").outerWidth();
    

    for (var i = 0; i < images.length; i++) {
        var $slide = $("<div>")
            .addClass("slides")
            .text(headings[i])
            .css({
                "background-image" : "url(" + pathToImages + images[i] + ")", 
                "background-size" : "100% 100%",
                "position" : "absolute"
            });

        $("#slides-box").append($slide);
    }

    $(".slides:first-child").css('z-index', '1');

    var currentSlideNumber = 1,
        zIndexCount = 0;

    $("#left-band").click(function() {
        
        if (currentSlideNumber === images.length) {
            
            currentSlideNumber = 0;
        }
        
        zIndexCount += 1;
        var nextSlideNumber = currentSlideNumber + 1;
        

        $(".slides:nth-child(" + nextSlideNumber + ")").css({"top": 0, "left": slidesBoxWidth, "z-index": zIndexCount});
        $(".slides:nth-child(" + nextSlideNumber + ")").show().animate({ "left": "-=" + slidesBoxWidth + "px" }, 500);

        currentSlideNumber += 1;
    });

    $("#right-band").click(function() {
        
        zIndexCount += 1;

        if (currentSlideNumber === 1) {
            currentSlideNumber = images.length + 1;
        }

        var previousSlideNumber = currentSlideNumber - 1;

        $(".slides:nth-child(" + previousSlideNumber + ")").css({"top": 0, "left": -slidesBoxWidth, "z-index": zIndexCount});
        $(".slides:nth-child(" + previousSlideNumber + ")").show().animate({ "left": "+=" + slidesBoxWidth + "px" }, 500);

        currentSlideNumber -= 1;
    });

    //auto-play
    setInterval(function() {
        $("#right-band").click()
    }, 5000);
    
});