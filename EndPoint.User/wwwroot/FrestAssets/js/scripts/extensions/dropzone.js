///*=========================================================================================
//    File Name: dropzone.js
//    Description: dropzone
//==========================================================================================*/


window.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("select-files");
    const selectBtn = document.getElementById("select-btn");
    const dropzone = document.getElementById("dropzone-area");
    const previewContainer = document.getElementById("preview-container");
    let allFiles = [];

    // 📂 باز کردن File Picker
    selectBtn.addEventListener("click", () => input.click());

    // 🔹 انتخاب فایل از دکمه یا ورودی
    input.addEventListener("change", () => addFiles(input.files));

    // 🔹 Drag & Drop
    dropzone.addEventListener("dragover", (e) => {
        e.preventDefault();
        dropzone.style.backgroundColor = "#e9f5ff";
    });
    dropzone.addEventListener("dragleave", (e) => {
        e.preventDefault();
        dropzone.style.backgroundColor = "";
    });
    dropzone.addEventListener("drop", (e) => {
        e.preventDefault();
        dropzone.style.backgroundColor = "";
        addFiles(e.dataTransfer.files);
    });

    // ➕ افزودن فایل‌ها
    function addFiles(newFiles) {
        for (const file of newFiles) {
            if (!allFiles.some(f => f.name === file.name && f.size === file.size)) {
                allFiles.push(file);
            }
        }
        updateInputFiles();
        renderPreview();
    }

    // 🧾 بروزرسانی input.files
    function updateInputFiles() {
        const dataTransfer = new DataTransfer();
        allFiles.forEach(file => dataTransfer.items.add(file));
        input.files = dataTransfer.files;
    }

    // 🎨 نمایش پیش‌نمایش‌ها
    function renderPreview() {
        previewContainer.innerHTML = "";
        allFiles.forEach((file, index) => {
            if (!file.type.startsWith("image/")) return;
            const item = document.createElement("div");
            item.classList.add("preview-item");

            const img = document.createElement("img");
            img.src = URL.createObjectURL(file);

            const btn = document.createElement("button");
            btn.innerHTML = "×";
            btn.classList.add("remove-btn");
            btn.addEventListener("click", () => removeFile(index));

            item.appendChild(img);
            item.appendChild(btn);
            previewContainer.appendChild(item);
        });
    }

    // ❌ حذف فایل
    function removeFile(index) {
        allFiles.splice(index, 1);
        updateInputFiles();
        renderPreview();
    }
});
//Dropzone.autoDiscover = false;
//new Dropzone("#dpz-btn-select-files", {
//    clickable: "#select-files",
//    autoProcessQueue: false, // ✅ نمی‌فرسته
//    uploadMultiple: true,
//    parallelUploads: 5,
//    addRemoveLinks: true,
//    dictRemoveFile: "حذف فایل",
//    dictDefaultMessage: "فایل‌ها را بکشید یا انتخاب کنید"
//});

//Dropzone.options.dpzSingleFile = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFiles: 1,
//    init: function () {
//        this.on("maxfilesexceeded", function (file) {
//            this.removeAllFiles();
//            this.addFile(file);
//        });
//    }
//};

///********************************************
// *               Multiple Files              *
// ********************************************/
//Dropzone.options.dpzMultipleFiles = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFilesize: 0.5, // MB
//    clickable: true
//}


///********************************************************
// *               Use Button To Select Files              *
// ********************************************************/
////Dropzone.options.dpzBtnSelectFiles =
////{
////    url: "", // Set the url
////    previewsContainer: "#dpz-btn-select-files", // Define the container to display the previews
////    clickable: "#select-files"
////}

//Dropzone.autoDiscover = false;
//new Dropzone(document.body, { // Make the whole body a dropzone

//	previewsContainer: "#dpz-btn-select-files", // Define the container to display the previews
//	clickable: "#select-files" // Define the element that should be used as click trigger to select files.
//});




///****************************************************************
// *               Limit File Size and No. Of Files                *
// ****************************************************************/
//Dropzone.options.dpzFileLimits = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFilesize: 0.5, // MB
//    maxFiles: 5,
//    maxThumbnailFilesize: 1, // MB
//}


///********************************************
// *               Accepted Files              *
// ********************************************/
//Dropzone.options.dpAcceptFiles = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFilesize: 1, // MB
//    acceptedFiles: 'image/*'
//}


///************************************************
// *               Remove Thumbnail                *
// ************************************************/
//Dropzone.options.dpzRemoveThumb = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFilesize: 1, // MB
//    addRemoveLinks: true,
//    dictRemoveFile: " حذف"
//}

///*****************************************************
// *               Remove All Thumbnails                *
// *****************************************************/
//Dropzone.options.dpzRemoveAllThumb = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFilesize: 1, // MB
//    init: function () {

//        // Using a closure.
//        var _this = this;

//        // Setup the observer for the button.
//        $("#clear-dropzone").on("click", function () {
//            // Using "_this" here, because "this" doesn't point to the dropzone anymore
//            _this.removeAllFiles();
//            // If you want to cancel uploads as well, you
//            // could also call _this.removeAllFiles(true);
//        });
//    }
//}