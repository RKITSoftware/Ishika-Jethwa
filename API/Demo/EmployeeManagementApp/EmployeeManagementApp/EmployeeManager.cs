using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagementApp
{
    /// <summary>
    /// Class to manage employees and perform various operations.
    /// </summary>
    /// 

    public class EmployeeManager
    {
        public List<Employee> lstEmployees = new List<Employee>();

        #region Public Methods
        /// <summary>
        /// Adds an employee to the manager.
        /// </summary>
        /// <param name="employee">The employee to add.</param>

        public void AddEmployee(Employee objEmployee)
        {
            lstEmployees.Add(objEmployee);
        }

        /// <summary>
        /// Displays information for all employees.
        /// </summary>
        public void DisplayAllEmployees()
        {
            Console.WriteLine("All Employees:");
            EmployeeDisplay objEmployee = new EmployeeDisplay();
            objEmployee.DisplayInfo(lstEmployees);
        }

        /// <summary>
        /// Adds a new employee to the employee manager.
        /// </summary>
        public void AddEmployeeOperation()
        {
            // Prompt user to enter employee details
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            // Create new employee and add to the manager
            Employee newEmployee = new Employee { FirstName = firstName, LastName = lastName, EmployeeId = employeeId, Department = department };
            AddEmployee(newEmployee);

            Console.WriteLine("Employee added successfully.");
        }

        /// <summary>
        /// Removes an employee from the employee manager.
        /// </summary>
        public void RemoveEmployeeOperation()
        {
            // Prompt user to enter employee ID to remove
            Console.Write("Enter Employee ID to remove: ");
            int employeeIdToRemove = int.Parse(Console.ReadLine());

            // Find and remove employee with the specified ID
            Employee employeeToRemove = lstEmployees.Find(e => e.EmployeeId == employeeIdToRemove);
            if (employeeToRemove != null)
            {
                lstEmployees.Remove(employeeToRemove);
                Console.WriteLine($"Employee with ID {employeeIdToRemove} removed successfully.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeIdToRemove} not found.");
            }
        }

        /// <summary>
        /// Writes employee details to a file.
        /// </summar>
        public void WriteToFile()
        {
            Console.Write("Enter the file Name to write this employee details: ");
            string fileName = Console.ReadLine();

            // Get the current directory of the application
            string projectDirectory = Directory.GetCurrentDirectory();

            // Combine the project directory  the provided file name
            string filePath = Path.Combine(projectDirectory, fileName);

            Console.WriteLine(filePath);

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (Employee employee in lstEmployees)
                {
                    sw.WriteLine($"{employee.FirstName},{employee.LastName},{employee.EmployeeId},{employee.Department}");
                }
                Console.WriteLine("File Created");
            }

        }
        /// <summary>
        /// Reads employee details from a file and displays them.
        /// </summary>
        public void ReadFromFile()
        {
            Console.Write("Enter the file path for Reading: ");
            string path = Console.ReadLine();
            // Open the file to read 
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                //check availability of file
                if (File.Exists(path))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist!");
                }
            }
        }
        /// <summary>
        /// Deletes a file based on user confirmation.
        /// </summary>
        public void DeleteFile()
        {
            Console.Write("Are you sure you want to delete the file? (y/n): ");
            string response = Console.ReadLine().ToLower();

            if (response == "y")
            {
                Console.Write("Enter the file path to delete: ");
                string filePath = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("File deleted successfully.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            else
            {
                Console.WriteLine("File deletion canceled.");
            }
        }

        #endregion
    }

}
