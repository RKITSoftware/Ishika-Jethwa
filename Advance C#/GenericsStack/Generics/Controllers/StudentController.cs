using Generics.IService;
using Generics.Models;
using Generics.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Generics.Controllers
{
    public class StudentController : ApiController
    {
        private static IGenericService<Stu01> _studentService = new BLStudentService();

        /// <summary>
        /// Gets all students.
        /// </summary>
        [HttpGet]
        [Route("api/student")]
        public IHttpActionResult GetStudents()
        {
            try
            {
                Stack<Stu01> students = _studentService.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student.</param>
        [HttpGet]
        [Route("api/student/{id}")]
        public IHttpActionResult GetStudent(int id)
        {
            try
            {
                Stu01 student = _studentService.GetById(id);

                if (student == null)
                    return NotFound();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="student">The student to be added.</param>
        [HttpPost]
        [Route("api/student/AddStudent")]
        public IHttpActionResult AddStudent([FromBody] Stu01 objStudent)
        {
            try
            {
                Stack<Stu01> updatedStudents = _studentService.Insert(objStudent);
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
                Stack<Stu01> updatedStudents = _studentService.Delete();
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
