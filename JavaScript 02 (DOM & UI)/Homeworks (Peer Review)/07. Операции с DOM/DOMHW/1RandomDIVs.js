function randomBetween(x, y) {
    return Math.floor(Math.random() * (y - x) + x);
}
function randomColorString() {
    return "rgb(" + String(randomBetween(0, 256)) + "," +
        String(randomBetween(0, 256)) + "," +
        String(randomBetween(0, 256)) + ")";
}
function randomDiv() {
    var randomDiv = document.createElement("div");
    randomDiv.style.height = String(randomBetween(20, 101)) + "px";
    randomDiv.style.width = String(randomBetween(20, 101)) + "px";
    randomDiv.style.backgroundColor = randomColorString();
    randomDiv.style.color = randomColorString();
    randomDiv.style.position = "absolute";
    randomDiv.style.top = String(randomBetween(0, 1000)) + "px";
    randomDiv.style.left = String(randomBetween(0, 1000)) + "px";
    var insideTheDiv = document.createElement("strong");
    insideTheDiv.textContent = "div";
    randomDiv.style.borderRadius = String(randomBetween(0, 50)) + "px";
    randomDiv.style.borderColor = randomColorString();
    randomDiv.style.borderWidth = String(randomBetween(1, 21)) + "px";
    randomDiv.style.borderStyle = "solid";
    randomDiv.appendChild(insideTheDiv);
    return randomDiv;
}
function twenyRandmoDIVs() {
    var divs = document.createDocumentFragment();
    for (var i = 0; i < 20; i++) {
        divs.appendChild(randomDiv());
    }
    return divs;
}
window.onload = function () {
    document.body.appendChild(twenyRandmoDIVs());
}