window.onload = function () {
    createTreeView("myTree");
}
function createTreeView(id) {
    var treeView = document.getElementById(id);
    var unorderedLists = treeView.getElementsByTagName("ul");
    var length = unorderedLists.length;
    for (var i = 0; i < length; i++) {
        createTree(unorderedLists[i]);
    }
    createTree(treeView);
    function createTree(node) {
        //hide all content in the div's
        var items = node.children;
        var length = items.length;
        for (var i = 0; i < length; i++) {
            hide(items[i]);
            //THis needs refactoring
            items[i].setAttribute("hidenContent", "true");
            items[i].onclick = function (e) {
                event.stopPropagation();
                if (this.getAttribute("hidenContent") == "true") {
                    show(this);
                } else {
                    hide(this);
                }
            };
        }

    }
    function show(node) {
        
        node.setAttribute("hidenContent", "");
        var childDivs = node.children;
        var len = childDivs.length;
        for (var i = 0; i < len; i++) {
            if (childDivs[i].classList.contains("tree-content")) {
                childDivs[i].style.display = "";
            }
        }
    }
    function hide(node) {
        node.setAttribute("hidenContent", "true");
        var childDivs = node.children;
        var len = childDivs.length;
        for (var i = 0; i < len; i++) {
            if (childDivs[i].classList.contains("tree-content")) {
                childDivs[i].style.display = "none";
            }
        }
    }
}
