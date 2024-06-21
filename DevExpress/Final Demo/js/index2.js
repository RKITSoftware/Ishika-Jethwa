$(function () {
    // Function to initialize DX TextBox with common settings
    function initializeTextBox(id, placeholderText, isRequired = true) {
        const config = {
            placeholder: placeholderText,
            showClearButton: true,
            width: 700,
        };
        if (isRequired) {
            $("#" + id).dxTextBox(config).dxValidator({
                validationRules: [{
                    type: "required",
                    message: placeholderText + " is required"
                }]
            });
        } else {
            $("#" + id).dxTextBox(config);
        }
    }

    // Function to initialize DX NumberBox with common settings
    function initializeNumberBox(id, placeholderText, min, max, isRequired = true) {
        const config = {
            placeholder: placeholderText,
            showSpinButtons: true,
            width: 700,
            min: min,
            max: max
        };
        if (isRequired) {
            $("#" + id).dxNumberBox(config).dxValidator({
                validationRules: [{
                    type: "required",
                    message: placeholderText + " is required"
                }]
            });
        } else {
            $("#" + id).dxNumberBox(config);
        }
    }

    // Initialize educational form fields
    initializeTextBox("highSchoolName", "High School Name");
    initializeTextBox("highSchoolBoard", "High School Board");
    initializeNumberBox("highSchoolYear", "High School Year of Passing", 1900, new Date().getFullYear());
    initializeNumberBox("highSchoolPercentage", "High School Percentage/Grade", 0, 100);

    initializeTextBox("intermediateSchoolName", "Intermediate School Name");
    initializeTextBox("intermediateSchoolBoard", "Intermediate School Board");
    initializeNumberBox("intermediateSchoolYear", "Intermediate School Year of Passing", 1900, new Date().getFullYear());
    initializeNumberBox("intermediateSchoolPercentage", "Intermediate School Percentage/Grade", 0, 100);

    initializeTextBox("graduationCollegeName", "Graduation College Name");
    initializeTextBox("graduationUniversity", "Graduation University");
    initializeNumberBox("graduationYear", "Graduation Year of Passing", 1900, new Date().getFullYear());
    initializeNumberBox("graduationPercentage", "Graduation Percentage/Grade", 0, 100);

    initializeTextBox("postGraduationCollegeName", "Post Graduation College Name (if any)", false);
    initializeTextBox("postGraduationUniversity", "Post Graduation University (if any)", false);
    initializeNumberBox("postGraduationYear", "Post Graduation Year of Passing (if any)", 1900, new Date().getFullYear(), false);
    initializeNumberBox("postGraduationPercentage", "Post Graduation Percentage/Grade (if any)", 0, 100, false);

    // Handle form submission
    $("#submitButtonContainer").dxButton({
        text: "Submit",
        type: "default",
        onClick: function () {
            // Validate the inputs
            var validators = [
                $("#highSchoolName").dxValidator("instance"),
                $("#highSchoolBoard").dxValidator("instance"),
                $("#highSchoolYear").dxValidator("instance"),
                $("#highSchoolPercentage").dxValidator("instance"),
                $("#intermediateSchoolName").dxValidator("instance"),
                $("#intermediateSchoolBoard").dxValidator("instance"),
                $("#intermediateSchoolYear").dxValidator("instance"),
                $("#intermediateSchoolPercentage").dxValidator("instance"),
                $("#graduationCollegeName").dxValidator("instance"),
                $("#graduationUniversity").dxValidator("instance"),
                $("#graduationYear").dxValidator("instance"),
                $("#graduationPercentage").dxValidator("instance"),
               
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
        // Perform form submission logic here
        console.log("Form submitted successfully!");

        // Redirect to index2.html
        window.location.href = "index3.html";
    }
});
