// Data.collection returns the array of celestial objects

var Data = (function () {
    'use strict';
    // name          - name of the planet/star
    // imgSrc        - Source of the image for the planet/star
    // radius        - Planet/star radius = img.width & img.height // img's offset: { x: radius/2, y: radius/2 }
    // angularSpeed  - Speed with which planet/star orbits around own axis (1 day)
    // orbitSpeed    - Speed with which planet/star orbits around system's axis (1 year = 10000 / orbitSpeed [= planet.period])
    // orbitRadius   - Distance to center of rotation
    // orbitRadusX   - Farther distance to center of rotation if the orbit is an elipce
    // orbitRadusY   - Closer distance to center of rotation if the orbit is an elipce
    // orbitOffset   - If the star's center does not match the center of the planet's rotation is not the center of rotation

    var base = {    // Earth's main properties
        radius: 30,
        angularSpeed: 120,
        orbitSpeed: 3,
        distance: 200
    },
        celestialObjects = [{
            name: 'Sun',
            imgSrc: 'images/sun/sun.png',
            radius: 2.33 * base.radius, // radius: 109.13 * base.radius,    // to make it accurately scaled to Earth's radius
            angularSpeed: 34 * base.angularSpeed,
            orbitSpeed: 10000,          // can't be 0 because period would be 'infinity' (period = 10000 / orbitSpeed)
            orbitRadius: 0,
            orbitRadusX: 0,
            orbitRadusY: 0,
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Mercury',
            imgSrc: 'images/sun/sun.png',   // TODO
            radius: 0.38 * base.radius,
            angularSpeed: 58.6 * base.angularSpeed,
            orbitSpeed: 0.24 * base.orbitSpeed,
            orbitRadius: 0.39 * base.distance,
            orbitRadusX: 0.47 * base.distance,
            orbitRadusY: 0.31 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Venus',
            imgSrc: 'images/sun/sun.png',   // TODO
            radius: 0.95 * base.radius,
            angularSpeed: 241 * base.angularSpeed,
            orbitSpeed: 0.62 * base.orbitSpeed,
            orbitRadius: 0.72 * base.distance,
            orbitRadusX: 0.73 * base.distance,
            orbitRadusY: 0.72 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Earth',
            imgSrc: 'images/planets/earth - Copy.png',
            radius: base.radius,
            angularSpeed: base.angularSpeed,
            orbitSpeed: base.orbitSpeed,
            orbitRadius: base.distance,
            orbitRadusX: 1.02 * base.distance,
            orbitRadusY: 0.98 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Mars',
            imgSrc: './images/planets/mars - Copy.png',
            radius: 0.53 * base.radius,
            angularSpeed: 1.03 * base.angularSpeed,
            orbitSpeed: 1.88 * base.orbitSpeed,
            orbitRadius: 1.52 * base.distance,
            orbitRadusX: 1.67 * base.distance,
            orbitRadusY: 1.37 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Jupiter',
            imgSrc: './images/sun/sun.png', // TODO
            radius: 2 * base.radius,    // radius: 11.21 * base.radius,     // to make it accurately scaled to Earth's radius
            angularSpeed: 0.41 * base.angularSpeed,
            orbitSpeed: 11.86 * base.orbitSpeed,
            orbitRadius: 2.61 * base.distance,  // orbitRadius: 5.21 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusX: 2.73 * base.distance,  // orbitRadusX: 5.46 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusY: 2.48 * base.distance,  // orbitRadusY: 4.96 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Saturn',
            imgSrc: './images/sun/sun.png', // TODO
            radius: 1.8 * base.radius,    // radius: 9.45 * base.radius,    // to make it accurately scaled to Earth's radius
            angularSpeed: 0.44 * base.angularSpeed,
            orbitSpeed: 29.46 * base.orbitSpeed,
            orbitRadius: 3.19 * base.distance,  // orbitRadius: 9.57 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusX: 3.37 * base.distance,  // orbitRadusX: 10.1 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusY: 3.01 * base.distance,  // orbitRadusY: 9.03 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Uranus',
            imgSrc: './images/sun/sun.png', // TODO
            radius: 1.4 * base.radius,    // radius: 4.01 * base.radius,     // to make it accurately scaled to Earth's radius
            angularSpeed: 0.75 * base.angularSpeed,
            orbitSpeed: 84.06 * base.orbitSpeed,
            orbitRadius: 3.85 * base.distance,  // orbitRadius: 19.23 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusX: 4.01 * base.distance,  // orbitRadusX: 20.07 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusY: 3.68 * base.distance,  // orbitRadusY: 18.39 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Neptune',
            imgSrc: './images/sun/sun.png', // TODO
            radius: 1.4 * base.radius,    // radius: 3.88 * base.radius,     // to make it accurately scaled to Earth's radius
            angularSpeed: 0.79 * base.angularSpeed,
            orbitSpeed: 164.84 * base.orbitSpeed,
            orbitRadius: 4.3 * base.distance,   // orbitRadius: 30.10 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusX: 4.35 * base.distance,  // orbitRadusX: 30.43 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusY: 4.25 * base.distance,  // orbitRadusY: 29.77 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            }
        }, {
            name: 'Pluto',
            imgSrc: './images/sun/sun.png', // TODO
            radius: 0.36 * base.radius,
            angularSpeed: 6.4 * base.angularSpeed,
            orbitSpeed: 248.08 * base.orbitSpeed,
            orbitRadius: 4.94 * base.distance,  // orbitRadius: 39.53 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusX: 6.17 * base.distance,  // orbitRadusX: 49.36 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusY: 3.71 * base.distance,  // orbitRadusY: 29.70 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            }
        }];

    return {
        collection: celestialObjects
    };
}());
