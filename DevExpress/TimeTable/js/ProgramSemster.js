// Function to generate Program Semester Form
export function generateProgramSemesterForm() {
    // HTML structure for the form and content
    const formHTML = `
        <div class="form-container">
            <h2>Program Semester Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid for Program Semester
    initProgramSemesterDataGrid();
}

// Function to initialize DataGrid for Program Semester
function initProgramSemesterDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: [], // Your data source here
        columns: [
            { dataField: 'Id', caption: 'ID', width: 50 },
            { dataField: 'ProgramSemesterTitle', caption: 'Program Semester Title', readOnly: true },
            { dataField: 'Capacity', caption: 'Capacity' },
            { dataField: 'IsActive', caption: 'IsActive', dataType: 'boolean', width: 100 },
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Program Semester',
                showTitle: true,
                width: 700, // Adjust popup width as needed
                height: 'auto', // Adjust popup height as needed
            },
            form: {
                // onInitialized: function (e) {
                //     window.formData1 = e.component._options._optionManager._options.formData
                //     console.log("IN FORM")
                // },
                items: [
                    {
                        itemType: 'group',
                        colCount: 1,
                        items: [
                            {
                                editorType: "dxTextBox",
                                dataField: 'ProgramSemesterTitle',
                                editorOptions: {
                                    readOnly: true,
                                    elementAttr: { id: "ProgramSemesterTitle" },
                                    width: "500px",
                                }
                            },
                            {
                                dataField: 'SessionId',
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: sessionDataSource,
                                    displayExpr: 'SessionTitle',
                                    valueExpr: 'Id',
                                    placeholder: 'Select Session',
                                    name: "SessionTitle",
                                    onValueChanged: updateProgramSemesterTitle
                                }
                            },
                            {
                                dataField: 'ProgramId',
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: programDataSource,
                                    displayExpr: 'ProgramName',
                                    valueExpr: 'Id',
                                    placeholder: 'Select Program',
                                    name: "ProgramName",
                                    onValueChanged: updateProgramSemesterTitle
                                }
                            },
                            {
                                dataField: 'SemesterId',
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: semesterDataSource,
                                    displayExpr: 'SemesterName',
                                    valueExpr: 'Id',
                                    placeholder: 'Select Semester',
                                    name: "SemesterName",
                                    onValueChanged: updateProgramSemesterTitle
                                }
                            },
                            {
                                dataField: 'Capacity',
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: [1, 2, 3],
                                    placeholder: 'Select Capacity'
                                }
                            },
                            {
                                dataField: 'IsActive',
                                editorType: 'dxCheckBox',
                                editorOptions: {
                                    value: false,
                                },
                            },
                        ],
                    },
                ],
            },
        },
        height: 400, // Set grid height as needed
        showBorders: true // Show borders for better UI
    });
}

// Example data source for Session dropdown
const sessionDataSource = [
    { Id: 1, SessionTitle: 'Spring Session' },
    { Id: 2, SessionTitle: 'Summer Session' },
    { Id: 3, SessionTitle: 'Fall Session' },
    // Add more sessions as needed
];

// Example data source for Program dropdown
const programDataSource = [
    { Id: 1, ProgramName: 'Computer Science' },
    { Id: 2, ProgramName: 'Electrical Engineering' },
    { Id: 3, ProgramName: 'Business Administration' },
    // Add more programs as needed
];

// Example data source for Semester dropdown
const semesterDataSource = [
    { Id: 1, SemesterName: 'Spring 2024' },
    { Id: 2, SemesterName: 'Summer 2024' },
    { Id: 3, SemesterName: 'Fall 2024' },
    // Add more semesters as needed
];

var array200 = [];

// Function to update Program Semester Title
function updateProgramSemesterTitle(e) {

    var name = e.component.option("name");
    var structure;
    if (name === "SessionTitle") {
        structure = sessionDataSource.find(x => x.Id === e.value);
        array200[0] = structure.SessionTitle;
    }
    else if (name === "SemesterName") {
        structure = semesterDataSource.find(x => x.Id === e.value);
        array200[2] = structure.SemesterName;
    }
    else {
        structure = programDataSource.find(x => x.Id === e.value);
        array200[1] = structure.ProgramName;
    }
    var string1 = array200.reduce(function (item, acc) {
        return item + acc + "-";
    }, "");

    $("#ProgramSemesterTitle").dxTextBox("instance").option("value", string1.slice(0, -1));
}
