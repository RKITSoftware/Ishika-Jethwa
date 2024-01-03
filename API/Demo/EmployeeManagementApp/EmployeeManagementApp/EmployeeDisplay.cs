using System;
using System.Collections.Generic;
using System.Data;


namespace EmployeeManagementApp
{
    /// <summary>
    /// Derived class representing an employee with additional properties.
    /// </summary>

   
    public class EmployeeDisplay 
    {
        #region public method
        /// <summary>
        /// Display information about an employee using DataTable.
        /// </summary>
        /// <param name="employees">List of employees to display information for.</param>
        public void DisplayInfo(List<Employee> lstEmployees)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("First Name");
            dataTable.Columns.Add("Last Name");
            dataTable.Columns.Add("Employee ID");
            dataTable.Columns.Add("Department");

            foreach (Employee employee in lstEmployees)
            {
                dataTable.Rows.Add(employee.FirstName, employee.LastName, employee.EmployeeId, employee.Department);
            }

            Console.WriteLine("Employee information displayed through DataTable:");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Name : {row["First Name"]} {row["Last Name"]}, ID: {row["Employee ID"]}, Department: {row["Department"]}");
            }
        }
        #endregion
    }


}
