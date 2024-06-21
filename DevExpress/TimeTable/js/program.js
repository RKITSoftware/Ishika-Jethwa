export function generateProgramForm() {
    const formHTML = `
        
            <div class="form-container">
                <h2>Program Form</h2>
            
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>

            </div>

        `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid (example)
    initDataGrid();
}

const customStore = new DevExpress.data.CustomStore({
    key: 'programId',

    load: function () {
       

        // Perform GET request to fetch data with paging
        return $.getJSON('https://localhost:7128/api/CLProgram').then(function (response) {
            if (response.isSuccess && response.data && response.data.programTable) {
                return {
                    data: response.data.programTable,
                    totalCount: response.data.programTable.length
                };
            }
        });
    },
    insert: function (values) {
        // Perform POST request to insert data
        return $.ajax({
            url: 'https://localhost:7128/api/CLProgram',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(values)
        });
    },

    update: function (key, values) {
        values.programId = key;
        console.log(JSON.stringify(values));
        // Perform PUT request to update data
        return $.ajax({
            url: `https://localhost:7128/api/CLProgram`,
            method: 'PUT',
            contentType: 'application/json',
            
            data: JSON.stringify(values)
        });
    },

    remove: function (key) {
        // Perform DELETE request to remove data
        return $.ajax({
            url: `https://localhost:7128/api/CLProgram/${key}`,
            method: 'DELETE'
        });
    }
});

function initDataGrid() {
    // Example initialization of a data grid using a library like DevExpress or any other data grid library
    $('#dataGrid').dxDataGrid({
        dataSource: customStore, // Your data source here
        columns: [
            { dataField: 'programId', caption:'ID',width:50 },
            { dataField: 'name', caption: 'Program name' },
            { dataField: 'isActive', caption: 'IsActive', dataType: 'boolean', width: 200 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
           
            popup: {
                title: 'Edit',
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
                            { dataField: 'programId', editorOptions: {readOnly:true } },
                            { dataField: 'name', editorOptions: { placeholder: 'Enter Program Name' } },
                            { dataField: 'isActive', editorType: 'dxCheckBox'},
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
