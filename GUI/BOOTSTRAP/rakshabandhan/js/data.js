


function getUserInfo(){
    $.ajax({
        contentType: "application/x-www-form-urlencoded",
        url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user",
        type: "GET",
        async: true,
        success: function getData(result) {
            $("#userInfoTable tbody").empty();
            for (const key in result) {
              
                    $("#userInfoTable tbody").append(
                        "<tr>" +
                        "<td>" + result[key].id + "</td>" +
                        "<td>" + result[key].name + "</td>" +
                        "<td>" + result[key].city + "</td>" +
                        "<td>" + result[key].designation + "</td>" +
                        "</tr>"
                    )
                
            }
        },
        error: function ErrorData() {
            alert("Something Wants to Wrong !!!")
        },
        
    });
}
$(()=>{
   
    
    getUserInfo();
    addRecord=()=>{
        let payload={}
        payload['name'] =$("#exampleInputName").val();
        
        payload['password'] =$("#exampleInputPassword").val();
        payload['city'] =$("#exampleSelect option:selected").text();
        
        console.log(payload)
        console.log($.param(payload))
        $.ajax({
            type: "POST",
            url: "https://6522cd38f43b17938414eb9d.mockapi.io/api/person/user",
            data: $.param(payload),
            success: function () {
                alert("Record Inserted Successfully...")
            },
            error: function () {
                alert("Something Wants to Wrong !!!")
            },
           
        });
   }
});