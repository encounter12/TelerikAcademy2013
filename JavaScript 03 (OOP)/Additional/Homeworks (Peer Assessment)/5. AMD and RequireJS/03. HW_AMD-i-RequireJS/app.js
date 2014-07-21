(function () {
    require.config({
        paths: {
            "jquery": "ExternalLibs/jquery-2.1.1",
            "controls" : "ProjectScripts/controls",
            "handlebars" : "ExternalLibs/handlebars"
        }
    });
    
    require(["jquery", "ProjectScripts/controls"], function ($, controls) {
        var people = [
            { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "http://academy.telerik.com/images/lecturers/doncho.jpg?sfvrsn=0" },
            { id: 2, name: "Niki Kostov", age: 19, avatarUrl: "http://academy.telerik.com/images/default-album/niki.jpg?sfvrsn=0" },
            { id: 2, name: "Kiro Spirov", age: 45, avatarUrl: "http://blogs.telerik.com/images/default-source/miroslav-miroslav/super_ninja.png?sfvrsn=2" },
            { id: 2, name: "Tosho Kolev", age: 46, avatarUrl: "http://blogs.telerik.com/images/default-source/miroslav-miroslav/super_ninja.png?sfvrsn=2" },
            { id: 2, name: "Marin Drinov", age: 23, avatarUrl: "http://blogs.telerik.com/images/default-source/miroslav-miroslav/super_ninja.png?sfvrsn=2" }];

        var comboBox = controls.comboBox(people);

        var template = $("#people-template").html();

        var outputHtml = comboBox.render(template);

        var $container = $("#container");
        $container.html(outputHtml);
    });    
}());