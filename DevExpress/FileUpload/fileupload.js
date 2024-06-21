$(function () {
    // Initialize the FileUploader
    $("#fileUploaderContainer").dxFileUploader({
        selectButtonText: "Select Photo",
        labelText: "or drag a photo",
        accept: "image/*",
        allowedFileExtensions: ['.jpg','.jpeg' ,'.png'],
        multiple: true,
        uploadMode: "useButtons", //Accept instantly,
        minFileSize: 40000,
        maxFileSize: 10000000,
        uploadButtonText: "submit...",
        uploadFailedMessage:"Upload Failed...",
        uploadedMessage:"Uploaded...",
        readyToUploadMessage:'click to upload...',
        invalidFileExtensionMessage:"Not a valid File",
        invalidMaxFileSizeMessage:"FileSize is too Max...",
        invalidMinFileSizeMessage:"FileSize is too small...",
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        onValueChanged: function (e) {
            var file = e.value[0];
            if (file) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("#uploadedPhoto").attr("src", e.target.result);
                    $("#uploadedPhoto").show();
                };
                reader.readAsDataURL(file);
            } else {    
                $("#uploadedPhoto").attr("src", "");
                $("#uploadedPhoto").hide();
            }
            const files = e.value;
            if (files.length > 0) {
                $('#selected-files .selected-item').remove();
                $.each(files, (i, file) => {
                    const $selectedItem = $('<div />').addClass('selected-item');
                    $selectedItem.append(
                        $('<span />').html(`Name: ${file.name}<br/>`),
                        $('<span />').html(`Size ${file.size} bytes<br/>`),
                        $('<span />').html(`Type ${file.type}<br/>`),
                        $('<span />').html(`Last Modified Date: ${file.lastModifiedDate}`),
                    );
                    $selectedItem.appendTo($('#selected-files'));
                });
                $('#selected-files').show();
            } else { $('#selected-files').hide(); }
        }
    });
});