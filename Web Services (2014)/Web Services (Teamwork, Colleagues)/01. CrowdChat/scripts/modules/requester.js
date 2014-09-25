define(['jquery'], function ($) {
	function getMessages(numberOfMessages) {
		var deferred = $.Deferred();

		$.ajax({
			url: 'http://crowd-chat.herokuapp.com/posts',
			type: 'GET',
			success: function (data) {
				deferred.resolve(data.slice(data.length - numberOfMessages, data.length).reverse());
			}
		});

		return deferred.promise();
	}

	function postMessage(data) {
		$.ajax({
			url: 'http://crowd-chat.herokuapp.com/posts',
			type: 'POST',
			data: {
				user: data.user,
				text: data.text
			}
		});
	}

	return {
		getMessages: getMessages,
		postMessage: postMessage
	};
});