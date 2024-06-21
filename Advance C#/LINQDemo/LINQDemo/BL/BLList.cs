using LINQDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo.BL
{
    public static class BLList
    {
        /// <summary>
        /// List of people.
        /// </summary>
        public static List<Per01> lstpeople = new List<Per01>
        {
            new Per01 { r01f01 = 2, r01f02 = "Jethwa", r01f03 = 0 },
            new Per01 { r01f01 = 1, r01f02 = "Deven", r01f03 = 22 },
            new Per01 { r01f01 = 3, r01f02 = "krishna", r01f03 = 98 },
            new Per01 { r01f01 = 7, r01f02 = "ganesh", r01f03 = 30 },
             new Per01 { r01f01 = 6, r01f02 = "krishna", r01f03 = 30 }

        };

        /// <summary>
        /// Gets the list of people, ordered by Id.
        /// </summary>
        /// <returns>The ordered list of people.</returns>
        public static List<Per01> GetList()
        {
            IEnumerable<Per01> query = from person in lstpeople
                                       select new Per01
                                       {
                                           r01f01 = person.r01f01,
                                           r01f02 = person.r01f02,
                                           r01f03 = person.r01f03
                                       };

            return query.OrderBy(person => person.r01f01).ToList();
        }

        /// <summary>
        /// Gets a person by their Id.
        /// </summary>
        /// <param name="id">The Id of the person to retrieve.</param>
        /// <returns>The person with the specified Id, or null if not found.</returns>
        public static Per01 GetByID(int id)
        {
            return lstpeople.FirstOrDefault(p => p.r01f01 == id);
        }

        /// <summary>
        /// Adds a new person to the list.
        /// </summary>
        /// <param name="objPerson">The person to add.</param>
        /// <returns>The added person with an assigned Id.</returns>
        public static Per01 AddPerson(Per01 objPerson)
        {
            int newId = lstpeople.Max(p => p.r01f01) + 1;
            objPerson.r01f01 = newId;

            lstpeople.Add(objPerson);
            return objPerson;
        }

        /// <summary>
        /// Removes a person from the list.
        /// </summary>
        /// <param name="objPerson">The person to remove.</param>
        public static void Remove(Per01 objPerson)
        {
            lstpeople.Remove(objPerson);
        }

        /// <summary>
        /// Calculates the average of the ages of all people in the list.
        /// </summary>
        /// <returns>The average age.</returns>
        public static double GetAvg()
        {
            return lstpeople.Average(p => p.r01f03);
        }

        /// <summary>
        /// Performs an INNER JOIN between two lists based on a common property.
        /// </summary>
        /// <param name="otherList">The list to join with.</param>
        /// <returns>The result of the INNER JOIN operation.</returns>
        /// 
        public static List<Per01> InnerJoinWith(List<Per01> otherList)
        {
            var query = lstpeople.Join(
                otherList,
                person => person.r01f01,
                otherPerson => otherPerson.r01f01,
                (person, otherPerson) => new Per01
                {
                    r01f01 = person.r01f01,
                    r01f02 = person.r01f02 + " " + otherPerson.r01f02,
                    r01f03 =  otherPerson.r01f03
                });

            return query.ToList();
        }


        /// <summary>
        /// Checks if a person with a specific Id exists in the list.
        /// </summary>
        /// <param name="id">The Id to check for.</param>
        /// <returns>True if the person exists; otherwise, false.</returns>
        public static bool PersonExists(int id)
        {
            return lstpeople.Any(person => person.r01f01 == id);
        }

        /// <summary>
        /// Gets the people who are not in another list.
        /// </summary>
        /// <param name="otherList">The list to compare with.</param>
        /// <returns>The people who are not in the other list.</returns>

        public static List<Per01> GetPeopleNotInList(List<Per01> otherList)
        {
            var query = lstpeople
                .Except(otherList, new PersonComparer())
                .GroupBy(person => person.r01f02)
                //.SelectMany(group => group)
                .Select(group => group.First()) // Select the first item from each group
                .ToList();

            return query;
        }

        public static List<RightJoinResult> RightJoin(List<Per01> otherList)
        {
            var rightJoinQuery = from otherPerson in otherList
                                 join person in lstpeople
                                 on otherPerson.r01f01 equals person.r01f01 into rj
                                 from subPerson in rj.DefaultIfEmpty()
                                 select new RightJoinResult // Replace SomeType with the actual type you want to return
                                 {
                                     OtherPerson = otherPerson,
                                     Person = subPerson
                                 };

            // Convert the result to a list
            var rightJoinResult = rightJoinQuery.ToList();
            return rightJoinResult;
        }


    }
}
