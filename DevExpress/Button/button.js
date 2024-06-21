$(function () {
    var stylingMode = "contained"; // Default styling mode

    // Initialize the SelectBox for button type
    $("#selectBox").dxSelectBox({
        items: ["Danger", "Success", "Default", "Normal"],
        value: "Default",
        onValueChanged: function (data) {
            // Hide all buttons initially
            $("#buttons > div").hide();
            // Show the selected button
            switch (data.value) {
                case "Danger":
                    $("#dangerButton").show();
                    break;
                case "Success":
                    $("#successButton").show();
                    break;
                case "Default":
                    $("#defaultButton").show();
                    break;
                case "Normal":
                    $("#normalButton").show();
                    break;
            }
        }
    });

    // Initialize the SelectBox for styling mode
    $("#stylingModeSelectBox").dxSelectBox({
        items: ["text", "outlined", "contained"],
        value: "contained",
        onValueChanged: function (data) {
            stylingMode = data.value;
            updateButtonStyles();
        }
    });

    // Function to show a toast notification
    function showToast(message, type) {
        $("#toastContainer").dxToast({
            message: message,
            type: type, // This will determine the color and icon
            displayTime: 2000,
            position: {
                my: 'center bottom',
                at: 'center bottom'
            }
        }).dxToast("show");
    }

    // Initialize the buttons with click handlers
    $("#dangerButton").dxButton({
        text: "Danger Button",
        type: "danger",
        stylingMode: stylingMode,
        onClick: function () {
            showToast("Danger button clicked", "error"); // "error" type for danger
        }
    });
    $("#successButton").dxButton({
        text: "Success Button",
        type: "success",
        stylingMode: stylingMode,
        onClick: function () {
            showToast("Success button clicked", "success"); // "success" type for success
        }
    });
    $("#defaultButton").dxButton({
        text: "Default Button",
        type: "default",
        stylingMode: stylingMode,
        onClick: function () {
            showToast("Default button clicked", "info"); // "info" type for default
        }
    });
    $("#normalButton").dxButton({
        text: "Normal Button",
        type: "normal",
        stylingMode: stylingMode,
        onClick: function () {
            showToast("Normal button clicked", "info"); // "info" type for normal
        }
    });

    // Function to update the styling mode of all buttons
    function updateButtonStyles() {
        $("#dangerButton").dxButton("instance").option("stylingMode", stylingMode);
        $("#successButton").dxButton("instance").option("stylingMode", stylingMode);
        $("#defaultButton").dxButton("instance").option("stylingMode", stylingMode);
        $("#normalButton").dxButton("instance").option("stylingMode", stylingMode);
    }

    // Initially hide all buttons except the default one
    $("#buttons > div").hide();
    $("#defaultButton").show();
});
