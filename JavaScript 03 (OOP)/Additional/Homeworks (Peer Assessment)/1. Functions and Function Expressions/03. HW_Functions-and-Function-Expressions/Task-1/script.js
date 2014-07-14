// Create a module for working with DOM. The module should have the following functionality
// 		Add DOM element to parent element given by selector
// 		Remove element from the DOM  by given selector
// 		Attach event to given selector by given event type and event hander
// 		Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
// 		The buffer contains elements for each selector it gets
// 		Get elements by CSS selector

var button;
var div;
var li;

// Test of domModule.appendToBuffer
function fillBuffer()
{
	domModule.appendToBuffer('#wrapper', div.cloneNode(true));
	domModule.appendToBuffer('#wrapper', div.cloneNode(true));
	domModule.appendToBuffer('#wrapper', div.cloneNode(true));

	for (var index = 0; index < 118; index += 1)
	{
		domModule.appendToBuffer('#list-wrapper', li.cloneNode(true));
	}
}

var domModule = (function (){
	var buffer = [];
	var i;
	
	function appendChild(selector, child){
		var target = document.querySelector(selector);
		target.appendChild(child);
	}
	
	function removeChild(selector, child){
		var target = document.querySelector(selector);
		if (target.children.length > 0)
		{		
			target.removeChild(child);
		}
		else
		{
			alert("OOOPPPS");
		}
	}

	function addHandler(selector, event, handler){
		var target = document.querySelector(selector);
		
		target.addEventListener(event, handler);
	}

	function appendToBuffer (selector, child){
		if (buffer.length < 100)
		{
			buffer.push([selector, child]);
		}
		else
		{
			buffer.push([selector, child]);
			
			// code to add elements in DOM
			for (i = 0; i < buffer.length; i += 1)
			{
				appendChild(buffer[i][0], buffer[i][1]);
			}
			
			buffer = [];
		}
		
	}
	
	return {
		appendChild: appendChild,
		removeChild: removeChild,
		addHandler: addHandler,
		appendToBuffer: appendToBuffer
	}
})();

div = document.createElement('div');
div.innerHTML = 'New div added to #wrapper';
div.style.border = '1px solid gray';
div.style.marginBottom = '5px';
div.style.marginTop = '5px';

domModule.addHandler('button#addDiv', 'click', function(){domModule.appendChild('#wrapper', div.cloneNode(true))});
domModule.addHandler('button#removeLi', 'click', function(){domModule.removeChild('#list-wrapper', document.querySelector('li'))});
domModule.addHandler('button#fillBuffer', 'click', fillBuffer);

li = document.createElement('li')
li.innerHTML = 'New LI element';


