(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1.min",
            "handlebars": "libs/handlebars.min",
            "generateTemplate": "./generateTemplate",
            "comboBox": "./generateComboBox"
        }
    });
    var people = [
    { id: 1, name: "NikiKostov", age: 25, avatarUrl: "images/Niki.png" },
    { id: 2, name: "Doncho Minkov", age: 25, avatarUrl: "images/Doncho.png" },
    { id: 3, name: "Ivaylo Kenov", age: 25, avatarUrl: "images/Ivaylo.jpg" },
    { id: 3, name: "Todor Stoyanov", age: 20, avatarUrl: "images/Todor.jpg" },
    { id: 4, name: "Pavel Kolev", age: 21, avatarUrl: "images/Pavel.jpg" },
    ];


    require(['generateTemplate', 'jquery', 'comboBox'], function (tempGenerator, $) {
        var generator = new tempGenerator("person-template", people);

        $("#wrapper").comboBox(generator.getDropdownDiv());
    })

}());