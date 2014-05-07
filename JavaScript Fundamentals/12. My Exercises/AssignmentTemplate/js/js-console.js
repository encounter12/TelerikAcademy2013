(function () {
    function createJsConsole(selector) {
        var self = this;
        var consoleElement = document.querySelector(selector);

        if (consoleElement.className) {
            consoleElement.className = consoleElement.className + " js-console";
        }
        else {
            consoleElement.className = "js-console";
        }

        var textArea = document.createElement("p");
        consoleElement.appendChild(textArea);

        self.write = function jsConsoleWrite(text) {
            var textLine = document.createElement("span");
            textLine.innerHTML = text;
            textArea.appendChild(textLine);
            consoleElement.scrollTop = consoleElement.scrollHeight;
        }

        self.writeLine = function jsConsoleWriteLine(text) {
            self.write(text);
            textArea.appendChild(document.createElement("br"));
        }

        self.read = function readText(inputSelector) {
            var element = document.querySelector(inputSelector);
            if (element.innerHTML) {
                return element.innerHTML;
            }
            else {
                return element.value;
            }
        }

        self.readInteger = function readInteger(inputSelector) {
            var text = self.read(inputSelector);
            return parseInt(text);
        }

        self.readFloat = function readFloat(inputSelector) {
            var text = self.read(inputSelector);
            return parseFloat(text);
        }

        self.clear = function jsConsoleClear() {
            var console = document.getElementById("js-console");
            while (console.lastChild) {
                console.removeChild(console.lastChild);
            }

            var nodes = document.querySelectorAll("input[type=text]");
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].value = "";
            }
        }

        self.clearTextFields = function jsConsoleClearTextFields() {
            var nodes = document.querySelectorAll("input[type=text]");
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].value = "";
            }
        }

        self.clearAll = function jsConsoleClearAll() {
            var console = document.getElementById("js-console");
            while (console.lastChild) {
                console.removeChild(console.lastChild);
            }

            var nodes = document.querySelectorAll("input[type=text]");
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].value = "";
            }

        }

        self.searchKeyPress = function searchKeyPress(e) {
            if (typeof e === "undefined" && window.event) {
                e = window.event;
            }
            if (e.keyCode === 13) {
                document.getElementById("process").click();
                jsConsole = new createJsConsole("#js-console");
                return false;
            }
            if (e.keyCode === 27) {
                document.getElementById("clear").click();
                jsConsole = new createJsConsole("#js-console");
                return false;
            }
        }

        return self;
    }
    jsConsole = new createJsConsole("#js-console");
}).call(this);