define(['jquery', 'sammy', 'validator', 'requester'], function ($, Sammy, Validator, Requester) {
	function bindLogin(page, redirectingURL) {

		var $loginButton = $('#login-button');

		$loginButton.off('click');
		$loginButton.on('click', function () {
			var username = $('#username').val();

			if (Validator.checkUsername(username)) {
				localStorage.setItem('CrowdChatUsername', username);
				page.redirect(redirectingURL);
			} else {
				alert('Invalid username');
			}
		});
	}

	function logout(page, redirectingURL) {
		var $logoutButton = $('#logout-button');
		$logoutButton.off('click');
		$logoutButton.on('click', function () {
			localStorage.removeItem('CrowdChatUsername');
			page.redirect(redirectingURL);
		});
	}

	function sendMessage() {
		var $sendButton = $('#send-button');

		$sendButton.on('click', function () {
			var username = localStorage.getItem('CrowdChatUsername'),
				$messageBox = $('#message'),
				message = $messageBox.val(),
				data = {user: username, text: message};

			if (Validator.checkMessage(message)) {
				Requester.postMessage(data);
				$messageBox.val(' ');
			} else {
				alert('Invalid message');
			}
		});
	}

	return {
		login: bindLogin,
		logout: logout,
		sendMessage: sendMessage
	};
});