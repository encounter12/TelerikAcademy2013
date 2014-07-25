define(function() {
    var StorageObjectExtensions;

    StorageObjectExtensions = (function() {
        if (!Storage.prototype.setObject) {
            Storage.prototype.setObject = function setObject(key, object) {
                var jsonObject = JSON.stringify(object);
                this.setItem(key, jsonObject);
            };
        }

        if (!Storage.prototype.getObject) {
            Storage.prototype.getObject = function getObject(key) {
                var jsonObject = this.getItem(key);
                var object = JSON.parse(jsonObject);
                return object;
            };
        }
    }());

    return StorageObjectExtensions;
});