using System.Collections.Generic;

namespace Generics.Service
{
    public class BLStudentService<T> 
    {
        Queue<T> queStudent = new Queue<T>();

        /// <summary>
        /// Deletes a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be deleted.</param>
        /// <returns>A Stack of students after the deletion operation.</returns>
        public Queue<T> Delete()
        {
            queStudent.Dequeue();
            return queStudent;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A Stack of all students.</returns>
        public Queue<T> GetAll()
        {
            return queStudent;
        }

        /// <summary>
        /// Inserts a new student.
        /// </summary>
        /// <param name="entity">The student to be inserted.</param>
        /// <returns>A Stack of students after the insertion operation.</returns>
        public Queue<T> Insert(T entity)
        {
            queStudent.Enqueue(entity);
            return queStudent;
        }
    }
}
