/*global CelestialBody, Orbit */

//  var loader = new Loader(Data.collection, stage.width(), stage.height());
//  var selestialObjects = loader.load();

// var Loader = function (collection, centerX, centerY) {
var Loader = function (collection, containerWidth, containerHeight) {
    'use strict';
    this.load = function () {
        var celestialBodies = [],
            length = collection.length,
            celestialBody,
            orbit,
            i;

        for (i = 0; i < length; i += 1) {
            orbit = new Orbit();
            celestialBody = new CelestialBody(/*...,*/ orbit); // ?? or whatever it will be called. It should describe both the planets and the Sun
            // Properties to use:
            // x -> centerX or containerWidth / 2
            // y -> centerX or containerHeight / 2
            // collection[i].name
            // collection[i].radius
            // collection[i].angularSpeed
            // collection[i].imgSrc
            // collection[i].orbitSpeed
            // collection[i].orbitOffset
            // \/ for cicle \/
            // collection[i].orbitRadius
            // \/ for elipse \/
            // collection[i].orbitRadiusX
            // collection[i].orbitRadiusY
            // + For orbit:
            //      period = 10000 / speed
            //      stroke = 'white';
            //      stroke width = 0.2;
            // solarSystemObject.imgSrc = collection[i].imgSrc;
            celestialBodies.push(celestialBody);
        }

        return celestialBodies;
    };
};
