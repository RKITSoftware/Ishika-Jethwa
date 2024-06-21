$(() => {
    $('#simple').dxTextBox({
        value: 'Ishika Jethwa',
        width: 1150
    });

    $('#placeholder').dxTextBox({
        placeholder: 'Enter full name here...',
    });

    $('#clear-button').dxTextBox({
        value: 'Ishika Jethwa',
        showClearButton: true,
    });

    $('#password').dxTextBox({
        mode: 'password',
        placeholder: 'Enter password',
        showClearButton: true,
        value: 'f5lzKs0T',
    });

    $('#mask').dxTextBox({
        mask: '+1 (X00) 000-0000',
        maskRules: { X: /[02-9]/ },
    });

    $('#disabled').dxTextBox({
        value: 'Ishika Jethwa',
        disabled: true,
    });

    $('#full-name').dxTextBox({
        value: 'ishika',
        showClearButton: true,
        placeholder: 'Enter full name',
        valueChangeEvent: 'keyup',
        onValueChanged(data) {
            emailEditor.option('value', `${data.value.replace(/\s/g, '').toLowerCase()}@gmail.com`);
        },
    });

    const emailEditor = $('#email').dxTextBox({
        value: 'ishika@gmail.com',
        readOnly: true,
        hoverStateEnabled: false,
    }).dxTextBox('instance');
});