var a = (function () {
    function someSetup() {
        console.log('Preparations...');
    }
    
    function actualWork() {
        console.log('Worky-worky');
    }
    someSetup();
    return actualWork;
}());


a();
a();
a();


/*var a = (function () {
    function someSetup() {
        console.log('Preparations...');
    }
    
    function actualWork() {
        console.log('Worky-worky');
    }
    someSetup();
    return actualWork;
};*/