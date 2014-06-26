function Orbit(centerX, centerY,xRadius, yRadius){
	this.centerX = centerX;
	this.centerY = centerY;
	this.xRadius = xRadius;
	this.yRadius = yRadius;
	
	// To be used to calculate each of the X coordinates to draw the orbit by changing the angle
	this.calcXCoordByAngle = function(angleInDegrees){
		var angleInRadians = toRadians(angleInDegrees);
		var cos = Math.cos(angleInRadians);
		var coordX = this.centerX + this.xRadius * cos;	
		return coordX;
	}

	// To be used to calculate each of the Y coordinates to draw the orbit by changing the angle
	this.calcYCoordByAngle = function(angleInDegrees){
		var angleInRadians = toRadians(angleInDegrees);
		var sin = Math.sin(angleInRadians);
		var coordY = this.centerY + this.YRadius * sin;	
		return coordY;
	}

	// Converts angle in degrees to angle in radians
    function toRadians(angle) {
        return angle * (Math.PI / 180);
    }
}