import { generateProgramForm } from "./program.js";
import { generateSessionForm } from "./session.js";
import { generateSubjectForm } from "./subject.js";
import { generateLecturerForm } from "./Lecturer.js";
import { generateRoomForm } from "./room.js";
import { generateLabForm } from "./lab.js";
import { generateSemesterForm } from "./semester.js";
import { generateSectionForm } from "./section.js";
import { generateProgramSemesterForm } from "./ProgramSemster.js";
import { generateSubjectSemesterForm } from "./subjectSemester.js";
$(() => {
    $('#content').html(text);

    const drawer = $('#drawer').dxDrawer({
        opened: true,
        closeOnOutsideClick: true,
        template() {
            const $list = $('<div>').width(200);

            const list = $list.dxList({
                dataSource: navigation,
                hoverStateEnabled: false,
                focusStateEnabled: false,
                activeStateEnabled: false,
                grouped: true,
                collapsibleGroups: true,
                groupTemplate(group) {
                    return $('<div>').text(group.key);
                },
                itemTemplate(item) {
                    return $('<div>').text(item.text);
                },
                onContentReady(e) {
                    const instance = e.component;
                    instance.option('dataSource').forEach((group, index) => {
                        instance.collapseGroup(index);
                    });
                },
                onGroupClick(e) {
                    const instance = e.component;
                    if (instance.isGroupExpanded(e.groupIndex)) {
                        instance.collapseGroup(e.groupIndex);
                    } else {
                        instance.collapseAll(-1);  // Collapse all groups
                        instance.expandGroup(e.groupIndex);  // Expand the clicked group
                    }
                },
                onItemClick(e) {
                    handleNavigationClick(e.itemData.id);
                },
            }).dxList('instance');

            return $list;
        },
    }).dxDrawer('instance');

    $('#toolbar').dxToolbar({
       
        items: [{
            widget: 'dxButton',
            location: 'before',
            options: {
                icon: 'menu',
                stylingMode: 'text',
                onClick() {
                    drawer.toggle();
                },
            },
        }],
    });


 
});
// Function to handle navigation item clicks
function handleNavigationClick(id) {
    let content = '';
    switch (id) {
        case 1:
            content = generateProgramForm();
            break;
        case 2:
            content = generateSessionForm();
            break;
        case 3:
            content = generateSubjectForm();
            break;
        case 4:
            content = generateLecturerForm();;
            break;
        case 5:
            content = `
                <h2>Lectures Content</h2>
                <p>Details about lectures...</p>
                <button id="newLectureBtn">New Lecture</button>
                <button id="assignSubjectBtn">Assign Subject to Lecturer</button>
            `;
            break;
        case 6:
            content = generateRoomForm();
            break;
        case 7:
            content = generateLabForm();
            break;
        case 8:
            content = generateSemesterForm();
            break;
        case 9:
            content = generateSectionForm();
            break;
        case 10:
            content = generateProgramSemesterForm();
            break;
        case 11:
            content = generateSubjectSemesterForm();
            break;
    }
    $('#content').html(content);
}
