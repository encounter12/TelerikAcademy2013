// Data.collection returns an array of objects (the array 'celestialObjects')

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
    // data          - Contains the actual information about the planet/star (data.info keeps wikipedia information)

    var base = {            // Earth's main properties
        radius: 30,
        angularSpeed: 1,    // ~12 for about 1:1 with true speed
        orbitSpeed: 1,
        distance: 120
    },
        celestialObjects = [{
            name: 'Sun',
            imgSrc: './images/sun/sun.png',
            radius: 2.33 * base.radius, // radius: 109.13 * base.radius,    // to make it accurately scaled to Earth's radius
            angularSpeed: 0.0294 * base.angularSpeed,
            orbitSpeed: 1,          // can't be 0 because period would be 'infinity' (period = 10000 / orbitSpeed)
            orbitRadius: 0,
            orbitRadusX: 0,
            orbitRadusY: 0,
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '696000 km',
                dayLength: '34 Earth days',
                closestToSun: '0 AU',
                farthestFromSun: '0 AU',
                timeToOrbitSun: '0 Earth days',
                info: 'The Sun is the star at the center of the Solar System. It is almost perfectly spherical and consists of hot plasma interwoven with magnetic fields. It has a diameter of about 1 392 684 km, around 109 times that of Earth, and its mass (1.989×1030 kilograms, approximately 330 000 times the mass of Earth) accounts for about 99.86% of the total mass of the Solar System.'
            }
        }, {
            name: 'Mercury',
            imgSrc: './images/planets/mercury.png',
            radius: 0.38 * base.radius,
            angularSpeed: 0.0171 * base.angularSpeed,
            orbitSpeed: 4.15 * base.orbitSpeed,
            orbitRadius: 0.39 * base.distance,
            orbitRadusX: 0.47 * base.distance,
            orbitRadusY: 0.31 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '2440 km',
                dayLength: '58.6 Earth days',
                closestToSun: '0.31 AU',
                farthestFromSun: '0.47 AU',
                timeToOrbitSun: '88 Earth days',
                info: 'Mercury is the smallest and closest to the Sun of the eight planets in the Solar System, with an orbital period of about 88 Earth days. Seen from Earth, it appears to move around its orbit in about 116 days, which is much faster than any other planet. Because it has almost no atmosphere to retain heat, Mercury\'s surface experiences the greatest temperature variation of all the planets, ranging from -173 °C at night to 427 °C during the day at some equatorial regions.'
            }
        }, {
            name: 'Venus',
            imgSrc: './images/planets/venus.png',
            radius: 0.95 * base.radius,
            angularSpeed: 0.0041 * base.angularSpeed,
            orbitSpeed: 1.6253 * base.orbitSpeed,
            orbitRadius: 0.72 * base.distance,
            orbitRadusX: 0.73 * base.distance,
            orbitRadusY: 0.72 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '6052 km',
                dayLength: '241 Earth days',
                closestToSun: '0.72 AU',
                farthestFromSun: '0.73 AU',
                timeToOrbitSun: '224.7 Earth days',
                info: 'Venus is the second planet from the Sun, orbiting it every 224.7 Earth days. After the Moon, it is the brightest natural object in the night sky, reaching an apparent magnitude of −4.6, bright enough to cast shadows. Venus is a terrestrial planet and is sometimes called Earth\'s "sister planet" because of their similar size, gravity, and bulk composition (Venus is both the closest planet to Earth and the planet closest in size to Earth).'
            }
        }, {
            name: 'Earth',
            imgSrc: './images/planets/earth.png',
            radius: base.radius,
            angularSpeed: base.angularSpeed,
            orbitSpeed: base.orbitSpeed,
            orbitRadius: base.distance,
            orbitRadusX: 1.02 * base.distance,
            orbitRadusY: 0.98 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '6378 km',
                dayLength: '1 Earth day',
                closestToSun: '0.98 AU',
                farthestFromSun: '1.02 AU',
                timeToOrbitSun: '365.2 Earth days',
                info: 'Earth is the third-closest planet to the Sun, the densest planet in the Solar System, the largest of the Solar System\'s four terrestrial planets and the only celestial body known to accommodate life. Earth was formed around four and a half billion years ago. Within its first billion years, life appeared in its oceans and began to affect its atmosphere and surface, promoting the proliferation of aerobic as well as anaerobic organisms and causing the formation of the atmosphere\'s ozone layer.'
            }
        }, {
            name: 'Mars',
            imgSrc: './images/planets/mars.png',
            radius: 0.53 * base.radius,
            angularSpeed: 0.9709 * base.angularSpeed,
            orbitSpeed: 0.5316 * base.orbitSpeed,
            orbitRadius: 1.52 * base.distance,
            orbitRadusX: 1.67 * base.distance,
            orbitRadusY: 1.37 * base.distance,
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '3396 km',
                dayLength: '1.03 Earth days',
                closestToSun: '1.37 AU',
                farthestFromSun: '1.67 AU',
                timeToOrbitSun: '687 Earth days',
                info: 'Mars is a terrestrial planet with a thin atmosphere, having surface features reminiscent both of the impact craters of the Moon and the volcanoes, valleys, deserts, and polar ice caps of Earth. The rotational period and seasonal cycles of Mars are likewise similar to those of Earth, as is the tilt that produces the seasons. Mars is currently host to five functioning spacecraft: three in orbit - the Mars Odyssey, Mars Express, and Mars Reconnaissance Orbiter – and two on the surface – Mars Exploration Rover Opportunity and the Mars Science Laboratory Curiosity.'
            }
        }, {
            name: 'Jupiter',
            imgSrc: './images/planets/jupiter.png',
            radius: 2 * base.radius,    // radius: 11.21 * base.radius,     // to make it accurately scaled to Earth's radius
            angularSpeed: 2.4450 * base.angularSpeed,
            orbitSpeed: 0.0843 * base.orbitSpeed,
            orbitRadius: 2.61 * base.distance,  // orbitRadius: 5.21 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusX: 2.73 * base.distance,  // orbitRadusX: 5.46 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusY: 2.48 * base.distance,  // orbitRadusY: 4.96 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '1492 km',
                dayLength: '0.41 Earth days',
                closestToSun: '4.96 AU',
                farthestFromSun: '5.46 AU',
                timeToOrbitSun: '4332 Earth days',
                info: 'Jupiter is the fifth planet from the Sun and the largest planet in the Solar System. It is a gas giant with mass one-thousandth of that of the Sun but is two and a half times the mass of all the other planets in the Solar System combined. Jupiter is classified as a gas giant along with Saturn, Uranus and Neptune. Together, these four planets are sometimes referred to as the Jovian or outer planets.'
            }
        }, {
            name: 'Saturn',
            imgSrc: './images/planets/saturn.png',
            radius: 1.8 * base.radius,    // radius: 9.45 * base.radius,    // to make it accurately scaled to Earth's radius
            angularSpeed: 2.2831 * base.angularSpeed,
            orbitSpeed: 0.0339 * base.orbitSpeed,
            orbitRadius: 3.19 * base.distance,  // orbitRadius: 9.57 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusX: 3.37 * base.distance,  // orbitRadusX: 10.1 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitRadusY: 3.01 * base.distance,  // orbitRadusY: 9.03 * base.distance,   // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '60268 km',
                dayLength: '0.44 Earth days',
                closestToSun: '9.03 AU',
                farthestFromSun: '10.10 AU',
                timeToOrbitSun: '10760 Earth days',
                info: 'Saturn is the sixth planet from the Sun and the second largest planet in the Solar System, after Jupiter. Saturn is a gas giant with an average radius about nine times that of Earth. While only one-eighth the average density of Earth, with its larger volume Saturn is just over 95 times more massive. Saturn has a prominent ring system that consists of nine continuous main rings and three discontinuous arcs, composed mostly of ice particles with a smaller amount of rocky debris and dust. Sixty-two known moons orbit the planet; fifty-three are officially named.'
            }
        }, {
            name: 'Uranus',
            imgSrc: './images/planets/uranus.png',
            radius: 1.4 * base.radius,    // radius: 4.01 * base.radius,     // to make it accurately scaled to Earth's radius
            angularSpeed: 1.3333 * base.angularSpeed,
            orbitSpeed: 0.0119 * base.orbitSpeed,
            orbitRadius: 3.85 * base.distance,  // orbitRadius: 19.23 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusX: 4.01 * base.distance,  // orbitRadusX: 20.07 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusY: 3.68 * base.distance,  // orbitRadusY: 18.39 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '25559 km',
                dayLength: '0.75 Earth days',
                closestToSun: '18.39 AU',
                farthestFromSun: '20.07 AU',
                timeToOrbitSun: '30700 Earth days',
                info: 'Uranus is the seventh planet from the Sun. It has the third-largest planetary radius and fourth-largest planetary mass in the Solar System. Uranus is similar in composition to Neptune, and both are of different chemical composition than the larger gas giants Jupiter and Saturn. For this reason, astronomers sometimes place them in a separate category called "ice giants". Uranus\'s atmosphere, contains more "ices" such as water, ammonia, and methane, along with traces of hydrocarbons. It is the coldest planetary atmosphere in the Solar System, with a minimum temperature of -224.2 °C.'
            }
        }, {
            name: 'Neptune',
            imgSrc: './images/planets/neptune.png',
            radius: 1.4 * base.radius,    // radius: 3.88 * base.radius,     // to make it accurately scaled to Earth's radius
            angularSpeed: 1.2658 * base.angularSpeed,
            orbitSpeed: 0.0061 * base.orbitSpeed,
            orbitRadius: 4.3 * base.distance,   // orbitRadius: 30.10 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusX: 4.35 * base.distance,  // orbitRadusX: 30.43 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusY: 4.25 * base.distance,  // orbitRadusY: 29.77 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '24764 km',
                dayLength: '0.79 Earth days',
                closestToSun: '29.77 AU',
                farthestFromSun: '30.43 AU',
                timeToOrbitSun: '60200 Earth days',
                info: 'Neptune is the eighth and farthest planet from the Sun in the Solar System. It is the fourth-largest planet by diameter and the third-largest by mass. Among the gaseous planets in the solar system, Neptune is the most dense. Neptune is 17 times the mass of Earth and is slightly more massive than its near-twin Uranus, which is 15 times the mass of Earth but not as dense. Neptune orbits the Sun at an average distance of 30.1 astronomical units. Neptune was the first planet found by mathematical prediction rather than by empirical observation.'
            }
        }, {
            name: 'Pluto',
            imgSrc: './images/planets/pluto.png',
            radius: 0.36 * base.radius,
            angularSpeed: 0.1563 * base.angularSpeed,
            orbitSpeed: 0.0040 * base.orbitSpeed,
            orbitRadius: 4.94 * base.distance,  // orbitRadius: 39.53 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusX: 6.17 * base.distance,  // orbitRadusX: 49.36 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitRadusY: 3.71 * base.distance,  // orbitRadusY: 29.70 * base.distance,  // to make it accurately scaled to Earth's orbit
            orbitOffset: {
                x: 0,
                y: 0
            },
            data: {
                radius: '2302 km',
                dayLength: '6.4 Earth days',
                closestToSun: '29.70 AU',
                farthestFromSun: '49.36 AU',
                timeToOrbitSun: '90600 Earth days',
                info: 'Pluto is the tenth-most-massive body observed directly orbiting the Sun. It is the second-most-massive known dwarf planet, after Eris. Like other Kuiper-belt objects, Pluto is composed primarily of rock and ice and is relatively small, approximately one-sixth the mass of the Moon and one-third its volume. It has an eccentric and highly inclined orbit that takes it from 30 to 49 AU (4.4 - 7.4 billion km) from the Sun. This causes Pluto to periodically come closer to the Sun than Neptune, but an orbital resonance with Neptune prevents the bodies from colliding.'
            }
        }];

    return {
        collection: celestialObjects
    };
}());
