(function ($) {
  $.fn.messageBox = function () {
    $this = $(this); 
  };

  $.fn.messageBox.success = function(text) {
    displayMessage(text);
    return this; 
  };

  $.fn.messageBox.error = function(text) {
    displayMessage(text);
    return this;
  };

  function displayMessage(text) {
    $this.html(text);
    $this.fadeIn('1000', function() {
      $this.fadeOut('3000');
    });
  }
}(jQuery));