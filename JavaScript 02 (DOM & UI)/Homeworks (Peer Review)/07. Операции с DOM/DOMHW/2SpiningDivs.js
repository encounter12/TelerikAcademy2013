var cx = 500;
var cy = 500;
var r = 300;
var divs;
var positions = [];
var speed = 0.05;
window.onload = function () {
    divs = document.getElementsByTagName("div");
    var length = divs.length;
    for (var i = 0; i < length; i++) {
        divs[i].style.left = String(cx + Math.cos((Math.PI * 2 / length) * i)*r) + "px";
        divs[i].style.top = String(cy + Math.sin((Math.PI * 2 / length) * i)*r) + "px";
        positions.push((Math.PI * 2 / length) * i);
    }
    animate()
}
function animate() {
    var length = divs.length;
    for (var i = 0; i < length; i++) {
        divs[i].style.left = String(cx + Math.cos(positions[i]) * r) + "px";
        divs[i].style.top = String(cy + Math.sin(positions[i]) * r) + "px";
        positions[i] += speed;
    }
    setTimeout(animate, 50);
}