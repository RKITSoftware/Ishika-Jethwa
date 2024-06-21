$("#datebox").dxDateBox({
    //user can enter value or not
    acceptCustomValue: true,
    accessKey: "A",
    activeStateEnabled: true,
    adaptivityEnabled: true,
    applyButtonText: "Set", // Default Ok
    //adding 3 buttons into datebox 
    applyValueMode: "useButtons", // Accepted Values: 'instantly' | 'useButtons'

    cancelButtonText: "No Need", // Cancel button text default cancel
    // pickerType: 'roller',
    calendarOptions: {
        maxZoomLevel: "month", // Other valid values: "decade", "year", "month", "century"
        minZoomLevel: "century", // Other valid values: "decade", "year", "month" , "century"
        // showTodayButton: true // Boolean value to show/hide the "Today" button
    },
    dateOutOfRangeMessage: "Date is out of range",
    max: new Date(2024, 11, 31),
    min: new Date(2024, 0, 1),

    dateSerializationFormat: "yyyy-MM-dd",
    displayFormat: "dd/MM/yyyy",
    disabled: false,
    focusStateEnabled: true,
    hint: "Datebox demo",
    invalidDateMessage: "Invalid Date",
    //type:time,date, datetime
    width: 1150,
    hight: 52,
    type: 'date',  
    pickerType: 'calendar',    //Accepted Value Roller         //must be calender
    onOpened: function () {
       alert("Datebox drop-down menu open...")
    },
    disabledDates: function (args) {
        console.log(args)
        const dayOfWeek = args.date.getDay();
        console.log(dayOfWeek);  //starting from 0-sunday
        const isWeekend = dayOfWeek === 0 || dayOfWeek === 6;
        return isWeekend;
    },
    //by default calander is open or not
    opened: false,
    openOnFieldClick: true
});
$('#date').dxDateBox({
    type: 'date',
    pickerType: 'calendar',
    hint: "Datebox demo",
    invalidDateMessage: "Invalid Date",
    displayFormat: "dd/MM/yyyy",
});
 $('#time').dxDateBox({
    type: 'time',
     accessKey: "t", // Shortcut key
     activeStateEnabled: true, // Changes state on user interaction
     adaptivityEnabled: true, // Adapts to small screens
     applyButtonText: "Ok", // Text for the Apply button
     applyValueMode: "useButtons", // Apply value mode
     displayFormat: "HH:mm", // Format to display time
     onChange: function (e) { console.log("Change event:", e.value); }, // Change event handler
     onClosed: function (e) { console.log("Closed event"); }, // Closed event handler
     onCopy: function (e) { console.log("Copy event"); }, // Copy event handler
     onCut: function (e) { console.log("Cut event"); }, // Cut event handler
     onEnterKey: function (e) { console.log("Enter key event"); }, // Enter key event handler
     onFocusIn: function (e) { console.log("Focus in event"); }, // Focus in event handler
     onFocusOut: function (e) { console.log("Focus out event"); }, // Focus out event handler
     onInitialized: function (e) { console.log("Initialized event"); }, // Initialized event handler
     onInput: function (e) { console.log("Input event"); }, // Input event handler
     onKeyDown: function (e) { console.log("Key down event"); }, // Key down event handler
     onKeyPress: function (e) { console.log("Key press event"); }, // Key press event handler
     onKeyUp: function (e) { console.log("Key up event"); }, // Key up event handler
     onOpened: function (e) { console.log("Opened event"); }, // Opened event handler
     onPaste: function (e) { console.log("Paste event"); }, // Paste event handler
     onValueChanged: function (e) { console.log("Value changed event:", e.value); }, // Value changed event handler
     pickerType: "rollers", // Picker type (rollers, list, or calendar)
     value : new Date()
   
});
$("#datetime").dxDateBox({
    type: 'datetime', // Set type to 'datetime'
    pickerType: 'calendar', // Picker type (calendar for datetime)
    acceptCustomValue: true, // Allows entering custom values
    accessKey: "d", // Shortcut key
    activeStateEnabled: true, // Changes state on user interaction
    adaptivityEnabled: true, // Adapts to small screens
    applyButtonText: "Apply", // Text for the Apply button
    applyValueMode: "useButtons", // Apply value mode
    dateOutOfRangeMessage: "DateTime is out of range", // Message for out-of-range values
    displayFormat: "dd/MM/yyyy HH:mm:ss", // Format to display datetime including seconds
    invalidDateMessage: "Invalid datetime", // Message for invalid date
    isValid: true, // Is the value valid
    max: new Date(2024, 11, 31, 23, 59, 59), // Maximum datetime
    min: new Date(2024, 0, 1, 0, 0, 0), // Minimum datetime
    name: "datetimeBox", // Name attribute for the input
    tabIndex: 0, // Tab index
    value: new Date(), // Current value
   
});
$('#custom').dxDateBox({
    displayFormat: 'EEEE, MMM dd',
    value: new Date()
});

$('#date-by-picker').dxDateBox({
    pickerType: 'rollers',
    value: new Date(),
    
});
$('#disabledDates').dxDateBox({
    type: 'date',
    pickerType: 'calendar',
    value: new Date(2017, 0, 3),
    disabled: true,
    disabledDates: function (args) {
        const dayOfWeek = args.date.getDay();
        const isWeekend = dayOfWeek === 0 || dayOfWeek === 6;
        return isWeekend;
    },
    inputAttr: { 'aria-label': 'Disabled' },
});
$('#Disable-Certain-Date').dxDateBox({
    type: 'date',
    pickerType: 'calendar',
    value: new Date(2017, 0, 3),
    disabledDates: function (args) {
        const dayOfWeek = args.date.getDay();
        const isWeekend = dayOfWeek === 0 || dayOfWeek === 6;
        return isWeekend;
    },
    inputAttr: { 'aria-label': 'Disabled' },
});
$('#clear').dxDateBox({
    type: 'time',
    showClearButton: true,
    value: new Date(),
  
});
$('#birthday').dxDateBox({
    applyValueMode: 'useButtons',
    value: new Date(),
    max: new Date(),
    min: new Date(1900, 0, 1),
    inputAttr: { 'aria-label': 'Birth Date' },
    onValueChanged(data) {
        dateDiff(new Date(data.value));
    },
});

function dateDiff(birthday) {
    const today = new Date();
    let age = today.getFullYear() - birthday.getFullYear();
    const m = today.getMonth() - birthday.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthday.getDate())) {
        age--;
    }
    $('#age').text(`${age} years old`);
}


