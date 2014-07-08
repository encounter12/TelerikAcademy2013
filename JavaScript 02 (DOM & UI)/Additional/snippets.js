var header = document.getElementById('header');
var inputs = document.getElementsByTagName('li');
var radiosGroup = document.getElementsByName('genders[]');
var posts = document.getElementsByClassName('post-item');

var nav = document.querySelector('#main-nav');
var header = document.querySelectorAll('#main-nav li'); 

selectedDiv.style.background = "#456";
var div = document.createElement("div");

element.parentNode
element.childNodes
firstChild / lastChild
firstElementChild / lastElementChild
nextSibling / nextElementSibling
previousSibling / previousElementSibling

var liElement = document.createElement("li");
console.log(liElement instanceof HTMLLIElement); //true
console.log(liElement instanceof HTMLElement); //true
console.log(liElement instanceof HTMLDivElement); //false

var studentsList = document.createElement("ul");
var studentLi = document.createElement("li");
studentsList.appendChild(studentLi);
document.body.appendChild(studentsList);
parent.insertBefore(newNode, specificElement)

var trainers = document.getElementsByTagName("ul")[0];
var trainer = trainers.getElementsByTagName("li")[0];
trainers.removeChild(trainer);

//remove a selected element
var selectedElement = //select the element
selectedElement.parentNode.removeChild(selectedElement);

var div = document.getElementById("content");
div.style.display = "block";
div.style.width = "123px";
container.className += ' dropdown-list';

dFrag = document.createDocumentFragment();
dFrag.appendChild(div);
document.body.appendChild(dFrag);

var clonedNode = someElement.cloneNode(true);

if (element.nodeName == "#text")
content = element.textContent.trimChars("\n \t")

domElement.addEventListener(eventType, eventHandler, isCaptureEvent)
upButton.addEventListener("click", onUpButtonClick, false);

var event = new CustomEvent("tripleClick"); 
var body = document.getElementsByTagName("body")[0];
body.addEventListener("tripleClick", function() {
	alert("You click three times");
}, false);
body.dispatchEvent(event);

var l = document.getElementById('my-link');
l.onclick();