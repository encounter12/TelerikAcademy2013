define(['tech-store-models/item'], function (Item) {
    var Store = (function () {

        function Store(name) {
            this._items = [];
            this._name = validateName(name);
        }
        function validateName(name) {
            if (name.length < 6 || name.lenght > 40) {
                throw new RangeError("The name string length is out of range!");
            }
            return name;
        }
        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw new Error(
                        "Trying to add an object that is not an instance of Student"
                    );
                }
                this._items.push(item);
                return this;
            },

            getAll: function () {
                var i,
                    len = this._items.length;
                if (len > 1) {
                    this._items.sort(function (a, b) {
                        if (a._name > b._name) {
                            return 1;
                        }
                        if (a._name < b._name) {
                            return -1;
                        }
                        return 0;
                    });
                }
                return this._items;
            },

            getSmartPhones: function () {
                var smartPhones = [],
                    i,
                    len = this._items.length,
                    copiedItems = this._items.slice(0);

                for (i = 0; i < len; i += 1) {
                    if (this._items[i]._type === "smart-phone") {
                        smartPhones.push(this._items[i]);
                    }
                }
                sortByName(smartPhones);
                function sortByName(elements) {
                    if (elements.len > 1) {
                        elements.sort(
                            function (a, b) {
                                if (a._name > b._name) {
                                    return 1;
                                }
                                if (a._name < b._name) {
                                    return -1;
                                }
                                return 0;
                            }
                        );
                    }
                }
                return smartPhones;
            },
            getMobiles: function () {

            },

            getComputers: function () {

            },

            filterItemsByType: function (filterType) {

            },

            filterItemsByPrice: function (options) {

            },

            countItemsByType: function () {

            },

            filterItemsByName: function (partOfName) {

            }
        };

        return Store;
    }());


    return Store;
});