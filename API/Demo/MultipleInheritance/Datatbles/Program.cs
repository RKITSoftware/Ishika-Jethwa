using System;
using System.Data;


namespace Datatbles
{
    /// <summary>
    /// This program demonstrates the creation and usage of a DataTable in C#.
    /// It creates a DataTable named "MyTable," adds columns (ID, Name, Age, Status), and adds two rows of data.
    /// The DisplayDataTable method is used to print the contents of the DataTable with only active rows to the console.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Displays the content of a DataTable with only active rows.
        /// </summary>
        ///<param name="dataTable"></param>
        static void DisplayDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                // Check if the Status is "Active" before displaying the row
                if (row["Status"].ToString().Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]}   ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            // Create a DataTable
            DataTable dataTable = new DataTable("MyTable");

            // Add columns to the DataTable
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Columns.Add("Status", typeof(string));

            // Add rows to the DataTable
            dataTable.Rows.Add(1, "John", 25, "Active");
            dataTable.Rows.Add(2, "Jane", 30, "Inactive");
            dataTable.Rows.Add(1, "Jena", 35, "Active");
            dataTable.Rows.Add(2, "Joan", 40, "Inactive");

            // Display the DataTable
            DisplayDataTable(dataTable);

            Console.ReadLine();
        }
    }
}
