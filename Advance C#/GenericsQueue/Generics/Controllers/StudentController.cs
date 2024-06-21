using Generics.Models;
using Generics.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Generics.Controllers
{
    public class StudentController : ApiController
    {
        private static BLStudentService<Stu01> _studentService = new BLStudentService<Stu01>();

        /// <summary>
        /// Gets all students.
        /// </summary>
        [HttpGet]
        [Route("api/student")]
        public IHttpActionResult GetStudents()
        {
            try
            {
                Queue<Stu01> students = _studentService.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                // Log the exception
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="student">The student to be added.</param>
        [HttpPost]
        [Route("api/student/AddStudent")]
        public IHttpActionResult AddStudent([FromBody] Stu01 student)
        {
            try
            {
                Queue<Stu01> updatedStudents = _studentService.Insert(student);
                return Ok(updatedStudents);
            }
            catch (Exception ex)
            {
                // Log the exception
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be deleted.</param>
        [HttpDelete]
        [Route("api/student/DeleteStudent")]
        public IHttpActionResult DeleteStudent()
        {
            try
            {
                Queue<Stu01> updatedStudents = _studentService.Delete();
                return Ok(updatedStudents);
            }
            catch (Exception ex)
            {
                // Log the exception
                return InternalServerError(ex);
            }
        }
    }
}
