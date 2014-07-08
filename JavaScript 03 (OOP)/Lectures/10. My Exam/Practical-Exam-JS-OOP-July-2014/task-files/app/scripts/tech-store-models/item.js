define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(typeValue, name, price) {
            this._type = validateType(typeValue);
            this._name = validateName(name);
            this._price = validatePrice(price);
        }
        function validateType(typeValue) {
            var TypeEnum = {
                "accessory": "accessory",
                "smart-phone": "smart-phone",
                "notebook": "notebook",
                "pc": "pc",
                "tablet": "tablet"
            },
                isTypeValueCorrect = false,
                i,
                len;

            for (var prop in TypeEnum) {
                if (typeValue === prop) {
                    return typeValue;
                }
            }
            if (!isTypeValueCorrect) {
                throw new TypeError("The item type is not correct!");
            }
        }
        function validateName(name) {
            if (name.length < 6 || name.lenght > 40) {
                throw new RangeError("The name string length is out of range!");
            }
            return name;
        }
        function validatePrice(price) {
            if (!isFinite(price)) {
                throw new TypeError("The price is not a valid decimal floating-point number!");
            }
            return price;
        }
        Item.prototype = {
            getData: function () {
                return {
                    content: this._content
                };
            }
        };
        return Item;
    })();
    return Item;
});