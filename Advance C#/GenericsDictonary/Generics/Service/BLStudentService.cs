using Generics.IService;
using Generics.Models;
using System.Collections.Generic;

namespace Generics.Service
{
    public class BLStudentService : IGenericService<Stu01>
    {
        private Dictionary<int, Stu01> dictStudents = new Dictionary<int, Stu01>();

        /// <summary>
        /// Initializes the student dictionary with sample data.
        /// </summary>
        public BLStudentService()
        {
            for (int i = 1; i < 10; i++)
            {
                Stu01 student = new Stu01()
                {
                    u01f01 = i,
                    u01f02 = "Stu" + i,
                    u01f03 = "100" + i
                };

                dictStudents.Add(student.u01f01, student);
            }
        }

        /// <summary>
        /// Deletes a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be deleted.</param>
        /// <returns>A Dictionary of students after the deletion operation.</returns>
        public Dictionary<int, Stu01> Delete(int id)
        {
            // Remove the student with the specified id from the dictionary
            dictStudents.Remove(id);
            return dictStudents;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A Dictionary of all students.</returns>
        public Dictionary<int, Stu01> GetAll()
        {
            return new Dictionary<int, Stu01>(dictStudents);
        }

        /// <summary>
        /// Gets a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be retrieved.</param>
        /// <returns>The student with the specified identifier.</returns>
        public Stu01 GetById(int id)
        {
            if (dictStudents.TryGetValue(id, out Stu01 objStudent))
            {
                return objStudent;
            }

            return null; // Return null if the student is not found
        }

        /// <summary>
        /// Inserts a new student.
        /// </summary>
        /// <param name="entity">The student to be inserted.</param>
        /// <returns>A Dictionary of students after the insertion operation.</returns>
        public Dictionary<int, Stu01> Insert(Stu01 objStudent)
        {
            // Generate a unique identifier for the student (replace this logic as needed)
            int newId = dictStudents.Count + 1;

            objStudent.u01f01 = newId;
            dictStudents.Add(newId, objStudent);
            return dictStudents;
        }
    }
}
