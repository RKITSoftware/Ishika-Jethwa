document.addEventListener("DOMContentLoaded", function () {

    var checkboxInstance = $("#checkbox1-container").dxCheckBox({
        accessKey: "A", // alt + A
        activeStateEnabled: false, // active css apply
        disabled: false,
        elementAttr: { id: "myCheckbox", class: "custom-class" },
        focusStateEnabled: true, // keyboard through focus
        height: 52,
        hint: "Check to accept terms and conditions", // hover hint
        hoverStateEnabled: false, // hover -border 
        isValid: false, // red border (not valid)   
        name: "termsCheckbox",
        readOnly: false,
        rtlEnabled: false,
        tabIndex: 0,
        text: "Accept Terms and Conditions",
        value: true,
        visible: true,
        width: 1300,

        // Event handlers
        onContentReady: function (e) {
            console.log("Content is ready");
        },
        onDisposing: function (e) {
            console.log("Component is disposing");
        },
        onInitialized: function (e) {
            console.log("Component initialized");
        },
        onOptionChanged: function (e) {
            console.log("Option changed: ", e);
        },
        onValueChanged: function (e) {
            const value = e.value;
            alert("CheckBox value changed to " + value);
        }
    }).dxCheckBox("instance");

    // Focus the CheckBox when the button is clicked
    $("#focusButton").on("click", function () {
        checkboxInstance.focus();
    });

    // Dispose of the CheckBox when the button is clicked
    $("#disposeButton").on("click", function () {
        checkboxInstance.dispose();
        console.log("CheckBox disposed");
    });

    // Update the text option when the button is clicked
    $("#updateOptionButton").on("click", function () {
        checkboxInstance.option("text", "Updated Text");
        console.log("CheckBox text updated");
    });

    // Reset the text option to its default value
    $("#resetOptionButton").on("click", function () {
        checkboxInstance.resetOption("text");
        console.log("CheckBox text reset to default");
    });

    // Demonstrate beginUpdate and endUpdate
    checkboxInstance.beginUpdate();
    checkboxInstance.option({
        disabled: false,
        visible: true
    });
    checkboxInstance.endUpdate();

    // Demonstrate registering a key handler
    checkboxInstance.registerKeyHandler("enter", function () {
        alert("Enter key pressed on CheckBox");
    });

    $("#Checked").dxCheckBox({
        height: 52,
        hint: "Checked CheckBox", // hover hint
        hoverStateEnabled: false, // hover -border 
        value: true,
        width: 1300,
    });

    $("#un-Checked").dxCheckBox({
        height: 52,
        hint: "Un-Checked CheckBox", // hover hint
        hoverStateEnabled: false, // hover -border 
        value: false,
        width: 1300,
    });
    $("#Disable").dxCheckBox({
        height: 52,
        value: true,
        width: 1300,
        disabled: true
    });
    $("#ReadOnly").dxCheckBox({
        height: 52,
        value: true,
        width: 1300,
        readOnly: true
    });
    $("#AccessKey").dxCheckBox({
        height: 52,
        value: true,
        width: 1300,
        accessKey: "S"
    });
    $("#InValid").dxCheckBox({
        height: 52,
        value: true,
        width: 1300,
        isValid: false,
        validationError: {
            message : "invalid Message"
        }

    });
    $("#Labeled").dxCheckBox({
        height: 52,
        value: true,
        width: 1300,
        text: "terms & condition"

    });
    var active = $("#Update").dxCheckBox({
        height: 52,
        value: true,
        width: 1300,
        text: "Active",
        onValueChanged: function (e) {
            const value = e.value;
            if (value == true) {
                active.option("text", "Active")
            }
            else {
                active.option("text", "DeActive")
            }
        }
    }).dxCheckBox("instance");



});