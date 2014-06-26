//JavaScript - The Definitive Guide - 9.6.2 Example: Enumerated Types

/*An enumerated type is a type with a finite set of values that are listed (or “enumerated”) when the type is defined. In C and languages derived from it, enumerated types are declared with the enum keyword. enum is a reserved (but unused) word in ECMAScript 5 which leaves open the possibility that JavaScript may someday have native enumerated types. Until then, Example 9-7 shows how you can define your own enumerated types in JavaScript. Note that it uses the inherit() function from Example  6-1. Example 9-7 consists of a single function enumeration(). This is not a constructor function, however: it does not define a class named “enumeration”. Instead, this is a factory function: each invocation creates and returns a new class. Use it like this:*/

/*It is not usually necessary to lock down prototype objects like this, but there are some circumstances where preventing extensions to an object can be useful. Think back to the enumeration() class factory function of Example 9-7. That function stored the instances of each enumerated type in properties of the constructor object, and also in the values array of the constructor. These properties and array serve as the official list of instances of the enumerated type, and it is worth freezing them, so that new instances cannot be added and existing instances cannot be deleted or altered. In the enumeration() function we can simply add these lines of code: 

Object.freeze(enumeration.values);
Object.freeze(enumeration);

Notice that by calling Object.freeze() on the enumerated type, we prevent the future use of the objectId property defined in Example 9-17. A solution to this problem is to read the objectId property (calling the underlying accessor method and setting the internal property) of the enumerated type once before freezing it.*/

// Create a new Coin class with four values: Coin.Penny, Coin.Nickel, etc.
var Coin = enumeration({Penny: 1, Nickel:5, Dime:10, Quarter:25});
var c = Coin.Dime; // This is an instance of the new class
c instanceof Coin // => true: instanceof works
c.constructor == Coin // => true: constructor property works
Coin.Quarter + 3 * Coin.Nickel // => 40: values convert to numbers
Coin.Dime == 10 // => true: more conversion to numbers
Coin.Dime > Coin.Nickel // => true: relational operators work
String(Coin.Dime) + ":" + Coin.Dime // => "Dime:10": coerce to string
The point of this example is to demonstrate that JavaScript classes are much more
flexible and dynamic than the static classes of languages like C++ and Java.


function inherit(p) {
    if (p == null) {
        throw TypeError();
    }

    if (Object.create) {
        return Object.create(p);
    }
    var t = typeof p;

    if (t !== "object" && t !== "function") {
        throw TypeError();
    }

    function f() {};
    f.prototype = p;

    return new f();
}

function enumeration(namesToValues) {
    
    var enumeration = function() { throw "Can't Instantiate Enumerations"; };
    
    var proto = enumeration.prototype = {
        constructor: enumeration,
        toString: function() { return this.name; },
        valueOf: function() { return this.value; },
        Object.freeze(enumeration.values);
        Object.freeze(enumeration);
        toJSON: function() { return this.name; }
    };
    enumeration.values = [];

    for(name in namesToValues) { 
        var e = inherit(proto);
        e.name = name;
        e.value = namesToValues[name];
        enumeration[name] = e;
        enumeration.values.push(e);
    }

    enumeration.foreach = function(f,c) {
        for(var i = 0; i < this.values.length; i++) {
            f.call(c,this.values[i]);
        }
    };

    return enumeration;
}


//Example: 


function Card(suit, rank) {
    this.suit = suit; // Each card has a suit
    this.rank = rank; // and a rank
}


Card.Suit = enumeration({Clubs: 1, Diamonds: 2, Hearts:3, Spades:4});
Card.Rank = enumeration({Two: 2, Three: 3, Four: 4, Five: 5, Six: 6, Seven: 7, Eight: 8, Nine: 9, Ten: 10, Jack: 11, Queen: 12, King: 13, Ace: 14});

Card.prototype.toString = function() {
    return this.rank.toString() + " of " + this.suit.toString();
};

Card.prototype.compareTo = function(that) {
    if (this.rank < that.rank) {
        return -1;
    }
    if (this.rank > that.rank) {
        return 1;
    }
    return 0;
};


Card.orderByRank = function(a,b) { 
    return a.compareTo(b); 
};

Card.orderBySuit = function(a,b) {
    if (a.suit < b.suit) {
        return -1;
    }
    if (a.suit > b.suit) {
        return 1;
    }
    if (a.rank < b.rank) {
        return -1;
    }
    if (a.rank > b.rank) {
        return 1;
    }
    return 0;
};


function Deck() {
    var cards = this.cards = [];

    Card.Suit.foreach(function(s) {
        Card.Rank.foreach(function(r) {
            cards.push(new Card(s,r));
        });
    });
}
    

Deck.prototype.shuffle = function() {

    var deck = this.cards, 
        len = deck.length;

    for(var i = len-1; i > 0; i--) {
        var r = Math.floor(Math.random()*(i+1)), 
            temp;
            
            temp = deck[i], 
            deck[i] = deck[r], 
            deck[r] = temp;
    }
    return this;
};

Deck.prototype.deal = function(n) {
    if (this.cards.length < n) {
        throw "Out of cards";
    }
    return this.cards.splice(this.cards.length-n, n);
};

var deck = (new Deck()).shuffle();
var hand = deck.deal(13).sort(Card.orderBySuit);



----------------------------

//Using ENUM in JavaScript – Almost

//http://www.misfitgeek.com/using-enum-in-javascript/

var DaysOfTheWeek = { 
    "Sunday":1,
    "Monday":2,
    "Tuesday":3,
    "Wednesday":4,
    "Thursday":5,
    "Friday":6,
    "Saturday":7              
}
Object.freeze(DaysOfTheWeek);

Since JavaScript is loosely types, we could even make our pseudo-enum a collection of Object like this.
    
var SIZE = {
    SMALL : {value: 0, name: "Small", code: "S"},
    MEDIUM: {value: 1, name: "Medium", code: "M"},
    LARGE : {value: 2, name: "Large", code: "L"}
};