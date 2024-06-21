$(function () {
    function restrictInput(e) {
        var key = e.key;
        if (/[^a-zA-Z]/.test(key)) {
            e.preventDefault();
        }
    }

    function restrictInputToNumbers(e) {
        var key = e.key;
        if (/[^0-9]/.test(key) && !["Backspace", "Delete", "ArrowLeft", "ArrowRight"].includes(key)) {
            e.preventDefault();
        }
    }

    function capitalizeFirstLetter(word) {
        return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
    }

    function capitalizeInput(e) {
        var input = $(e.target);
        var value = input.val();
        var capitalizedValue = value.split(' ').map(capitalizeFirstLetter).join(' ');
        input.val(capitalizedValue);
    }

    // Initialize DevExtreme components for the form fields
    $("#firstname").dxTextBox({
        placeholder: "Firstname",
        showClearButton: true,
        width: 700,
        onContentReady: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInput);
            input.on('focusout', capitalizeInput);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "First name is required"
        }]
    });

    $("#middlename").dxTextBox({
        placeholder: "Middlename",
        showClearButton: true,
        width: 700,
        onContentReady: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInput);
            input.on('focusout', capitalizeInput);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "First name is required"
        }]
    });

    $("#lastname").dxTextBox({
        placeholder: "Lastname",
        showClearButton: true,
        width: 700,
        onContentReady: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInput);
            input.on('focusout', capitalizeInput);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Last name is required"
        }]
    });

    $("#dateOfBirth").dxDateBox({
        placeholder: "Date of birth",
        type: "date",
        min: new Date(1950, 0, 1),
        max: new Date(2007, 0, 1),
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Date of birth is required"
        }]
    });

    $("#category").dxRadioGroup({
        items: ["General", "SC", "ST", "OBC"],
        value: "General",
        layout: "horizontal",
    });

    const religion = [
        {
            id: 1,
            name: "Hindu"
        },
        {
            id: 2,
            name: "Christianity"
        },
        {
            id: 3,
            name: "Islam"
        },
        {
            id: 4,
            name: "Buddhism"
        },
        {
            id: 5,
            name: "Judaism"
        },
        {
            id: 6,
            name: "Sikhism"
        },
        {
            id: 7,
            name: "Other"
        }
    ];
    $("#religion").dxDropDownBox({
        value: religion[0].id,
        valueExpr: "id",
        placeholder: "Select your religion",
        displayExpr: "name",
        showClearButton: true,
        width: 700,
        dataSource: religion,
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (item) {
                    var $itemDiv = $("<div>");
                    var $nameSpan = $("<span>").text(item.name);
                    $itemDiv.append($nameSpan);
                    return $itemDiv;
                },
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData.id);
                    e.component.close();
                }
            });
            return $list;

        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Religion is required"
        }]
    });

    $("#caste").dxTextBox({
        placeholder: "Caste",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Caste is required"
        }]
    });

    $("#nationality").dxSelectBox({
        placeholder: "Select your nationality",
        showClearButton: true,
        width: 700,
        items: ["American", "British", "Canadian", "Australian", "Indian", "Other"],
        value: "Indian",
        acceptCustomValue: true,
        onValueChanged: function (e) {
            var selectedNationality = e.value;
            var countryCode = countryCodeMap[selectedNationality] || "";
            $("#candidatePhoneCountryCode").dxTextBox("instance").option("value", countryCode);
            $("#parentPhoneCountryCode").dxTextBox("instance").option("value", countryCode);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "nationality is required"
        }]
    });
    const data = [
        {
            key: "United States",
            items: [
                { stateName: "California" },
                { stateName: "New York" },
                { stateName: "Texas" },
                { stateName: "Florida" }
            ]
        },
        {
            key: "United Kingdom",
            items: [
                { stateName: "England" },
                { stateName: "Scotland" },
                { stateName: "Wales" },
                { stateName: "Northern Ireland" }
            ]
        },
        {
            key: "Canada",
            items: [
                { stateName: "Ontario" },
                { stateName: "Quebec" },
                { stateName: "British Columbia" },
                { stateName: "Alberta" }
            ]
        },
        {
            key: "Australia",
            items: [
                { stateName: "New South Wales" },
                { stateName: "Victoria" },
                { stateName: "Queensland" },
                { stateName: "Western Australia" }
            ]
        },
        {
            key: "India",
            items: [
                { stateName: "Gujrat" },
                { stateName: "Maharashtra" },
                { stateName: "Karnataka" },
                { stateName: "Tamil Nadu" },
                { stateName: "Uttar Pradesh" }
            ]
        }
    ];
    $("#stateOfDomicile").dxSelectBox({
        searchEnabled: true,
        noDataText: "Nathi data malto...",
        searchExpr: ["key", "stateName"],
        searchMode: 'contains',
        searchTimeout: 200,
        minSearchLength: 1,
        showDataBeforeSearch: true,
        showClearButton: true,
        width: 700,
        acceptCustomValue: true,
        displayExpr: "stateName",
        dataSource: data,
        grouped: true,
        itemTemplate: function (data) {
            return data.stateName;  // Template to display state name
        },
        onInitialized: function (e) {
            e.component.getDataSource().load();
        },
        onCustomItemCreating: function (e) {
            var selectBoxW = e.component;
            var customValue = e.text;
            var itemExists = data.some(item => item.items.some(subItem => subItem.stateName === customValue));
            if (itemExists) {
                e.customItem = {
                    "stateName": customValue,
                    "key": "United States"
                };
                return;
            }
            selectBoxW.getDataSource().store()._array.push({
                stateName: customValue,
                key: "Custom"
            });
            selectBoxW.getDataSource().reload();

            e.customItem = {
                stateName: customValue,
                key: "Custom"
            }
        },
        valueExpr: "stateName",
       
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Domicile State is required"
        }]
    });


    $("#bloodGroup").dxTextBox({
        placeholder: "Blood Group",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Blood Group is required"
        }]
    });

    $("#aadhar").dxTextBox({
        width: 700,
        mask: "0000-0000-0000-0000",
        maskInvalidMessage: "Invalid Aadhar card number",
        useMaskedValue: true,
        maskRules: { "X": /[02-9]/ }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Aadhar number is required"
        }]
    });

    $("#gender").dxRadioGroup({
        items: ["Female", "Male", "Other"],
        value: "Female",
        layout: "horizontal"
    });

    $("#email").dxTextBox({
        placeholder: "Email ID",
        showClearButton: true,
        mode: "email",
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Email is required"
        }, {
            type: "email",
            message: "Email is invalid"
        }]
    });

    $("#password").dxTextBox({
        placeholder: "Password",
        showClearButton: true,
        mode: "password",
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Password is required"
        }]
    });

    var countryCodeMap = {
        "American": "+1",
        "British": "+44",
        "Canadian": "+1",
        "Australian": "+61",
        "Indian": "+91",
        "Other": ""
    };

    $("#candidatePhoneCountryCode").dxTextBox({
        placeholder: "Country Code",
        value: "+91",
        maxLength: 4,
        width: 65,
        onInput: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInputToNumbers);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Country Code is required"
        }]
    });

    $("#candidatePhoneNumber").dxTextBox({
        placeholder: "Phone Number",
        maxLength: 10,
        width: 620,
        onInput: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInputToNumbers);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Candidate's phone number is required"
        }, {
            type: "pattern",
            pattern: "^[0-9]{10}$",
            message: "Phone number must be 10 digits"
        }]
    });

    $("#parentPhoneCountryCode").dxTextBox({
        placeholder: "Country Code",
        value: "+91",
        maxLength: 3,
        width: 65,
        onInput: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInputToNumbers);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Country Code is required"
        }]
    });

    $("#parentPhoneNumber").dxTextBox({
        placeholder: "Phone Number",
        maxLength: 10,
        width: 620,
        onInput: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInputToNumbers);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Parent's phone number is required"
        }, {
            type: "pattern",
            pattern: "^[0-9]{10}$",
            message: "Phone number must be 10 digits"
        }]
    });

    $("#address").dxTextArea({
        placeholder: "Address",
        height: 90,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Address is required"
        }]
    });

    $("#city").dxTextBox({
        placeholder: "Town/City",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "City is required"
        }]
    });

    $("#district").dxTextBox({
        placeholder: "District",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "District is required"
        }]
    });

    $("#pinCode").dxTextBox({
        placeholder: "Pin Code",
        maxLength: 6,
        minLength: 6,
        width: 700,
        onContentReady: function (e) {
            var input = e.component._input();
            input.on('keydown', restrictInputToNumbers);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Pin Code is required"
        }, {
            type: "pattern",
            pattern: "^[0-9]{6}$",
            message: "Pin Code must be 6 digits"
        }]
    });

    $("#state").dxTextBox({
        placeholder: "State",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "State is required"
        }]
    });

    $("#fatherName").dxTextBox({
        placeholder: "Father's name",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Father's name is required"
        }]
    });

    $("#motherName").dxTextBox({
        placeholder: "Mother's name",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Mother's name is required"
        }]
    });

    $("#fatherOccupation").dxTextBox({
        placeholder: "Father's occupation",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Father's occupation is required"
        }]
    });

    $("#motherOccupation").dxTextBox({
        placeholder: "Mother's occupation",
        showClearButton: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Mother's occupation is required"
        }]
    });

    $("#familyIncome").dxNumberBox({
        placeholder: "Total Family Annual Income",
        showSpinButtons: true,
        width: 700,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Total family annual income is required"
        }]
    });

    $("#submitButtonContainer").dxButton({
        text: "Submit",
        type: "default",
        onClick: function () {
            // Validate the inputs
            var validators = [
                $("#firstname").dxValidator("instance"),
                $("#lastname").dxValidator("instance"),
                $("#middlename").dxValidator("instance"),
                $("#dateOfBirth").dxValidator("instance"),
                $("#religion").dxValidator("instance"),
                $("#caste").dxValidator("instance"),
                $("#nationality").dxValidator("instance"),
                $("#stateOfDomicile").dxValidator("instance"),
                $("#bloodGroup").dxValidator("instance"),
                $("#aadhar").dxValidator("instance"),
                $("#email").dxValidator("instance"),
                $("#password").dxValidator("instance"),
                $("#candidatePhoneCountryCode").dxValidator("instance"),
                $("#candidatePhoneNumber").dxValidator("instance"),
                $("#parentPhoneCountryCode").dxValidator("instance"),
                $("#parentPhoneNumber").dxValidator("instance"),
                $("#address").dxValidator("instance"),
                $("#city").dxValidator("instance"),
                $("#district").dxValidator("instance"),
                $("#pinCode").dxValidator("instance"),
                $("#state").dxValidator("instance"),
                $("#fatherName").dxValidator("instance"),
                $("#motherName").dxValidator("instance"),
                $("#fatherOccupation").dxValidator("instance"),
                $("#motherOccupation").dxValidator("instance"),
                $("#familyIncome").dxValidator("instance")
            ];

            var isValid = true;
            validators.forEach(function (validator) {
                if (validator) {
                    validator.validate();
                    if (!validator.option("isValid")) {
                        isValid = false;
                    }
                }
            });

            // If all inputs are valid, proceed with form submission
            if (isValid) {
                submitForm();
            } else {
                console.log("Validation errors exist.");
                // Handle validation errors or display messages as needed
            }
        }
    });

    function submitForm() {

        // Redirect to index2.html
        window.location.href = "index2.html";
    }

});