define(function() {
    var Validator = (function() {
        function isUsernameCorrect(username) {
            var isValidUsername = username && typeof username == 'string' &&
                                  username.length >= 6 && username.length <= 40;
            return isValidUsername;
        }

        return {
            isUsernameCorrect: isUsernameCorrect
        }
    }());

    return Validator;
});