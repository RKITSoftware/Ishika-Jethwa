using LINQDemo.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace LINQDemo.BL
{
    /// <summary>
    /// Linq with Datatble
    /// </summary>
    public static class BLDataTable
    {
        /// <summary>
        /// DataTable to store person data.
        /// </summary>
        public static DataTable personsDataTable;

        /// <summary>
        /// Static constructor to initialize the DataTable with sample data.
        /// </summary>
        static BLDataTable()
        {
            personsDataTable = new DataTable("Per01");
            personsDataTable.Columns.Add("r01f01", typeof(int));
            personsDataTable.Columns.Add("r01f02", typeof(string));
            personsDataTable.Columns.Add("r01f03", typeof(int));

            // Sample data
            personsDataTable.Rows.Add(1, "Ishika", 25);
            personsDataTable.Rows.Add(2, "Deven", 30);
            personsDataTable.Rows.Add(3, "Dimple", 25);
            personsDataTable.Rows.Add(4, "Aarti", 28);
        }

        /// <summary>
        /// Gets all persons from the DataTable.
        /// </summary>
        /// <returns>List of persons.</returns>
        public static List<Per01> GetAllPersons()
        {
            List<Per01> lstPerson = personsDataTable.AsEnumerable()
                .Select(row => new Per01
                {
                    r01f01 = row.Field<int>("r01f01"),
                    r01f02 = row.Field<string>("r01f02"),
                    r01f03 = row.Field<int>("r01f03")
                })
                .ToList();

            return lstPerson;
        }

        /// <summary>
        /// Gets a person by Id from the DataTable.
        /// </summary>
        /// <param name="id">The Id of the person to retrieve.</param>
        /// <returns>The person with the specified Id, or null if not found.</returns>
        public static Per01 GetPersonById(int id)
        {
            Per01 objPerson = personsDataTable.AsEnumerable()
                .Where(row => row.Field<int>("r01f01") == id)
                .Select(row => new Per01
                {
                    r01f01 = row.Field<int>("r01f01"),
                    r01f02 = row.Field<string>("r01f02"),
                    r01f03 = row.Field<int>("r01f03")
                }).FirstOrDefault();

            return objPerson;
        }

        /// <summary>
        /// Gets persons by age from the DataTable.
        /// </summary>
        /// <param name="age">The age to filter by.</param>
        /// <returns>List of persons with the specified age.</returns>
        public static List<Per01> GetPersonsByAge(int age)
        {
            List<Per01> lstFilterPerson = personsDataTable.AsEnumerable()
                .Where(row => row.Field<int>("r01f03") == age)
                .Select(row => new Per01
                {
                    r01f01 = row.Field<int>("r01f01"),
                    r01f02 = row.Field<string>("r01f02"),
                    r01f03 = row.Field<int>("r01f03")
                })
                .ToList();

            return lstFilterPerson;
        }

        /// <summary>
        /// Gets adult persons (age 18 and above) from the DataTable.
        /// </summary>
        /// <returns>List of adult persons.</returns>
        public static List<Per01> GetAdultPersons()
        {
            List<Per01> lstadultPersons = personsDataTable.AsEnumerable()
                .Where(row => row.Field<int>("r01f03") >= 18)
                .Select(row => new Per01
                {
                    r01f01 = row.Field<int>("r01f01"),
                    r01f02 = row.Field<string>("r01f02"),
                    r01f03 = row.Field<int>("r01f03")
                })
                .ToList();

            return lstadultPersons;
        }

        /// <summary>
        /// Adds a new person to the DataTable.
        /// </summary>
        /// <param name="objnewPerson">The new person to add.</param>
        /// <returns>The added person with an assigned Id.</returns>
        public static Per01 AddPerson(Per01 objnewPerson)
        {
            int newId = personsDataTable.AsEnumerable().Max(row => row.Field<int>("r01f01")) + 1;
            personsDataTable.Rows.Add(newId, objnewPerson.r01f02, objnewPerson.r01f03);

            Per01 objaddedPerson = new Per01
            {
                r01f01 = newId,
                r01f02 = objnewPerson.r01f02,
                r01f03 = objnewPerson.r01f03
            };

            return objaddedPerson;
        }

        /// <summary>
        /// Performs an INNER JOIN between two DataTables based on a common property.
        /// </summary>
        /// <param name="dataTable">The DataTable to join with.</param>
        /// <param name="commonColumn">The common column for the INNER JOIN.</param>
        /// <returns>The result of the INNER JOIN operation.</returns>
        public static DataTable InnerJoinWith(DataTable anothertable)
        {
            var query = from row1 in personsDataTable.AsEnumerable()
                        join row2 in anothertable.AsEnumerable()
                        on row1.Field<int>("r01f01") equals row2.Field<int>("r01f01")
                        select new
                        {
                            r01f01 = row1.Field<int>("r01f01"),
                            r01f02 = row1.Field<string>("r01f02"),
                            r01f03 = row2.Field<int>("r02f03")
                        };

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("r01f01");
            resultTable.Columns.Add("r01f02");
            resultTable.Columns.Add("r02f03");

            foreach (var item in query)
            {
                resultTable.Rows.Add(item.r01f01, item.r01f02, item.r01f03);
            }
            return resultTable;
        }

        /// <summary>
        /// Performs a RIGHT JOIN between two DataTables based on a common property.
        /// </summary>
        /// <param name="dataTable">The DataTable to right join with.</param>
        /// <param name="commonColumn">The common column for the RIGHT JOIN.</param>
        /// <returns>The result of the RIGHT JOIN operation.</returns>
        public static DataTable RightJoinWith(DataTable anothertable)
        {
            var query = from row1 in personsDataTable.AsEnumerable()
                        join row2 in anothertable.AsEnumerable()
                        on row1.Field<int>("r01f01") equals row2.Field<int>("r01f01") into joinGroup
                        from row2 in joinGroup.DefaultIfEmpty()
                        select new
                        {
                            r01f01 = row1.Field<int>("r01f01"),
                            r01f02 = row1.Field<string>("r01f02"),
                            r01f03 = (row2 == null) ? default(int) : row2.Field<int>("r01f03")
                        };

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("r01f01");
            resultTable.Columns.Add("r01f02");
            resultTable.Columns.Add("r01f03");

            foreach (var item in query)
            {
                resultTable.Rows.Add(item.r01f01, item.r01f02, item.r01f03);
            }
            return resultTable;
        }

        /// <summary>
        /// Checks if a row with a specific value in a specific column exists in the DataTable.
        /// </summary>
        /// <param name="value">The value to check for.</param>
        /// <param name="columnName">The column to check in.</param>
        /// <returns>True if the row exists; otherwise, false.</returns>
        public static bool RowExists(string value, string columnName)
        {
            return personsDataTable.AsEnumerable().Any(row => row.Field<string>(columnName) == value);
        }

        /// <summary>
        /// Gets the people who are not in another DataTable.
        /// </summary>
        /// <param name="dataTable">The DataTable to compare with.</param>
        /// <returns>The people who are not in the other DataTable.</returns>
        public static DataTable GetPeopleNotInTable(DataTable dataTable)
        {
            DataTable query = personsDataTable.AsEnumerable().Except(dataTable.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
           // DataTable resultTable = personsDataTable.Clone();

            

            return query;
        }

        /// <summary>
        /// Groups the DataTable by a specific column.
        /// </summary>
        /// <param name="columnName">The column to group by.</param>
        /// <returns>The grouped result.</returns>
        public static DataTable GroupByColumn(string columnName)
        {
            var query = from row in personsDataTable.AsEnumerable()
                        group row by row.Field<object>(columnName) into grp
                        select grp;

            DataTable resultTable = personsDataTable.Clone();

            foreach (var group in query)
            {
                foreach (var row in group)
                {
                    resultTable.ImportRow(row);
                }
            }

            return resultTable;
        }
    }
}
