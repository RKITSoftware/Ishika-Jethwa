// Function to generate Semester Form
export function generateSemesterForm() {
    // HTML structure for the form and content
    const formHTML = `
        <div class="form-container">
            <h2>Semester Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid for semesters
    initSemesterDataGrid();
}

// Function to initialize DataGrid for Semesters
function initSemesterDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: [], // Your data source here
        columns: [
            { dataField: 'Id', caption: 'ID', width: 50 },
            { dataField: 'SemesterName', caption: 'Semester Name' },
            { dataField: 'IsActive', caption: 'IsActive', dataType: 'boolean', width: 100 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Semester',
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
                            { dataField: 'SemesterName', editorOptions: { placeholder: 'Enter Semester Name' } },
                            { dataField: 'IsActive', editorType: 'dxCheckBox', editorOptions: { value: false } },
                        ],
                    },
                ],
            },
        },
        height: 400, // Set grid height as needed
        showBorders: true // Show borders for better UI
    });
}