// Function to generate Section Form
export function generateSectionForm() {
    // HTML structure for the form and content
    const formHTML = `
        <div class="form-container">
            <h2>Section Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid for sections
    initSectionDataGrid();
}

// Function to initialize DataGrid for Sections
function initSectionDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: [], // Your data source here
        columns: [
            { dataField: 'Id', caption: 'ID', width: 50 },
            { dataField: 'SectionTitle', caption: 'Section Title' },
            { dataField: 'SemesterId', caption: 'Semester', lookup: { dataSource: semesterDataSource, valueExpr: 'Id', displayExpr: 'SemesterName' } },
            { dataField: 'Capacity', caption: 'Capacity' },
            { dataField: 'IsActive', caption: 'IsActive', dataType: 'boolean', width: 100 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Section',
                showTitle: true,
                width: 700, // Adjust popup width as needed
                height: 'auto', // Adjust popup height as needed
            },
            form: {
                items: [
                    {
                        itemType: 'group',
                        colCount: 1,
                        items: [
                            { dataField: 'SectionTitle', editorOptions: { placeholder: 'Enter Section Title' } },
                            { dataField: 'SemesterId', editorType: 'dxSelectBox', editorOptions: { dataSource: semesterDataSource, displayExpr: 'SemesterName', valueExpr: 'Id', placeholder: 'Select Semester' } },
                            { dataField: 'Capacity', editorType: 'dxSelectBox', editorOptions: { dataSource: [1, 2, 3], placeholder: 'Select Capacity' } },
                            { dataField: 'IsActive', editorType: 'dxCheckBox', editorOptions: { value: false} },
                        ],
                    },
                ],
            },
        },
        height: 400, // Set grid height as needed
        showBorders: true // Show borders for better UI
    });
}

// Example data source for Semester dropdown
const semesterDataSource = [
    { Id: 1, SemesterName: 'Spring 2024' },
    { Id: 2, SemesterName: 'Summer 2024' },
    { Id: 3, SemesterName: 'Fall 2024' },
    // Add more semesters as needed
];