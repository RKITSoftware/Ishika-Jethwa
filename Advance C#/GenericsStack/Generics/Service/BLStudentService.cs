using Generics.IService;
using Generics.Models;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Service
{
    /// <summary>
    /// Service class for managing operations related to students.
    /// </summary>
    public class BLStudentService : IGenericService<Stu01>
    {
       public static  Stack<Stu01> stackStudent;

        /// <summary>
        /// Initializes the student stack with sample data.
        /// </summary>
        public BLStudentService()
        {
            stackStudent = new Stack<Stu01>();
            for (int i = 1; i < 10; i++)
            {
                stackStudent.Push(new Stu01()
                {
                    u01f01 = i,
                    u01f02 = "Stu" + i,
                    u01f03 = "100" + i
                });
            }
        }

        /// <summary>
        /// Deletes a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be deleted.</param>
        /// <returns>A Stack of students after the deletion operation.</returns>
        public Stack<Stu01> Delete()
        { 
            stackStudent.Pop();
             new Stack<Stu01>(stackStudent);
            return stackStudent;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A Stack of all students.</returns>
        public Stack<Stu01> GetAll()
        {
            new Stack<Stu01>(stackStudent);
            return stackStudent;
        }

        /// <summary>
        /// Gets a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be retrieved.</param>
        /// <returns>The student with the specified identifier.</returns>
        public Stu01 GetById(int id)
        {
            return stackStudent.FirstOrDefault(x => x.u01f01 == id);
        }

        /// <summary>
        /// Inserts a new student.
        /// </summary>
        /// <param name="entity">The student to be inserted.</param>
        /// <returns>A Stack of students after the insertion operation.</returns>
        public Stack<Stu01> Insert(Stu01 objStudent)
        {
            stackStudent.Push(objStudent);
            new Stack<Stu01>(stackStudent);
            return stackStudent;
        }
    }
}
