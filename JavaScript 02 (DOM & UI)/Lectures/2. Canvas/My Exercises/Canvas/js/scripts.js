/*jslint browser: true*/

window.onload = function () {
    'use strict';
    var theCanvas = document.getElementById("the-canvas"),
        canvasCtx = theCanvas.getContext("2d");

    canvasCtx.lineWidth = "2";
    canvasCtx.fillStyle = "olive";
    canvasCtx.strokeStyle = "darkblue";

    //canvasCtx.fillRect(10, 10, 300, 150);
    //canvasCtx.strokeRect(10, 10, 300, 150);

    //canvasCtx.beginPath();
    //canvasCtx.moveTo(400, 400);
    //canvasCtx.lineTo(600, 200);
    //canvasCtx.lineTo(400, 200);
    //canvasCtx.lineTo(400, 400);
    //canvasCtx.stroke();
    //canvasCtx.fill();
    //canvasCtx.closePath();

    //canvasCtx.beginPath();
    //canvasCtx.rotate(20 * Math.PI / 180);
    //canvasCtx.moveTo(400, 400);
    //canvasCtx.lineTo(600, 200);
    //canvasCtx.lineTo(400, 200);
    //canvasCtx.lineTo(400, 400);
    //canvasCtx.stroke();
    //canvasCtx.fill();
    //canvasCtx.closePath();

    //canvasCtx.beginPath();
    //canvasCtx.rotate(25 * Math.PI / 180);
    //canvasCtx.moveTo(400, 400);
    //canvasCtx.lineTo(600, 200);
    //canvasCtx.lineTo(400, 200);
    //canvasCtx.lineTo(400, 400);
    //canvasCtx.stroke();
    //canvasCtx.fill();
    //canvasCtx.closePath();

    //canvasCtx.beginPath();
    //canvasCtx.arc(300, 300, 100, 230 * Math.PI / 180, 130 * Math.PI / 180, false);
    //canvasCtx.stroke();
    //canvasCtx.fill();
    //canvasCtx.closePath();

    //function drawSector(x, y, r, from, to, isCounterClockwise) {
    //    canvasCtx.beginPath();
    //    canvasCtx.arc(x, y, r, from, to, isCounterClockwise);
    //    canvasCtx.lineTo(x, y);
    //    canvasCtx.closePath();
    //    canvasCtx.stroke();
    //    canvasCtx.fill();
    //}
    //drawSector(300, 300, 100, 210 * Math.PI / 180, 140 * Math.PI / 180, false);

    canvasCtx.beginPath();
    canvasCtx.moveTo(400, 380);
    canvasCtx.quadraticCurveTo(500, 500, 500, 100);
    canvasCtx.quadraticCurveTo(500, 600, 600, 320);
    canvasCtx.moveTo(470, 280);
    canvasCtx.lineTo(520, 270);    
    canvasCtx.stroke();
    canvasCtx.closePath();

    
    canvasCtx.font = "30px Calibri";
    canvasCtx.fillText("some text", 300, 600);
};
