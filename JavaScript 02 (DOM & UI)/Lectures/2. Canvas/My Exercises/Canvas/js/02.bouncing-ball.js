/*jslint browser: true*/

(function () {
    'use strict';

    var Direction = {
        'Down': 0,
        'DownRight': 1,
        'Right': 2,
        'UpRight': 3,
        'Up': 4,
        'UpLeft': 5,
        'Left': 6,
        'DownLeft': 7
    };
    Object.freeze(Direction);

    var WallPosition = {
        'Bottom': 0,
        'Top': 1,
        'Left': 2,
        'Right': 3
    };
    Object.freeze(WallPosition);

    //simulates ball class
    function Ball(centerX, centerY, radius, direction, lineWidth, strokeStyle, fillStyle) {
        this.centerX = centerX;
        this.centerY = centerY;
        this.radius = radius;
        this.direction = direction;
        this.lineWidth = lineWidth;
        this.strokeStyle = strokeStyle;
        this.fillStyle = fillStyle;
    }

    Ball.prototype.toString = function () {
        return "Center: (" + this.centerX + ", " + this.centerY + "), Radius: " + this.radius;
    };

    Ball.prototype.changeColor = function (colorOne, colorTwo, switchColorsCount, colorsChangeRate) {
        if (switchColorsCount.value >= 2 * colorsChangeRate) {
            switchColorsCount.value = 0;
        }

        if (switchColorsCount.value > 0 && switchColorsCount.value <= colorsChangeRate) {
            this.fillStyle = colorOne;
        }
        else {
            this.fillStyle = colorTwo;
        }
        switchColorsCount.value += 1;
    };

    Ball.prototype.draw = function (context) {
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.beginPath();
        context.arc(this.centerX, this.centerY, this.radius, 0, 2 * Math.PI);
        context.closePath();

        context.restore();

        context.lineWidth = this.lineWidth;
        context.strokeStyle = this.strokeStyle;
        context.fillStyle = this.fillStyle;

        context.stroke();
        context.fill();
    };

    Ball.prototype.isWallReached = function (canvas) {
        var wallReached = false,
            ballMostLeftCoord = this.centerX - this.radius,
            ballMostRightCoord = this.centerX + this.radius,
            ballHighestCoord = this.centerY - this.radius,
            ballLowestCoord = this.centerY + this.radius;

        if (ballMostLeftCoord <= 0 || ballMostRightCoord >= canvas.width ||
                ballHighestCoord <= 0 || ballLowestCoord >= canvas.height) {
            wallReached = true;
        }

        return wallReached;
    };

    Ball.prototype.getReachedWall = function (canvas) {
        var ballMostLeftCoord = this.centerX - this.radius,
            ballMostRightCoord = this.centerX + this.radius,
            ballHighestCoord = this.centerY - this.radius,
            ballLowestCoord = this.centerY + this.radius,
            reachedWall;

        if (ballMostLeftCoord <= 0) {
            reachedWall = WallPosition.Left;
        } else if (ballMostRightCoord >= canvas.width) {
            reachedWall = WallPosition.Right;
        } else if (ballHighestCoord <= 0) {
            reachedWall = WallPosition.Top;
        } else if (ballLowestCoord >= canvas.height) {
            reachedWall = WallPosition.Bottom;
        } else {
            reachedWall = null;
        }
        return reachedWall;
    };

    Ball.prototype.changeDirection = function (canvas) {

        if (this.direction === Direction.DownRight &&
                this.getReachedWall(canvas) === WallPosition.Bottom) {
            this.direction = Direction.UpRight;
        } else if (this.direction === Direction.DownRight &&
                    this.getReachedWall(canvas) === WallPosition.Right) {
            this.direction = Direction.DownLeft;
        } else if (this.direction === Direction.UpRight &&
                    this.getReachedWall(canvas) === WallPosition.Top) {
            this.direction = Direction.DownRight;
        } else if (this.direction === Direction.UpRight &&
                    this.getReachedWall(canvas) === WallPosition.Right) {
            this.direction = Direction.UpLeft;
        } else if (this.direction === Direction.DownLeft &&
                    this.getReachedWall(canvas) === WallPosition.Bottom) {
            this.direction = Direction.UpLeft;
        } else if (this.direction === Direction.DownLeft &&
                    this.getReachedWall(canvas) === WallPosition.Left) {
            this.direction = Direction.DownRight;
        } else if (this.direction === Direction.UpLeft &&
                    this.getReachedWall(canvas) === WallPosition.Top) {
            this.direction = Direction.DownLeft;
        } else if (this.direction === Direction.UpLeft &&
                this.getReachedWall(canvas) === WallPosition.Left) {
            this.direction = Direction.UpRight;
        } else if (this.direction === Direction.Down) {
            this.direction = Direction.Up;
        } else if (this.direction === Direction.Up) {
            this.direction = Direction.Down;
        } else if (this.direction === Direction.Left) {
            this.direction = Direction.Right;
        } else if (this.direction === Direction.Right) {
            this.direction = Direction.Left;
        } else {
            throw "Error: Invalid direction type.";
        }
    };

    Ball.prototype.move = function (speed) {
        switch (this.direction) {
        case Direction.Down:
            this.centerY += speed;
            break;
        case Direction.Up:
            this.centerY -= speed;
            break;
        case Direction.Left:
            this.centerX -= speed;
            break;
        case Direction.Right:
            this.centerX += speed;
            break;
        case Direction.DownRight:
            this.centerX += speed;
            this.centerY += speed;
            break;
        case Direction.UpRight:
            this.centerX += speed;
            this.centerY -= speed;
            break;
        case Direction.UpLeft:
            this.centerX -= speed;
            this.centerY -= speed;
            break;
        case Direction.DownLeft:
            this.centerX -= speed;
            this.centerY += speed;
            break;
        default:
            throw "Error: Invalid ball move.";
        }
    };

    var canvas = document.getElementById('the-canvas'),
        context = canvas.getContext("2d"),
        ballRadius = 30,
        startX = ballRadius + 2,
        startY = canvas.height / 2,
        speed = 2,
        ball = new Ball(startX, startY, ballRadius, Direction.DownRight, 2, '#252321', '#D4DBD3');
        //var switchColorsCount = {value: 0};
        //var colorsChangeRate = 20;
    

    function startBouncing() {

        if (ball.isWallReached(canvas)) {
            ball.changeDirection(canvas);
        }

        //ball.changeColor('#AEB5D4', '#334061', switchColorsCount, colorsChangeRate);

        ball.draw(context);
        ball.move(speed);
        
        requestAnimationFrame(startBouncing);
    }
    requestAnimationFrame(startBouncing);

}());