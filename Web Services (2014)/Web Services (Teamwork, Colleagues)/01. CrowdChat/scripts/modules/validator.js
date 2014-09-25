define(function () {
	function checkUsername(username) {
		if (typeof username === 'string' && 4 <= username.length && username.length <= 10) {
			return true;
		}

		return false;
	}

	function checkMessage(message) {
		if (typeof message === 'string' && 0 < message.length && message.length <= 50) {
			return true;
		}

		return false;
	}

	return {
		checkUsername: checkUsername,
		checkMessage: checkMessage
	};
});