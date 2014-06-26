/*global CelestialBody, Orbit */

// To get the objects from Data.collection as space objects (or celestial objects, or whatever) use:
// var loader = new Loader(Data.collection, centerX, centerY);
// var selestialObjects = loader.load();
// Where centerX and centerY are the center of the container (stage) (i.e. centerX=stage.width()/2, centerY=stage.height()/2)
// ... and selestialObjects is the collection/array of space objects that you want to use.

var Loader = function (collection, centerX, centerY) {
    // var Loader = function (collection, containerWidth, containerHeight)
    'use strict';
    this.load = function () {
        var celestialBodies = [],
            length = collection.length,
            celestialBody,
            orbit,
            i,
            orbitCenterX,
            orbitCenterY,
            orbitRadiusX,
            orbitRadiusY,
            name,
            radius,
            angularSpeed,
            orbitSpeed;

        for (i = 0; i < length; i += 1) {
            orbitCenterX = centerX + collection[i].orbitOffset.x;
            orbitCenterY = centerY + collection[i].orbitOffset.y;
            orbitRadiusX = collection[i].orbitRadiusX;
            orbitRadiusY = collection[i].orbitRadiusY;

            orbit = new Orbit(orbitCenterX, orbitCenterY, orbitRadiusX, orbitRadiusY);

            name = collection[i].name;
            radius = collection[i].radius;
            angularSpeed = collection[i].angularSpeed;
            orbitSpeed = collection[i].orbitSpeed;

            // Suggestion for constructor for Planet, or SpaceObject, or CelestialBody, or whatever it'll be called:
            celestialBody = new CelestialBody(name, radius, angularSpeed, orbitSpeed, orbit);
            // The following props I don't think shold be given through the constructor:
            // - x and y can be taken from the orbit
            // - the period is calculated through the orbitSpeed
            // - the offsets for the picture are calculated with the radius

            // The following can also be given through the constructor but there'd be too much arguments I think so
            // I'm setting their values separately:
            celestialBody.imgSrc = collection[i].imgSrc;
            // In 'celestialBody.imgSrc', 'imgSrc' should be renamed to whatever the property about the picture's
            // source would be in the planet class.

            // Data is in this format to make it easier to make a .toString() method for the planets in which the info
            // can be stiched together any way we see fit (if that's ever needed).
            // We can otherwise just use celestialBody.data.info in which there is some Wikipedia text.
            celestialBody.data = {
                radius: collection[i].data.radius,
                dayLength: collection[i].data.dayLength,
                closestToSun: collection[i].data.closestToSun,
                farthestFromSun: collection[i].data.farthestFromSun,
                timeToOrbitSun: collection[i].data.timeToOrbitSun,
                info: collection[i].data.info,
            };

            celestialBodies.push(celestialBody);
        }

        return celestialBodies;
        // celestialBodies[0] -> the Sun
        // celestialBodies[n] (n != 0) -> the planets
    };
};
