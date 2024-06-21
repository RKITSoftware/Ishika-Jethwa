// Function to generate Session Form
export function generateSessionForm() {
    // HTML structure for the form and content
    const formHTML = `
        <div class="form-container">
            <h2>Session Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid for sessions
    initSessionDataGrid();
}
function formatTitle(title) {
    // Assuming title is in the format '20232025'
    if (title && title.length === 8) {
        return title.slice(0, 4) + '-' + title.slice(4);
    }
    return title; // Return as is if already formatted or invalid
}
// Define the customStore for managing session data
const sessionCustomStore = new DevExpress.data.CustomStore({
    key: 'sessionID',


    load: function () {


        // Perform GET request to fetch data with paging
        return $.getJSON('https://localhost:7128/api/Session').then(function (response) {
            if (response.isSuccess && response.data && response.data.sessionTable) {
                // Format the title to include a dash
                const formattedData = response.data.sessionTable.map(item => ({
                    ...item,
                    title: formatTitle(item.title) // Format the title with a dash
                }));
                return {
                    data: formattedData,
                    totalCount: formattedData.length
                };
            }
        });
    },

    insert: function (values) {
        // Format the title with a dash before sending to the server
        values.title = formatTitle(values.title);
        // Perform POST request to insert data
        return $.ajax({
            url: 'https://localhost:7128/api/Session',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(values)
        });
    },

    update: function (key, values) {
        // Fetch the original data for the key (sessionID)
        return $.getJSON(`https://localhost:7128/api/Session/${key}`).then(function (originalData) {
            if (originalData.isSuccess && originalData.data && originalData.data.sessionTable) {
                const currentData = originalData.data.sessionTable[0];

                // Merge the original data with the updated values
                const updatedData = { ...currentData, ...values };
                updatedData.title = formatTitle(updatedData.title);
                // Perform PUT request to update data
                return $.ajax({
                    url: `https://localhost:7128/api/Session`,
                    method: 'PUT',
                    contentType: 'application/json',
                    data: JSON.stringify(updatedData)
                });
            } else {
                throw new Error('Failed to fetch the original data');
            }
        });
    },

    remove: function (key) {
        // Perform DELETE request to remove data
        return $.ajax({
            url: `https://localhost:7128/api/Session/${key}`,
            method: 'DELETE'
        });
    }
});


// Function to initialize DataGrid for Sessions
function initSessionDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: sessionCustomStore, // Your data source here
        columns: [
            { dataField: 'sessionID', caption: 'ID', width: 50 },
            { dataField: 'title', caption: 'Session Title' },
            { dataField: 'isActive', caption: 'IsActive', dataType: 'boolean', width: 200 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Session',
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
                            { dataField: 'sessionID', editorOptions: { readOnly: true } },
                            {
                                dataField: 'title',
                                editorType: 'dxTextBox',
                                editorOptions: {
                                    placeholder: 'Enter Session Title',
                                    mask: '0000-0000'
                                }
                            },
                            { dataField: 'isActive', editorType: 'dxCheckBox' },
                        ],
                    },
                ],
            },
        },

        searchPanel: {
            visible: true,
            highlightCaseSensitive: true
        },
        paging: {
            pageSize: 5
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [5, 10, 20],
            showInfo: true
        },
        height: 400, // Set grid height as needed
        showBorders: true // Show borders for better UI
    });
}