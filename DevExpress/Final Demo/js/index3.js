$(function () {
    // Initialize File Uploaders
    $("#photoUpload").dxFileUploader({
        selectButtonText: "Select photo",
        labelText: "or drag",
        accept: "image/*",
        uploadMode: "useButtons",
        maxFileSize: 5000000, // 5 MB
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        uploadFailedMessage: "Upload Failed...",
        uploadedMessage: "Uploaded...",
        readyToUploadMessage: 'click to upload...',
        invalidFileExtensionMessage: "Not a valid File",
        invalidMaxFileSizeMessage: "FileSize is too Max..."
    });

    $("#signatureUpload").dxFileUploader({ 
        selectButtonText: "Select signature",
        labelText: "or drag",
        accept: "image/*",
        uploadMode: "useButtons",
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        uploadFailedMessage: "Upload Failed...",
        uploadedMessage: "Uploaded...",
        readyToUploadMessage: 'click to upload...',
        invalidFileExtensionMessage: "Not a valid File",
        invalidMaxFileSizeMessage: "FileSize is too Max...",
        maxFileSize: 2000000 // 2 MB
    });

    $("#marksheetUpload").dxFileUploader({
        selectButtonText: "Select marksheet",
        labelText: "or drag",
        accept: ".pdf, .jpg, .jpeg, .png",
        uploadMode: "useButtons",
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        uploadFailedMessage: "Upload Failed...",
        uploadedMessage: "Uploaded...",
        readyToUploadMessage: 'click to upload...',
        invalidFileExtensionMessage: "Not a valid File",
        invalidMaxFileSizeMessage: "FileSize is too Max...",
        maxFileSize: 10000000 // 10 MB
    });

    $("#certificateUpload").dxFileUploader({
        labelText: "or drag",
        accept: ".pdf, .jpg, .jpeg, .png",
        uploadMode: "useButtons",
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        uploadFailedMessage: "Upload Failed...",
        uploadedMessage: "Uploaded...",
        readyToUploadMessage: 'click to upload...',
        invalidFileExtensionMessage: "Not a valid File",
        invalidMaxFileSizeMessage: "FileSize is too Max...",
        maxFileSize: 10000000 // 10 MB
    });

    // Handle form submission with validation
    $("#submitButtonContainer").dxButton({
        text: "Submit",
        type: "default",
        onClick: function () {
            var isValid = true;
            var fileUploaders = [
                { id: "#photoUpload", errorId: "#photoUploadError", required: true },
                { id: "#signatureUpload", errorId: "#signatureUploadError", required: true },
                { id: "#marksheetUpload", errorId: "#marksheetUploadError", required: true },
                { id: "#certificateUpload", errorId: "#certificateUploadError", required: false }
            ];

            fileUploaders.forEach(function (uploader) {
                var instance = $(uploader.id).dxFileUploader("instance");
                var files = instance.option("value");
                var errorMessage = "";

                if (uploader.required && files.length === 0) {
                    isValid = false;
                    errorMessage = "This field is required.";
                } 

                $(uploader.errorId).text(errorMessage);
            });

            if (isValid) {
                window.location.href = "submit.html";
            }
        }
    });
});
