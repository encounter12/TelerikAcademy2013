/*jslint browser: true*/
/*global Kinetic*/

(function () {
    'use strict';

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1200,
        height: 720
    });

    //Creating background layer and adding it to the stage
    var backgroundLayer = new Kinetic.Layer();
    var backgroundImage = new Image();
    
    backgroundImage.onload = function () {
        var background = new Kinetic.Image({
            x: 0,
            y: 0,
            image: backgroundImage,
            width: 1200,
            height: 720
        });
        backgroundLayer.add(background);
        backgroundLayer.draw();
    };

    backgroundImage.src = 'images/background/deep-space-01.png';

    stage.add(backgroundLayer);

    //the whole solar system could be dragged anywhere on the canvas
    var solarSystem = new Kinetic.Group({
            draggable: true
    });
    
    var planets = new Kinetic.Group();
    var orbits = new Kinetic.Group();

    //Creating sun and adding it to the solarSystem group
    var sun;
    var sunImage = new Image();

    sunImage.onload = function () {
            sun = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: sunImage,
            width: 70,
            height: 70,
            offset: {x:35, y:35}
        });
        sun.setAttr('angularSpeed');
        sun.angularSpeed = 20;
        solarSystem.add(sun);
    };

    sunImage.src = 'images/sun/sun.png';

   //Creating Earth and adding it to the planets group, Earth's orbit is added to the orbits group
    var earthImage = new Image();

    earthImage.onload = function () {
        var earth = new Kinetic.Image({
            x: stage.width() / 2 + 130,
            y: stage.height() / 2,
            image: earthImage,
            width: 30,
            height: 30,
            offset: { x: 15, y: 15 }
        });
        earth.setAttr('angularSpeed');
        earth.angularSpeed = 240;
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
        planets.add(earth);
        orbits.add(earth.orbit);
    };

    earthImage.src = 'images/planets/earth - Copy.png';

    //Creating Mars and adding it to the planets group, Mars' orbit is added to the orbits group
    var marsImage = new Image();

    marsImage.onload = function () {
        var mars = new Kinetic.Image({
            x: stage.width() / 2 + 210,
            y: stage.height() / 2,
            image: marsImage,
            width: 30,
            height: 30,
            offset: { x: 15, y: 15 }
        });
        mars.setAttr('angularSpeed');
        mars.angularSpeed = 120;
        mars.setAttr('distanceToSun');
        mars.distanceToSun = 210;
        mars.setAttr('speed');
        mars.speed = 1;
        mars.setAttr('period');
        mars.period = 10000 / mars.speed;
        mars.setAttr('orbit');
        mars.orbit = new Kinetic.Circle({

            x: stage.width() / 2 + 25,
            y: stage.height() / 2,
            radius: mars.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.2
        });
        planets.add(mars);
        orbits.add(mars.orbit);
    };

    marsImage.src = './images/planets/mars - Copy.png';

    solarSystem.add(planets);
    solarSystem.add(orbits);

    var layer = new Kinetic.Layer();
    layer.add(solarSystem);
    stage.add(layer);

    var planetsArray = planets.getChildren();


    var angleDiff;

    //class Animation
    var anim = new Kinetic.Animation(function (frame) {

        for (var i = 0; i < planetsArray.length; i += 1) {
            //planets orbiting around the Sun
            planetsArray[i].setX(planetsArray[i].distanceToSun * Math.cos(frame.time * 2 * Math.PI / planetsArray[i].period) + planetsArray[i].orbit.x());
            planetsArray[i].setY(planetsArray[i].distanceToSun * Math.sin(frame.time * 2 * Math.PI / planetsArray[i].period) + planetsArray[i].orbit.y());
            
            //planets rotating on their axes
            angleDiff = frame.timeDiff * planetsArray[i].angularSpeed / 1000;
            planetsArray[i].rotate(angleDiff);
        }

        //Sun rotating on its axis
        angleDiff = frame.timeDiff * sun.angularSpeed / 1000;
        sun.rotate(angleDiff);

    }, layer);

    anim.start();
}());