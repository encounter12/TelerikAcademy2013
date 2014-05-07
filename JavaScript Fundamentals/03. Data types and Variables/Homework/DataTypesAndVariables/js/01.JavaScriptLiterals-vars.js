var intLit = 15;
var floatLit = 12.3;
var stringLit = "Some text";
var booleanLit = true;

//JSON function for creating a person object
function buildPerson(fname, lname, age) {
    "use strict";
    return {
        fname: fname,
        lname: lname,
        age: age,
        toString: function () { return this.fname + " " + this.lname + ", Age: " + this.age; }
    };
}

var doe = buildPerson("John", "Doe", 32);
var arr = [2, 4, 5, 3, 7];