$(() => {
    $("#SelectBox1-container").dxSelectBox({
        items: simpleProducts,
        value: simpleProducts[0],
        acceptCustomValue: false,
        accessKey: "S",
        activeStateEnabled: true,
        disabled: false,
        focusStateEnabled: true,
        height: undefined,
        hint: "",
        hoverStateEnabled: true,
        isValid: false,
        name: "",
        noDataText: "No data",
        opened: false,
        placeholder: "Placeholder name",
        readOnly: false,
        rtlEnabled: false,
        tabEnabled: true,
        tabIndex: 0,
        text: "",
        visible: true,
        width: 1150,
      
    });

    $('#products-simple').dxSelectBox({
        items: simpleProducts
    });

    $('#products-placeholder').dxSelectBox({
        items: simpleProducts,
        placeholder: 'Choose Product',
        showClearButton: true,
        width: 1150
    });

    $('#products-read-only').dxSelectBox({
        items: simpleProducts,
        value: simpleProducts[1],
        readOnly: true,
    });

    $('#products-disabled').dxSelectBox({
        items: simpleProducts,
        value: simpleProducts[2],
        disabled: true,
    });
    $('#product-handler').dxSelectBox({
        items: simpleProducts,
        value: simpleProducts[0],
        onValueChanged(data) {
            DevExpress.ui.notify(`The value is changed to: "${data.value}"`);
        },
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
        noDataText: "Data not Found...",
        searchExpr: ["key", "stateName"],
        searchMode: 'contains',
        searchTimeout: 200,
        minSearchLength: 1,
        showDataBeforeSearch: true,
        showClearButton: true,
        width: 1150,
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

    })
});