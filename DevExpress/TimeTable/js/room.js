// Function to generate Room Form
export function generateRoomForm() {
    // HTML structure for the form and content
    const formHTML = `
        <div class="form-container">
            <h2>Room Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid for rooms
    initRoomDataGrid();
}

// Function to initialize DataGrid for Rooms
function initRoomDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: [], // Your data source here
        columns: [
            { dataField: 'Id', caption: 'ID', width: 50 },
            { dataField: 'RoomNo', caption: 'Room No.' },
            { dataField: 'Capacity', caption: 'Capacity' },
            { dataField: 'Status', caption: 'Status', dataType: 'boolean', width: 100 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Room',
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
                            { dataField: 'RoomNo', editorOptions: { placeholder: 'Enter Room Number' } },
                            { dataField: 'Capacity', editorType: 'dxNumberBox', editorOptions: { min: 1, max: 100, showSpinButtons: true } },
                            { dataField: 'Status', editorType: 'dxCheckBox', editorOptions: { value: false } },
                        ],
                    },
                ],
            },
        },
        height: 400, // Set grid height as needed
        showBorders: true // Show borders for better UI
    });
}