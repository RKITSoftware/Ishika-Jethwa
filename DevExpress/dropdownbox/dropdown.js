$(function () {
    $("#dropdownBox").dxDropDownBox({
        acceptCustomValue: true,
        dataSource: employees,   
        value: employees[0].Prefix + " " + employees[0].FirstName + " " + employees[0].LastName,
        contentTemplate: (e) => {
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (data) {
                    return data.FirstName +" "+ data.LastName;
                },
               
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData.Prefix + " " + selected.itemData.FirstName + " " + selected.itemData.LastName);
                    e.component.close();
                }
            });

            return $list;
        },
       
      
        selectionMode: "single",
        onSelectionChanged: function (arg) {
            e.component.option("value", arg.addedItems[0]);
            e.component.close();
        },
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
        acceptCustomValue: true,
        dataSource: religion,
        value: religion[0].name,
        //  valueExpr: "id",
        //  displayExpr: "name",
        placeholder: "Select your religion",
        showClearButton: true,
        width: 700,
        
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (item) {
                    // var $itemDiv = $("<div>");
                    // var $nameSpan = $("<span>").text(item.name);
                    // $itemDiv.append($nameSpan);
                    // return $itemDiv;
                    return item.id + " " + item.name;
                },
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData.name);
                    e.component.close();
                }
            });
            return $list;

        },
        onSelectionChanged: function (arg) {
            e.component.option("value", arg.addedItems[0]);
            e.component.close();
        },
    })
});