// Function to generate Subject Semester Form
export function generateSubjectSemesterForm() {
    // HTML structure for the form and content
    const formHTML = `
        <div class="form-container">
            <h2>Subject Semester Form</h2>
            <div id="dataGrid">
                <!-- Data grid content -->
            </div>
        </div>
    `;

    // Set the form HTML to the content div
    $('#content').html(formHTML);

    // Initialize and load data grid for Subject Semester
    initSubjectSemesterDataGrid();
}

// Function to initialize DataGrid for Subject Semester
function initSubjectSemesterDataGrid() {
    $('#dataGrid').dxDataGrid({
        dataSource: [], // Your data source here
        columns: [
            { dataField: 'Id', caption: 'ID', width: 50 },
            { dataField: 'SubjectSemesterTitle', caption: 'Subject Semester Title' },
          
        ],
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: 'Edit Subject Semester',
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
                            { dataField: 'SubjectSemesterTitle', editorOptions: { readOnly: true, elementAttr: { id: "SubjectSemesterTitle" }, } },
                            {
                                dataField: 'ProgramSemesterId',
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: programSemesterDataSource,
                                    displayExpr: 'ProgramSemesterTitle',
                                    valueExpr: 'Id',
                                    placeholder: 'Select Program Semester',
                                    name: "ProgramSemesterId",
                                    onValueChanged: updateSubjectSemesterTitle
                                },
                            },
                            {
                                dataField: 'SubjectId',
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: subjectDataSource,
                                    displayExpr: 'SubjectTitle',
                                    valueExpr: 'Id',
                                    placeholder: 'Select Subject',
                                    name:"SubjectId",
                                    onValueChanged: updateSubjectSemesterTitle
                                }
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

// Example data source for Program Semester dropdown
const programSemesterDataSource = [
    { Id: 1, ProgramSemesterTitle: 'Spring-Computer Science-2024' },
    { Id: 2, ProgramSemesterTitle: 'Summer-Electrical Engineering-2024' },
    { Id: 3, ProgramSemesterTitle: 'Fall-Business Administration-2024' },
    // Add more program semesters as needed
];

// Example data source for Subject dropdown
const subjectDataSource = [
    { Id: 1, SubjectTitle: 'Data Structures' },
    { Id: 2, SubjectTitle: 'Circuit Analysis' },
    { Id: 3, SubjectTitle: 'Marketing Principles' },
    // Add more subjects as needed
];

var array200 = [] ;
// Function to update Program Semester Title
function updateSubjectSemesterTitle(e) {

    var name = e.component.option("name");
    var structure;
    if (name === "ProgramSemesterId") {
        structure = programSemesterDataSource.find(x => x.Id === e.value);
        array200[0] = structure.ProgramSemesterTitle;
    }
    else {
        structure = subjectDataSource.find(x => x.Id === e.value);
        array200[1] = structure.SubjectTitle;
    }
   
    var string1 = array200.reduce(function (item, acc) {
        return item + acc + "-";
    }, "");

    $("#SubjectSemesterTitle").dxTextBox("instance").option("value", string1.slice(0, -1));
}

