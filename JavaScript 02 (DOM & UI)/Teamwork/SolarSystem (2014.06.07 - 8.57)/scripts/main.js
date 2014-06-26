/*jslint browser: true*/
/*global Kinetic*/

(function () {
    'use strict';

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1200,
        height: 720
    });

    var layer = new Kinetic.Layer();

    var solarSystem = new Kinetic.Group({
        draggable: true
    });

    var backgroundLayer = new Kinetic.Layer();

    var imageObjOne = new Image();

    imageObjOne.onload = function () {
        var background = new Kinetic.Image({
            x: 0,
            y: 0,
            image: imageObjOne,
            width: 1200,
            height: 720
        });
        backgroundLayer.add(background);
        backgroundLayer.draw();
    };

    imageObjOne.src = './images/background/deep-space-01.png';

    stage.add(backgroundLayer);


    var imageObjTwo = new Image();

    imageObjTwo.onload = function () {
        var sun = new Kinetic.Image({
            x: stage.width() / 2 - 35,
            y: stage.height() / 2 - 35,
            image: imageObjTwo,
            width: 70,
            height: 70
        });
        solarSystem.add(sun);
    };

    imageObjTwo.src = './images/sun/sun.png';

    var earth = new Kinetic.Circle({
        x: 0,
        y: 0,
        radius: 15,
        fill: 'blue',
        stroke: 'black',
        strokeWidth: 1
    });

    earth.setAttr('distanceToSun');
    earth.distanceToSun = 130;
    earth.setAttr('speed');
    earth.speed = 3;
    earth.setAttr('period');
    earth.period = 10000 / earth.speed;
    earth.setAttr('orbit');
    earth.orbit = new Kinetic.Circle({
        x: stage.width() / 2,
        y: stage.height() / 2,
        radius: earth.distanceToSun,
        stroke: 'white',
        strokeWidth: 0.2
    });


    var mars = new Kinetic.Circle({
        x: 0,
        y: 0,
        radius: 12,
        fill: 'red',
        stroke: 'black',
        strokeWidth: 1
    });

    mars.setAttr('distanceToSun');
    mars.distanceToSun = 210;
    mars.setAttr('speed');
    mars.speed = 1;
    mars.setAttr('period');
    mars.period = 10000 / mars.speed;
    mars.setAttr('orbit');
    mars.orbit = new Kinetic.Circle({
        x: stage.width() / 2,
        y: stage.height() / 2,
        radius: mars.distanceToSun,
        stroke: 'white',
        strokeWidth: 0.2
    });

    var planets = [earth, mars];

    for (var i = 0; i < planets.length; i += 1) {
        solarSystem.add(planets[i]);
        solarSystem.add(planets[i].orbit);
    }

    layer.add(solarSystem);
    stage.add(layer);

    var centerX = stage.width() / 2;
    var centerY = stage.height() / 2;

    var anim = new Kinetic.Animation(function (frame) {

        for (var i = 0; i < planets.length; i += 1) {
            planets[i].setX(planets[i].distanceToSun * Math.cos(frame.time * 2 * Math.PI / planets[i].period) + centerX);
            planets[i].setY(planets[i].distanceToSun * Math.sin(frame.time * 2 * Math.PI / planets[i].period) + centerY);
        };

    }, layer);

    anim.start();
}());