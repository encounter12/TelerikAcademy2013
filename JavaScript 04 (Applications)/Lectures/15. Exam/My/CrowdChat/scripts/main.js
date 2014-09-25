define(function() {
    require.config({
        paths: {
            'jquery': 'vendor/jquery-2.1.1',
            'sammy': 'vendor/sammy',
            'q': 'vendor/q.min',
            'cryptojs.core': "vendor/cryptojs/core",
            'cryptojs.sha1': "vendor/cryptojs/sha1",
            'mustache': 'vendor/mustache',
            'http-requester': 'http-requester',
            'validation-controller': 'validation-controller',
            'ui': 'ui-controller',
            'controller': 'controller'
        }
        ,
        shim: {
            'cryptojs.core': {
                exports: "CryptoJS"
            },
            'cryptojs.sha1': {
                deps: ['cryptojs.core'],
                exports: "CryptoJS"
            }
        }
    });

    require(['jquery', 'sammy', 'controller'], function($, Sammy, Controller) {
        var appController = new Controller('http://localhost:3000');
        appController.setEventHandler();

        var app = Sammy('#wrapper', function() {

            this.get("#/auth", function() {
                if (appController.isLoggedIn()) {
                    window.location = '#/posts';
                }
                appController.loadLoginForm();
            });

            this.get("#/posts", function() {

                //appController.showPosts();
                if (appController.isLoggedIn()) {
                    //appController.displayPostForm();
                }
            });
        });

        app.run('#/auth');
    });
});