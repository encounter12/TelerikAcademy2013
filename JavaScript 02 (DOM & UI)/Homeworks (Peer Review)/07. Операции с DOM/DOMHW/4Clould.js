function generateClould(tags,minFont,maxFont) {
    var tagCount = {};
    var length = tags.length;
    var max = 0;
    for (var i = 0; i < length; i++) {
        if (typeof (tagCount[tags[i]]) == "undefined") {
            tagCount[tags[i]] = 1;
        } else {
            tagCount[tags[i]]++;
        }
        if (tagCount[tags[i]] > max) {
            max = tagCount[tags[i]];
        }
    }

    //count to font
    for (var tag in tagCount) {
        tagCount[tag] = tagCount[tag] * (maxFont - minFont) + minFont;
    }

    var divContainer = document.createElement("div");
    for (var tag in tagCount) {
        var tagContainer = document.createElement("div");
        tagContainer.style.fontSize = tagCount[tag] + "px";
        tagContainer.innerText = tag;
        tagContainer.style.cssFloat = "left";
        divContainer.appendChild(tagContainer);
    }
    return divContainer;
}
window.onload = function () {
    document.body.appendChild(generateClould(test, 8, 25));
}
var test = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];
