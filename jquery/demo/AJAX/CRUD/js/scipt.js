
function showData() {
    $.ajax({
       
        url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user",
        type: "GET",
        async: true,
        success: function getData(result) {
            $("#myTable tbody").empty();
            for (const key in result) {
                
                    $("#myTable tbody").append(
                        "<tr>" +
                        "<td>" + result[key].id + "</td>" +
                        "<td>" + result[key].name + "</td>" +
                        "<td>" + result[key].designation + "</td>" +
                        "<td>" + result[key].city + "</td>" +
                        "</tr>"
                    )
                
            }   
        },
        error: function ErrorData() {
            alert("Something Wants to Wrong !!!")
        }
    });
}

$(() => {
    showData();



    $("#btnAddData").click(() => {
        let uservalue = {};
        uservalue['name'] = $("#exampleInputName").val();
        uservalue['designation'] = $("#exampleDesignation option:selected").text();
        uservalue['city'] = $("#exampleSelectCity option:selected").text();
        // uservalue['age'] = 19;

        // console.log($.param(uservalue));
        $.ajax({
            type: "POST",
            url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user",
            data: $.param(uservalue),
            success: showData(),
            error: function () {
                alert("Something Wants to Wrong !!!")
            }
        });
    });


    $("#btnDeleteData").click(() => {
        const searchValue = $("#txtSearch").val();
        $.ajax({
            
            url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user/" + searchValue,
            type: "DELETE",
            async: true,
            success: function () {
                alert("Record Deleted Successfully");
                showData();
            },
            error: function () {
                alert("Something Wants to Wrong !!!")
            }

        });
    });

  
    

    $("#btnUpdateData").click(() => {
        const searchValue = $("#txtSearch").val();
        let uservalue = {};
        uservalue['name'] = $("#exampleInputName").val();
        uservalue['designation'] = $("#exampleDesignation option:selected").text();
        uservalue['city'] = $("#exampleSelectCity option:selected").text();
        
       

        // console.log($.param(uservalue));
        $.ajax({
            type: "PUT",
            url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user/" + searchValue,
            data: $.param(uservalue),
            success: function () {
                alert("Record Updated Successfully");
                showData();
            },
            error: function () {
                alert("Something Wants to Wrong !!!")
            }
        

        });
    });
    $("#btnSearch").click(() => {
        const searchValue = $("#txtSearch").val();
        $.ajax({
          
            url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user?id=" + searchValue,
            type: "GET",
            async: true,
            success: function getData(result) {
                $("#myTable tbody").empty();
                for (const key in result) {
                    
                        $("#myTable tbody").append(
                            "<tr>" +
                            "<td>" + result[key].id + "</td>" +
                            "<td>" + result[key].name + "</td>" +
                            "<td>" + result[key].designation + "</td>" +
                           
                            "<td>" + result[key].city + "</td>" +
                            "</tr>"
                        )
                    
                }
            },
            error: function () {
                alert("Something Wents to Wrong !!!")
            },
           
        });
    });

});