$(() => {
    $("#numberbox").dxNumberBox({
        accessKey: "N",
        activeStateEnabled: true,
        buttons: [{
            name: "customButton",
            location: "after",
            options: {
                text: "Custom",
                onClick: function () {
                    alert("Custom button clicked");
                }
            }
        }],
        disabled: false,
        focusStateEnabled: true,
        format: "#,##.##",
        height: 40,
        hint: "Enter a number",
        hoverStateEnabled: true,
        inputAttr: {
            maxlength: 10
        },
        isValid: false,
       
        max: 100,
        min: 0,
        mode: "number", // password,
        placeholder: "Numbers.....",
        
    });

    $('#default').dxNumberBox({
        value: 15,
        width: 1150,
    });

    $('#spin_clear').dxNumberBox({
        value: 15.12,
        showSpinButtons: true,
        showClearButton: true,
        step:2,
        stylingMode: "filled", // Default Value: 'outlined', 'filled' (Material)
        useLargeSpinButtons:true,

    });

    $('#disabled').dxNumberBox({
        value: 20.5,
        showSpinButtons: true,
        showClearButton: true,
        disabled: true,

    });

    $('#max_min').dxNumberBox({
        value: 15,
        min: 10,
        max: 20,
        showSpinButtons: true

    });

    const totalProductQuantity = 30;

    $('#sales').dxNumberBox({
        max: totalProductQuantity,
        min: 0,
        value: 16,
        showSpinButtons: true,

        onKeyDown(e) {
            const { event } = e;
            const str = event.key;
            if (/^[.,e]$/.test(str)) {
                event.preventDefault();
            }
        },
        onValueChanged(data) {
            productInventory.option('value', totalProductQuantity - data.value);
        },
    });

    const productInventory = $('#stock').dxNumberBox({
        value: 14,
        min: 0,
        showSpinButtons: false,
        readOnly: true,
    }).dxNumberBox('instance');
});