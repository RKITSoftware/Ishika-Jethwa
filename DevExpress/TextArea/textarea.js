$(() => {
    const longText = 'DevExtreme is a comprehensive suite of high-performance HTML5 and JavaScript tools for building responsive web applications. It includes a variety of UI widgets, data visualization tools, and frameworks for building modern web applications. Here are some key aspects of DevExtreme . DevExtreme offers a wide range of UI widgets, including data grids, charts, pivot grids, tree lists, forms, editors, and more. These widgets are designed to be highly customizable and can be tailored to fit the specific needs of your application. DevExtreme components are designed to be fully responsive and adaptive, ensuring that applications work seamlessly on desktop, tablet, and mobile devices. These components support various data types and can be customized to display complex data in an intuitive manner. The suite includes powerful data visualization components like charts, gauges, maps, and range selectors.';
    $('#example-textarea').dxTextArea({
        value: longText,
        height: 90,
        width: 1150,
        maxLength:10,
        autoResizeEnabled :true
    });

    $('#editing-textarea').dxTextArea({
        value: longText,
        height: 90,
        valueChangeEvent: 'change',
        onValueChanged(data) {
            disabledTextArea.option('value', data.value);
        },
    });

    const disabledTextArea = $('#disabled-textarea').dxTextArea({
        value: longText,
        height: 90,
        disabled: true,
    }).dxTextArea('instance');
});