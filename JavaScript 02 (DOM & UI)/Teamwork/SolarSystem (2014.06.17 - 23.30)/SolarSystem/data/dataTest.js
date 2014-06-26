/*jslint browser: true*/
/*global Kinetic*/

(function () {
    'use strict';

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1200,
        height: 1200
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
            height: 1200
        });
        backgroundLayer.add(background);
        backgroundLayer.draw();
    };

    backgroundImage.src = '../images/background/deep-space-01.png';

    stage.add(backgroundLayer);

    //the whole solar system could be dragged anywhere on the canvas
    var solarSystem = new Kinetic.Group({
        draggable: true
    });

    var planets = new Kinetic.Group();
    var orbits = new Kinetic.Group();
    var base = {    // Earth's main properties
        radius: 30,
        angularSpeed: 1, // ~12 for about 1:1 with true speed when base.orbitSpeed is 1
        orbitSpeed: 1,
        distance: 120
    };
    //Creating sun and adding it to the solarSystem group
    var sun;
    var sunImage = new Image();

    sunImage.onload = function () {
        sun = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: sunImage,
            width: 2.33 * base.radius,
            height: 2.33 * base.radius,
            offset: {
                x: 2.33 * base.radius / 2,
                y: 2.33 * base.radius / 2
            }
        });
        sun.setAttr('angularSpeed');
        sun.angularSpeed = 0.0294 * base.angularSpeed;
        solarSystem.add(sun);
    };

    sunImage.src = '../images/sun/sun.png';

    //****************

    //Creating Mercury and adding it to the planets group, Earth's orbit is added to the orbits group
    var mercuryImage = new Image();

    mercuryImage.onload = function () {
        var mercury = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: mercuryImage,
            width: 0.38 * base.radius,
            height: 0.38 * base.radius,
            offset: {
                x: 0.38 * base.radius / 2,
                y: 0.38 * base.radius / 2
            }
        });
        mercury.setAttr('angularSpeed');
        mercury.angularSpeed = 0.0171 * base.angularSpeed;
        mercury.setAttr('distanceToSun');
        mercury.distanceToSun = 0.39 * base.distance;
        mercury.setAttr('speed');
        mercury.speed = 4.15 * base.orbitSpeed;
        mercury.setAttr('period');
        mercury.period = 10000 / mercury.speed;
        mercury.setAttr('orbit');
        mercury.orbit = new Kinetic.Circle({
            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: mercury.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(mercury);
        orbits.add(mercury.orbit);
    };

    mercuryImage.src = '../images/planets/mercury.png';

    //Creating Venus and adding it to the planets group, Earth's orbit is added to the orbits group
    var venusImage = new Image();

    venusImage.onload = function () {
        var venus = new Kinetic.Image({
            x: stage.width() / 2 + 80,
            y: stage.height() / 2,
            image: venusImage,
            width: 0.95 * base.radius,
            height: 0.95 * base.radius,
            offset: {
                x: 0.95 * base.radius / 2,
                y: 0.95 * base.radius / 2
            }
        });
        venus.setAttr('angularSpeed');
        venus.angularSpeed = 0.0041 * base.angularSpeed;
        venus.setAttr('distanceToSun');
        venus.distanceToSun = 0.72 * base.distance;
        venus.setAttr('speed');
        venus.speed = 1.6253 * base.orbitSpeed;
        venus.setAttr('period');
        venus.period = 10000 / venus.speed;
        venus.setAttr('orbit');
        venus.orbit = new Kinetic.Circle({
            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: venus.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(venus);
        orbits.add(venus.orbit);
    };

    venusImage.src = '../images/planets/venus.png';

    //Creating Earth and adding it to the planets group, Earth's orbit is added to the orbits group
    var earthImage = new Image();

    earthImage.onload = function () {
        var earth = new Kinetic.Image({
            x: stage.width() / 2 + 130,
            y: stage.height() / 2,
            image: earthImage,
            width: base.radius,
            height: base.radius,
            offset: {
                x: base.radius / 2,
                y: base.radius / 2
            }
        });
        earth.setAttr('angularSpeed');
        earth.angularSpeed = base.angularSpeed;
        earth.setAttr('distanceToSun');
        earth.distanceToSun = base.distance;
        earth.setAttr('speed');
        earth.speed = base.orbitSpeed;
        earth.setAttr('period');
        earth.period = 10000 / earth.speed;
        earth.setAttr('orbit');
        earth.orbit = new Kinetic.Circle({
            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: earth.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(earth);
        orbits.add(earth.orbit);
    };

    earthImage.src = '../images/planets/earth.png';

    //Creating Mars and adding it to the planets group, Mars' orbit is added to the orbits group
    var marsImage = new Image();

    marsImage.onload = function () {
        var mars = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: marsImage,
            width: 0.53 * base.radius,
            height: 0.53 * base.radius,
            offset: {
                x: 0.53 * base.radius / 2,
                y: 0.53 * base.radius / 2
            }
        });
        mars.setAttr('angularSpeed');
        mars.angularSpeed = 0.9709 * base.angularSpeed;
        mars.setAttr('distanceToSun');
        mars.distanceToSun = 1.52 * base.distance;
        mars.setAttr('speed');
        mars.speed = 0.5316 * base.orbitSpeed;
        mars.setAttr('period');
        mars.period = 10000 / mars.speed;
        mars.setAttr('orbit');
        mars.orbit = new Kinetic.Circle({

            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: mars.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(mars);
        orbits.add(mars.orbit);
    };

    marsImage.src = '../images/planets/mars.png';

    //Creating Jupiter and adding it to the planets group, Mars' orbit is added to the orbits group
    var jupiterImage = new Image();

    jupiterImage.onload = function () {
        var jupiter = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: jupiterImage,
            width: 2 * base.radius,
            height: 2 * base.radius,
            offset: {
                x: 2 * base.radius / 2,
                y: 2 * base.radius / 2
            }
        });
        jupiter.setAttr('angularSpeed');
        jupiter.angularSpeed = 2.4450 * base.angularSpeed;
        jupiter.setAttr('distanceToSun');
        jupiter.distanceToSun = 2.61 * base.distance;
        jupiter.setAttr('speed');
        jupiter.speed = 0.0843 * base.orbitSpeed;
        jupiter.setAttr('period');
        jupiter.period = 10000 / jupiter.speed;
        jupiter.setAttr('orbit');
        jupiter.orbit = new Kinetic.Circle({

            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: jupiter.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(jupiter);
        orbits.add(jupiter.orbit);
    };

    jupiterImage.src = '../images/planets/jupiter.png';

    //Creating Saturn and adding it to the planets group, Mars' orbit is added to the orbits group
    var saturnImage = new Image();

    saturnImage.onload = function () {
        var saturn = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: saturnImage,
            width: 1.8 * base.radius,
            height: 1.8 * base.radius,
            offset: {
                x: 1.8 * base.radius / 2,
                y: 1.8 * base.radius / 2
            }
        });
        saturn.setAttr('angularSpeed');
        saturn.angularSpeed = 2.2831 * base.angularSpeed;
        saturn.setAttr('distanceToSun');
        saturn.distanceToSun = 3.19 * base.distance;
        saturn.setAttr('speed');
        saturn.speed = 0.0339 * base.orbitSpeed;
        saturn.setAttr('period');
        saturn.period = 10000 / saturn.speed;
        saturn.setAttr('orbit');
        saturn.orbit = new Kinetic.Circle({

            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: saturn.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(saturn);
        orbits.add(saturn.orbit);
    };

    saturnImage.src = '../images/planets/saturn.png';

    //Creating Uranus and adding it to the planets group, Mars' orbit is added to the orbits group
    var uranusImage = new Image();

    uranusImage.onload = function () {
        var uranus = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: uranusImage,
            width: 1.4 * base.radius,
            height: 1.4 * base.radius,
            offset: {
                x: 1.4 * base.radius / 2,
                y: 1.4 * base.radius / 2
            }
        });
        uranus.setAttr('angularSpeed');
        uranus.angularSpeed = 1.3333 * base.angularSpeed;
        uranus.setAttr('distanceToSun');
        uranus.distanceToSun = 3.85 * base.distance;
        uranus.setAttr('speed');
        uranus.speed = 0.0119 * base.orbitSpeed;
        uranus.setAttr('period');
        uranus.period = 10000 / uranus.speed;
        uranus.setAttr('orbit');
        uranus.orbit = new Kinetic.Circle({

            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: uranus.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(uranus);
        orbits.add(uranus.orbit);
    };

    uranusImage.src = '../images/planets/uranus.png';

    //Creating Neptune and adding it to the planets group, Mars' orbit is added to the orbits group
    var neptuneImage = new Image();

    neptuneImage.onload = function () {
        var neptune = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: neptuneImage,
            width: 1.4 * base.radius,
            height: 1.4 * base.radius,
            offset: {
                x: 1.4 * base.radius / 2,
                y: 1.4 * base.radius / 2
            }
        });
        neptune.setAttr('angularSpeed');
        neptune.angularSpeed = 1.2658 * base.angularSpeed;
        neptune.setAttr('distanceToSun');
        neptune.distanceToSun = 4.3 * base.distance;
        neptune.setAttr('speed');
        neptune.speed = 0.0061 * base.orbitSpeed;
        neptune.setAttr('period');
        neptune.period = 10000 / neptune.speed;
        neptune.setAttr('orbit');
        neptune.orbit = new Kinetic.Circle({

            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: neptune.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(neptune);
        orbits.add(neptune.orbit);
    };

    neptuneImage.src = '../images/planets/neptune.png';

    //Creating Pluto and adding it to the planets group, Mars' orbit is added to the orbits group
    var plutoImage = new Image();

    plutoImage.onload = function () {
        var pluto = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: plutoImage,
            width: 0.36 * base.radius,
            height: 0.36 * base.radius,
            offset: {
                x: 0.36 * base.radius / 2,
                y: 0.36 * base.radius / 2
            }
        });
        pluto.setAttr('angularSpeed');
        pluto.angularSpeed = 0.1563 * base.angularSpeed;
        pluto.setAttr('distanceToSun');
        pluto.distanceToSun = 4.94 * base.distance;
        pluto.setAttr('speed');
        pluto.speed = 0.0040 * base.orbitSpeed;
        pluto.setAttr('period');
        pluto.period = 10000 / pluto.speed;
        pluto.setAttr('orbit');
        pluto.orbit = new Kinetic.Circle({

            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: pluto.distanceToSun,
            stroke: 'white',
            strokeWidth: 0.10
        });
        planets.add(pluto);
        orbits.add(pluto.orbit);
    };

    plutoImage.src = '../images/planets/pluto.png';

    solarSystem.add(orbits);
    solarSystem.add(planets);

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
            angleDiff = frame.timeDiff * planetsArray[i].angularSpeed;
            planetsArray[i].rotate(angleDiff);
        }

        //Sun rotating on its axis
        angleDiff = frame.timeDiff * sun.angularSpeed;
        sun.rotate(angleDiff);

    }, layer);

    anim.start();
}());
