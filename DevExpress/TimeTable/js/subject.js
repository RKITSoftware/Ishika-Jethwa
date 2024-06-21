export function generateSubjectForm() {

    const formHTML = `
        <div class="form-container">
            <h2>Subject Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    $('#content').html(formHTML);

    initSubjectDataGrid();
}

const customcourseStore = new DevExpress.data.CustomStore({
    key: 'courseID',

    load: function () {


        return $.getJSON('https://localhost:7128/api/CLCourse').then(function (response) {
            if (response.isSuccess && response.data && response.data.courseTable) {
                return {
                    data: response.data.courseTable,
                    totalCount: response.data.courseTable.length
                };
            }
        });
    },

    insert: function (values) {
        values.roomTypeID = values.roomTypeID.value;
        return $.ajax({
            url: 'https://localhost:7128/api/CLCourse',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(values)
        });
    },

    update: function (key, values) {
        return $.getJSON(`https://localhost:7128/api/CLCourse/${key}`).then(function (originalData) {
            if (originalData.isSuccess && originalData.data && originalData.data.courseTable) {
                const currentData = originalData.data.courseTable[0];
                const updatedData = { ...currentData, ...values };
                updatedData.roomTypeID = updatedData.roomTypeID.value;
                return $.ajax({
                    url: `https://localhost:7128/api/CLCourse`,
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
            url: `https://localhost:7128/api/CLCourse/${key}`,
            method: 'DELETE'
        });
    }
});

function initSubjectDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: customcourseStore,
        columns: [
            { dataField: 'courseID', caption: 'ID', width: 50 },
            { dataField: 'title', caption: 'Subject Title' },
            {
                dataField: 'roomTypeID', caption: 'Subject Type', calculateCellValue: function (data) {
                    return data.roomTypeID === 1 ? 'Practical' : 'Non-Practical';
                }
            },
            { dataField: 'crHrs', caption: 'Credit Hours' },
            { dataField: 'isActive', caption: 'IsActive', dataType: 'boolean', width: 100 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Subject',
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
                            { dataField: 'courseID', editorOptions: { readOnly: true } },
                            { dataField: 'title', editorType: 'dxTextArea', editorOptions: { placeholder: 'Enter Subject Title' } },
                            {
                                dataField: 'roomTypeID',

                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    items: [
                                        { value: 1, text: 'Practical' },
                                        { value: 2, text: 'Non-Practical' }
                                    ],
                                    displayExpr: 'text',
                                    valueExpr: 'text',
                                    placeholder: 'Select Subject Type'
                                }
                            },
                            {
                                dataField: 'crHrs', editorType: 'dxSelectBox', editorOptions: {
                                    items: [1, 2, 3],
                                    placeholder: 'Select Credit Hours'
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
        height: 400,
        showBorders: true
    });
}