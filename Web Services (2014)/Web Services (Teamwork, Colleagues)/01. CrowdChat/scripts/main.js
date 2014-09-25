define(function () {
	require.config({
		paths: {
			'jquery': 'libs/jquery',
			'sammy': 'libs/sammy',
			'sammy.handlebars': 'libs/sammy.handlebars',
			'handlebars': 'libs/handlebars',
			'requester': 'modules/requester',
			'validator': 'modules/validator',
			'eventBinder': 'modules/binder'
		},
		shim: {
			'handlebars': {
				exports: 'Handlebars'
			}
		}
	});

	require(['jquery', 'sammy', 'handlebars', 'requester', 'eventBinder', 'sammy.handlebars'], function ($, Sammy, Handlebars, Requester, Bind) {

		var app = Sammy('#wrapper', function () {
			this.use('Handlebars', 'hb');

			this.get('#/', function () {
				var username = localStorage.getItem('CrowdChatUsername');
				if (username) {
					this.redirect('#/chat');
				} else {
					this.redirect('#/login');
				}
			});

			this.get('#/login', function () {
				var _this = this,
					username = localStorage.getItem('CrowdChatUsername');

				if (username) {
					this.redirect('#/chat');
				}

				this.partial('templates/login.hb', function () {
					Bind.login(_this, '#/chat');
				});


			});

			this.get('#/chat', function () {
				var _this = this,
					username = localStorage.getItem('CrowdChatUsername');

				if (!username) {
					this.redirect('#/login');
				}

				$.when(Requester.getMessages(20))
					.then(function (data) {
						_this.partial('templates/chat-header.hb', {username: username, posts: data}, function () {
							Bind.logout(_this, '#/login');
							Bind.sendMessage();

							setInterval(function () {
								$.when(Requester.getMessages(20))
									.then(function (data) {
										_this.render('templates/chat-body.hb', {posts: data}).replace($('#chat-body'));
									});
							}, 1000);
						});
					});
			});
		});

		$(function () {
			app.run('#/');
		});

	});
});