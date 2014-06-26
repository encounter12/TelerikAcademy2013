var stage = new Kinetic.Stage({
    container: 'container',
    width: 900,
    height: 600
});

var layer = new Kinetic.Layer();

var rect = new Kinetic.Rect({
    x: 30,
    y: 30,
    width: 133,
    height: 45,
    stroke: 'green',
    strokeWidth: 1,
    cornerRadius: 4
});

var personsName = new Kinetic.Text({
    x: 0,
    y: 0,
    text: 'Martin Petrov',
    width: 110,
    fontSize: 17,
    fontFamily: 'Calibri',
    fill: 'black'
});

var rectWithInnerText = new Kinetic.Group({
        x: 0,
        y: 0,
        draggable: true
});

rectWithInnerText.add(rect);
rectWithInnerText.add(personsName);
  
layer.add(rectWithInnerText);

stage.add(layer);