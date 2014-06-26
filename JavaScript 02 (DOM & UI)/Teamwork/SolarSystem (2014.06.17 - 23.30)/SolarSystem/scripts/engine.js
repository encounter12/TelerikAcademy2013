/*global Kinetic, Data, solarSystem */
var engine = (function() {
	var engine = new Engine(),
		isRunning = true,
		stage = new Kinetic.Stage({
			container: 'container',
			width: 1200,
			height: 720
		});

	// The Engine is Singleton 
	function Engine() {
		// Use it like: engine.layer.add(rect)
		this.layer = new Kinetic.Layer();

		// Stage should not be changed, only get it
		this.getStage = function() {
			return stage;
		};

		// Initialize engine and graphics (to be called ONLY ONCE!!!)
		this.init = function() {
			solarSystem.init(Data.collection);
			this.stage.add(this.layer);
		};

		// Return true if engine is currently running
		this.isRunning = function() {
			return isRunning;
		};

		// Start engine
		this.start = function() {
			this.isRunning = true;
		};

		// Stop engine
		this.stop = function() {
			this.isRunning = false;
		};

		// Handle all animations, to be called as a parameter of
		// anim = new Animation(engine.animationHandler, engine.layer)
		this.animationHandler = function(frame) {
			if (!this.isRunning) {
				return;
			}

			for (var i = 0; i < solarSystem.celestialObjects.length; i += 1) {
				solarSystem.celestialObjects[i].animationFrame(frame);
			}
		};

		// Handle all onClick events, must be added to all celestialObjects as default onClick
		this.onClickHandler = function(event) {
			event = event || window.event;
			var target = event.target || event.srcElement;

			if (this.isRunning()) {
				this.stop();
			} else {
				this.start();
			}

			target.togleDisplayInfo();
		};
	}

	// To be shure that all elements are loaded before start the engine
	window.onload = function() {
		engine.init();
		engine.start();
	};

	// Make engine a global variable
	return engine;
})();