function createImagesPreviewer(selector, items) {

    var docFragment = document.createDocumentFragment();

    var leftContainer = document.createElement("div");
    leftContainer.id = "image-preview-left";
    leftContainer.style.width = "800px";
    leftContainer.style.height = "600px";
    leftContainer.style.float = "left";
    leftContainer.style.margin = "10px";
    leftContainer.style.position = "relative";
    leftContainer.style.display = "inline-block";

    var rightContainer = document.createElement("div");

    rightContainer.id = "images-container-right";
    rightContainer.style.width = "17%";
    rightContainer.style.height = "600px";
    rightContainer.style.display = "inline-block";
    rightContainer.style.margin = "10px";
    rightContainer.style.boxSizing = "border-box";
    rightContainer.style.padding = "10px";
   
   
    var imagePreview = document.createElement("img");
    imagePreview.style.width = "85%";
    imagePreview.style.height = "85%";

    imagePreview.style.borderRadius = "15px";
    imagePreview.src = items[0].url;

    var imagePreviewTitle = document.createElement("h1");
    imagePreviewTitle.innerHTML = items[0].title;


    var imagePreviewWithTitle = document.createElement("div");
    imagePreviewWithTitle.style.width = "95%";
    imagePreviewWithTitle.style.height = "90%";
    imagePreviewWithTitle.style.textAlign = "center";
    imagePreviewWithTitle.appendChild(imagePreviewTitle);


    //center imagePreview container in the parent imagePreviewContainer
    imagePreviewWithTitle.style.position = "absolute";
    imagePreviewWithTitle.style.top = "0";
    imagePreviewWithTitle.style.left = "0";
    imagePreviewWithTitle.style.bottom = "0";
    imagePreviewWithTitle.style.right = "0";
    imagePreviewWithTitle.style.margin = "auto";

    leftContainer.appendChild(imagePreviewWithTitle);

    imagePreviewWithTitle.appendChild(imagePreview);
   
    var filterForm = document.createElement("form");
    filterForm.style.width = "80%";
    filterForm.style.margin = "auto";
    filterForm.style.textAlign = "center";

    var filterLabel = document.createElement("label");
    filterLabel.innerHTML = "Filter";
    filterLabel.setAttribute("for", "filter-input-field");
    filterLabel.style.display = "block";

    var filterInputField = document.createElement("input");
    filterInputField.setAttribute("type", "text");
    filterInputField.id = "filter-input-field";
    
    filterForm.appendChild(filterLabel);
    filterForm.appendChild(filterInputField);

    rightContainer.appendChild(filterForm);
    rightContainer.style.overflowY = "scroll";

    var rightImagesWrapper = document.createElement("div");

    //creates the div elements containing the images and titles and adds them to the wrapper container
    rightImagesWrapper.appendChild(initializeImageElements(items));

    rightContainer.appendChild(rightImagesWrapper);

    docFragment.appendChild(leftContainer);
    docFragment.appendChild(rightContainer);

    var mainContainer = document.getElementById(selector.substr(1, selector.length - 1));
    mainContainer.appendChild(docFragment);


    function changePreviewImageOnClick() {
        var selectedImageTitle = this.firstChild.innerHTML;
        imagePreviewTitle.innerHTML = selectedImageTitle;

        //get clicked element index
        var parent = this.parentNode;
        var index = Array.prototype.indexOf.call(parent.children, this);

        imagePreview.src = items[index].url;
    }

    function changeBackgroundOnMouseover() {
        this.style.background = "#CBCBCB";
    }

    function clearBackgroundOnMouseout() {
        this.style.background = "white";
    }

    function removeChildNodes(parentNode) {
        while (parentNode.firstChild) {
            parentNode.removeChild(parentNode.firstChild);
        }
    }

    function initializeImageElements(items) {
        var docFragment = document.createDocumentFragment();

        for (var i = 0, len = items.length; i < len; i += 1) {

            var rightImageContainer = document.createElement("div");
            rightImageContainer.className = "images";
            rightImageContainer.style.width = "95%";
            rightImageContainer.style.marginTop = "10px";
            rightImageContainer.style.padding = "10px";
            rightImageContainer.style.borderRadius = "10px";
            rightImageContainer.addEventListener("click", changePreviewImageOnClick, false);
            rightImageContainer.addEventListener("mouseover", changeBackgroundOnMouseover, false);
            rightImageContainer.addEventListener("mouseout", clearBackgroundOnMouseout, false);

            var imageTtitle = document.createElement("h3");
            imageTtitle.innerHTML = items[i].title;
            imageTtitle.style.textAlign = "center";

            var rightImage = document.createElement("img");
            rightImage.src = items[i].url;
            rightImage.style.width = "180px";
            rightImage.style.height = "150px";
            rightImage.style.borderRadius = "8px";
            rightImage.style.display = "block";
            rightImage.style.margin = "auto";
            rightImageContainer.appendChild(imageTtitle);
            rightImageContainer.appendChild(rightImage);
            docFragment.appendChild(rightImageContainer);
        }
        return docFragment;
    }
}