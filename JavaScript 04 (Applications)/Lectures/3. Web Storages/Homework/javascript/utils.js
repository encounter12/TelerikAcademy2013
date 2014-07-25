define(["jquery"], function ($) {
    var Utils;
    
    Utils = (function() {
        function validateInput(inputField, container, button, digits) {
            var intRegex = /^[0-9]{4}$/;
            var input = $(inputField).val();
            if(!(intRegex.test(input) && input.length === digits)) {
                return false;
            }
            else {
                return true;
            }
        }
        function displayInputError(container) {
                var $message = $("<span></span>").html("Input is incorrect. Please, re-enter");
                $message.css({
                    "color": "red",
                    "font-size": "14px"
                });
                $(container).append($message);
        }
        return {
            "validateInput": validateInput,
            "displayInputError": displayInputError
        };
    })();

    return Utils;
});