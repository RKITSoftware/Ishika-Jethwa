$(document).ready(function() {
    const jsonDataUrl = "data.json"; // Path to the internal JSON file

    // Function to load and display data
    function loadData() {
        $.ajax({
            url: jsonDataUrl,
            type: "GET",
            dataType: "json",
            success: function(data) {
                $("#dataList").empty();
                data.forEach(function(item) {
                    $("#dataList").append("<li>" + item.name + "</li>");
                });
            },
            error: function(error) {
                console.log("Error loading data:", error);
            }
        });
    }

    // Click event for "Load Data" button
    $("#loadData").click(function() {
        loadData();
    });
});
