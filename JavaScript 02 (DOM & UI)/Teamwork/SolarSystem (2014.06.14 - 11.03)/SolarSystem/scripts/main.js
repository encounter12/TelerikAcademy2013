/*jslint browser: true*/
/*global Kinetic, Animation*/

(function() {
    'use strict';

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1100,
        height: 1050
    });

    //Creating background layer and adding it to the stage
    var backgroundLayer = new Kinetic.Layer();
    var backgroundImage = new Image();

    backgroundImage.onload = function() {
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

    backgroundImage.src = 'images/background/deep-space-01.png';

    stage.add(backgroundLayer);

    //the whole solar system could be dragged anywhere on the canvas
    var solarSystem = new Kinetic.Group({
        draggable: true
    });

    var spaceObjects = new Kinetic.Group();
    var orbits = new Kinetic.Group();

    //Creating sun and adding it to the solarSystem group
    var sun;
    var sunImage = new Image();

    sunImage.onload = function() {
        sun = new Kinetic.Image({
            x: stage.width() / 2,
            y: stage.height() / 2,
            image: sunImage,
            width: 180,
            height: 180,
            offset: {
                x: 90,
                y: 90
            }
        });
        sun.setAttr('angularSpeed');
        sun.angularSpeed = -1;
        sun.setAttr('period');
        sun.period = 3300;
        sun.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: {
                x: 0,
                y: 0
            },
            stroke: 'white',
            strokeWidth: 0.2
        });
        
        spaceObjects.add(sun);
    };

    sunImage.src = 'images/sun/sun.png';

    //****************

    //Creating Mercury and adding it to the spaceObjects group, Earth's orbit is added to the orbits group
    var mercuryImage = new Image();

    mercuryImage.onload = function() {
        var mercury = new Kinetic.Image({
            x: stage.width() / 2 + 80,
            y: stage.height() / 2,
            image: mercuryImage,
            width: 16,
            height: 16,
            offset: {
                x: 8,
                y: 8
            }
        });
        mercury.setAttr('angularSpeed');
        mercury.angularSpeed = -180;
        mercury.setAttr('speed');
        mercury.speed = -1.2;
        mercury.setAttr('period');
        mercury.period = 10000 / mercury.speed;
        mercury.setAttr('orbit');
        mercury.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2,
            y: stage.height() / 2 - 2,
            radius: {
                x: 100,
                y: 90
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(mercury);
        orbits.add(mercury.orbit);
    };

    mercuryImage.src = 'images/planets/mercury.png';

    //Creating Venus and adding it to the spaceObjects group, Earth's orbit is added to the orbits group
    var venusImage = new Image();

    venusImage.onload = function() {
        var venus = new Kinetic.Image({
            x: stage.width() / 2 + 80,
            y: stage.height() / 2,
            image: venusImage,
            width: 20,
            height: 20,
            offset: {
                x: 10,
                y: 10
            }
        });
        venus.setAttr('angularSpeed');
        venus.angularSpeed = 100;
        venus.setAttr('speed');
        venus.speed = -1;
        venus.setAttr('period');
        venus.period = 10000 / venus.speed;
        venus.setAttr('orbit');
        venus.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2 + 5,
            y: stage.height() / 2,
            radius: {
                x: 130,
                y: 124
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(venus);
        orbits.add(venus.orbit);
    };

    venusImage.src = 'images/planets/venus.png';

    //Creating Earth and adding it to the spaceObjects group, Earth's orbit is added to the orbits group
    var earthImage = new Image();

    earthImage.onload = function() {
        var earth = new Kinetic.Image({
            x: stage.width() / 2 + 130,
            y: stage.height() / 2,
            image: earthImage,
            width: 30,
            height: 30,
            offset: {
                x: 15,
                y: 15
            }
        });
        earth.setAttr('angularSpeed');
        earth.angularSpeed = -90;
        earth.setAttr('speed');
        earth.speed = -1.3;
        earth.setAttr('period');
        earth.period = 10000 / earth.speed;
        earth.setAttr('orbit');
        earth.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2,
            y: stage.height() / 2 + 2,
            radius: {
                x: 170,
                y: 150
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(earth);
        orbits.add(earth.orbit);
    };

    earthImage.src = 'images/planets/earth.png';

    //Creating Mars and adding it to the spaceObjects group, Mars' orbit is added to the orbits group
    var marsImage = new Image();

    marsImage.onload = function() {
        var mars = new Kinetic.Image({
            x: stage.width() / 2 + 210,
            y: stage.height() / 2,
            image: marsImage,
            width: 18,
            height: 18,
            offset: {
                x: 9,
                y: 9
            }
        });
        mars.setAttr('angularSpeed');
        mars.angularSpeed = -60;
        mars.setAttr('speed');
        mars.speed = -0.4;
        mars.setAttr('period');
        mars.period = 10000 / mars.speed;
        mars.setAttr('orbit');
        mars.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2 + 9,
            y: stage.height() / 2 + 12,
            radius: {
                x: 230,
                y: 210
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(mars);
        orbits.add(mars.orbit);
    };

    marsImage.src = './images/planets/mars.png';

    //Creating Jupiter and adding it to the spaceObjects group, Mars' orbit is added to the orbits group
    var jupiterImage = new Image();

    jupiterImage.onload = function() {
        var jupiter = new Kinetic.Image({
            x: stage.width() / 2 + 250,
            y: stage.height() / 2,
            image: jupiterImage,
            width: 50,
            height: 50,
            offset: {
                x: 25,
                y: 25
            }
        });
        jupiter.setAttr('angularSpeed');
        jupiter.angularSpeed = -120;
        jupiter.setAttr('speed');
        jupiter.speed = -1.1;
        jupiter.setAttr('period');
        jupiter.period = 10000 / jupiter.speed;
        jupiter.setAttr('orbit');
        jupiter.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2 - 10,
            y: stage.height() / 2 - 6,
            radius: {
                x: 300,
                y: 280
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(jupiter);
        orbits.add(jupiter.orbit);
    };

    jupiterImage.src = './images/planets/jupiter.png';

    //Creating Saturn and adding it to the spaceObjects group, Mars' orbit is added to the orbits group
    var saturnImage = new Image();

    saturnImage.onload = function() {
        var saturn = new Kinetic.Image({
            x: stage.width() / 2 + 250,
            y: stage.height() / 2,
            image: saturnImage,
            width: 48,
            height: 48,
            offset: {
                x: 24,
                y: 24
            }
        });
        saturn.setAttr('angularSpeed');
        saturn.angularSpeed = -50;
        saturn.setAttr('speed');
        saturn.speed = -0.6;
        saturn.setAttr('period');
        saturn.period = 10000 / saturn.speed;
        saturn.setAttr('orbit');
        saturn.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2,
            y: stage.height() / 2 - 7,
            radius: {
                x: 370,
                y: 355
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(saturn);
        orbits.add(saturn.orbit);
    };

    saturnImage.src = './images/planets/saturn.png';

    //Creating Uranus and adding it to the spaceObjects group, Mars' orbit is added to the orbits group
    var uranusImage = new Image();

    uranusImage.onload = function() {
        var uranus = new Kinetic.Image({
            x: stage.width() / 2 + 250,
            y: stage.height() / 2,
            image: uranusImage,
            width: 26,
            height: 26,
            offset: {
                x: 13,
                y: 13
            }
        });
        uranus.setAttr('angularSpeed');
        uranus.angularSpeed = 190;
        uranus.setAttr('speed');
        uranus.speed = -0.7;
        uranus.setAttr('period');
        uranus.period = 10000 / uranus.speed;
        uranus.setAttr('orbit');
        uranus.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: {
                x: 410,
                y: 400
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(uranus);
        orbits.add(uranus.orbit);
    };

    uranusImage.src = './images/planets/uranus.png';

    //Creating Neptune and adding it to the spaceObjects group, Mars' orbit is added to the orbits group
    var neptuneImage = new Image();

    neptuneImage.onload = function() {
        var neptune = new Kinetic.Image({
            x: stage.width() / 2 + 250,
            y: stage.height() / 2,
            image: neptuneImage,
            width: 26,
            height: 26,
            offset: {
                x: 13,
                y: 13
            }
        });
        neptune.setAttr('angularSpeed');
        neptune.angularSpeed = -140;
        neptune.setAttr('speed');
        neptune.speed = -0.3;
        neptune.setAttr('period');
        neptune.period = 10000 / neptune.speed;
        neptune.setAttr('orbit');
        neptune.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2,
            y: stage.height() / 2,
            radius: {
                x: 450,
                y: 440
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(neptune);
        orbits.add(neptune.orbit);
    };

    neptuneImage.src = './images/planets/neptune.png';

    //Creating Pluto and adding it to the spaceObjects group, Mars' orbit is added to the orbits group
    var plutoImage = new Image();

    plutoImage.onload = function() {
        var pluto = new Kinetic.Image({
            x: stage.width() / 2 + 250,
            y: stage.height() / 2,
            image: plutoImage,
            width: 22,
            height: 22,
            offset: {
                x: 11,
                y: 11
            }
        });
        pluto.setAttr('angularSpeed');
        pluto.angularSpeed = 100;
        pluto.setAttr('speed');
        pluto.speed = -0.5;
        pluto.setAttr('period');
        pluto.period = 10000 / pluto.speed;
        pluto.setAttr('orbit');
        pluto.orbit = new Kinetic.Ellipse({
            x: stage.width() / 2 + 15,
            y: stage.height() / 2 + 10,
            radius: {
                x: 500,
                y: 485
            },
            stroke: 'white',
            strokeWidth: 0.10
        });
        spaceObjects.add(pluto);
        orbits.add(pluto.orbit);
    };

    plutoImage.src = './images/planets/pluto.png';

    solarSystem.add(spaceObjects);
    solarSystem.add(orbits);
    
    var layer = new Kinetic.Layer();
    layer.add(solarSystem);
    stage.add(layer);

    var animation = new Animation(spaceObjects, layer);

    animation.start();

    document.getElementById('start').addEventListener('click', function() {
        animation.start();
    }, false);

    document.getElementById('stop').addEventListener('click', function() {
        animation.stop();
    }, false);

}());