const navigation = [
    {
        key: 'Main',
        items: [
            { id: 1, text: 'Program', icon: 'product' },
            { id: 2, text: 'Session', icon: 'money' },
            { id: 3, text: 'Subject', icon: 'group' },
        ],
    },
    {
        key: 'Lectures',
        items: [
            { id: 4, text: 'New Lecture', icon: 'chart', parent: 'Lectures' },
            { id: 5, text: 'Assign Subject to Lecturer', icon: 'chart', parent: 'Lectures' },
        ],
    }, 
    {
        key: 'Rooms/Labs',
        items: [
            { id: 6, text: 'Add rooms', icon: 'chart', parent: 'Rooms/Labs' },
            { id: 7, text: 'Add Labs', icon: 'chart', parent: 'Rooms/Labs' },
        ],
    },
    {
        key: 'Semester',
        items: [
            { id: 8, text: 'New Semesters', icon: 'chart', parent: 'Semester' },
            { id: 9, text: 'Add Semester Sections', icon: 'chart', parent: 'Semester' },
            { id: 10, text: 'Assign Semester to Program', icon: 'chart', parent: 'Semester' },
            { id: 11, text: 'Assign Subject to Semester', icon: 'chart', parent: 'Semester' },
        ],
    },
    {
        key: 'Day',
        items: [
            { id: 12, text: 'Add Days', icon: 'chart', parent: 'Day' },
            { id: 13, text: 'Day TimeSlot', icon: 'chart', parent: 'Day' },
        ],
    },
    {
        key: 'Auto Time Table',
        items: [
            { id: 14, text: 'Auto generate TimeTable', icon: 'chart', parent:"Auto Time Table" }
        ],
    },
    {
        key: 'Print',
        items: [
            { id: 15, text: 'Print All TimeTables', icon: 'chart', parent: 'Print' },
            { id: 16, text: 'Print All Teacher TimeTables', icon: 'chart', parent: 'Print' },
            { id: 17, text: 'Print All Day Wise TimeTables', icon: 'chart', parent: 'Print' },
          
        ],
    },
];
const text = `
<h2 align= center >
    <b>Auto TimeTable Generator</b>
</h2>
`;
