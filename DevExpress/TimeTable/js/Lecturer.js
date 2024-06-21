// Function to generate Lecturer Form
export function generateLecturerForm() {
    const formHTML = `
        <div class="form-container">
            <h2>Lecturer Form</h2>
            <div id="lecturerDataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    $('#content').html(formHTML);

    initLecturerDataGrid();
}

// Define the customStore for managing lecturer data
const customLecturerStore = new DevExpress.data.CustomStore({
    key: 'lecturerId',

    load: function () {
        return $.getJSON('https://localhost:7128/api/CLLecturer').then(function (response) {
            if (response.isSuccess && response.data && response.data.lecturerTable) {
                return {
                    data: response.data.lecturerTable,
                    totalCount: response.data.lecturerTable.length
                };
            }
        });
    },

    insert: function (values) {
        return $.ajax({
            url: 'https://localhost:7128/api/CLLecturer',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(values)
        });
    },

    update: function (key, values) {
        return $.getJSON(`https://localhost:7128/api/CLLecturer/${key}`).then(function (originalData) {
            if (originalData.isSuccess && originalData.data && originalData.data.lecturerTable) {
                const currentData = originalData.data.lecturerTable[0];
                const updatedData = { ...currentData, ...values };
                return $.ajax({
                    url: `https://localhost:7128/api/CLLecturer`,
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
        return $.ajax({
            url: `https://localhost:7128/api/CLLecturer/${key}`,
            method: 'DELETE'
        });
    }
});

// Function to initialize DataGrid for Lecturers
function initLecturerDataGrid() {
    $('#lecturerDataGrid').dxDataGrid({
        dataSource: customLecturerStore,
        columns: [
            { dataField: 'lecturerId', caption: 'ID', width: 50 },
            { dataField: 'fullName', caption: 'Full Name' },
            { dataField: 'contactNo', caption: 'Contact No' },
            { dataField: 'isActive', caption: 'IsActive', dataType: 'boolean', width: 100 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Lecturer',
                showTitle: true,
                width: 700,
                height: 'auto',
            },
            form: {
                items: [
                    {
                        itemType: 'group',
                        colCount: 1,
                        items: [
                            { dataField: 'lecturerId', editorOptions: { readOnly: true } },
                            { dataField: 'fullName', editorType: 'dxTextArea', editorOptions: { placeholder: 'Enter Full Name' } },
                            { dataField: 'contactNo', editorType: 'dxTextBox', editorOptions: { placeholder: 'Enter Contact Number' } },
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
        height: 500,
        showBorders: true
    });
}
