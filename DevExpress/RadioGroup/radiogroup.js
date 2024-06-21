$(function () {
    var stylingMode = "outlined"; // Default styling mode
    var backgroundColor = "white"; // Default background color
    var foregroundColor = "black"; // Default foreground color
    var selectedButtonType = "Default"; // Default selected button type

    // Initialize the RadioGroup for button type selection
    $("#radioGroupButtonType").dxRadioGroup({
        items: ["Danger", "Success", "Default", "Normal"],
        value: "Default",
        layout: "horizontal",
        onValueChanged: function (data) {
            selectedButtonType = data.value;
            updateButtonVisibility();
            updateButtonStyles();
            updateDotColor(); // Call function to update dot color
        }
    });

    // Initialize the RadioGroup for background color selection
    $("#radioGroupBackgroundColor").dxRadioGroup({
        items: ["Red", "Green", "Blue", "White"],
        value: "White",
        layout: "horizontal",
        onValueChanged: function (data) {
            backgroundColor = data.value.toLowerCase();
            updateButtonStyles();
        }
    });

    // Initialize the RadioGroup for foreground color selection
    $("#radioGroupForegroundColor").dxRadioGroup({
        items: ["Black", "White", "Yellow", "Gray"],
        value: "Black",
        layout: "horizontal",
        onValueChanged: function (data) {
            foregroundColor = data.value.toLowerCase();
            updateButtonStyles();
        }
    });

    // Initialize the SelectBox for styling mode
    $("#stylingModeSelectBox").dxSelectBox({
        items: ["text", "outlined", "contained"],
        value: "outlined",
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
        elementAttr: {
            style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
        },
        onClick: function () {
            showToast("Danger button clicked", "error"); // "error" type for danger
        }
    });
    $("#successButton").dxButton({
        text: "Success Button",
        type: "success",
        stylingMode: stylingMode,
        elementAttr: {
            style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
        },
        onClick: function () {
            showToast("Success button clicked", "success"); // "success" type for success
        }
    });
    $("#defaultButton").dxButton({
        text: "Default Button",
        type: "default",
        stylingMode: stylingMode,
        elementAttr: {
            style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
        },
        onClick: function () {
            showToast("Default button clicked", "info"); // "info" type for default
        }
    });
    $("#normalButton").dxButton({
        text: "Normal Button",
        type: "normal",
        stylingMode: stylingMode,
        elementAttr: {
            style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
        },
        onClick: function () {
            showToast("Normal button clicked", "info"); // "info" type for normal
        }
    });

    // Function to update the visibility of the selected button
    function updateButtonVisibility() {
        $("#buttons > div").hide();
        switch (selectedButtonType) {
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

    // Function to update the styling mode and colors of the selected button
    function updateButtonStyles() {
        switch (selectedButtonType) {
            case "Danger":
                $("#dangerButton").dxButton("instance").option({
                    stylingMode: stylingMode,
                    elementAttr: {
                        style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
                    }
                });
                break;
            case "Success":
                $("#successButton").dxButton("instance").option({
                    stylingMode: stylingMode,
                    elementAttr: {
                        style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
                    }
                });
                break;
            case "Default":
                $("#defaultButton").dxButton("instance").option({
                    stylingMode: stylingMode,
                    elementAttr: {
                        style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
                    }
                });
                break;
            case "Normal":
                $("#normalButton").dxButton("instance").option({
                    stylingMode: stylingMode,
                    elementAttr: {
                        style: `background-color: ${backgroundColor}; color: ${foregroundColor}`
                    }
                });
                break;
        }
    }

    // Function to update the dot color based on selected type
    function updateDotColor() {
        // Remove previous color class
        $(".dx-radiobutton-icon-dot").removeClass("success");

        // Add appropriate class based on selectedButtonType
        switch (selectedButtonType) {
            case "Danger":
                // Handle color change for Danger if needed
                break;
            case "Success":
                $(".dx-radiobutton.success .dx-radiobutton-icon-dot").addClass("success");
                break;
            case "Default":
                // Handle color change for Default if needed
                break;
            case "Normal":
                // Handle color change for Normal if needed
                break;
        }
    }

    // Initial call to set the initial state
    updateButtonVisibility();
    updateButtonStyles();
    updateDotColor();
});
