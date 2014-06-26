function setName (obj, newName) {
    obj.name = newName;
}

var person = {
    name: "John Doe",
    age: 36
}


console.log(person.name);

setName.call(null, person, "Michael Jordan");

console.log(person.name);