using EmployeeManagementApp;
using System;


class Program
{

    static void Main()
    {
        try
        {
            // Creating instances of the classes
            EmployeeManager objEmployeeManager = new EmployeeManager();

            // Adding employees
            objEmployeeManager.AddEmployee(new Employee { FirstName = "Ishika", LastName = "Jethwa", EmployeeId = 1, Department = "IT" });
            objEmployeeManager.AddEmployee(new Employee { FirstName = "Deven", LastName = "Jethwa", EmployeeId = 2, Department = "HR" });


            // Operations menu
            Console.WriteLine("Operations:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Display Employees through DataTable");
            Console.WriteLine("4. Write to File");
            Console.WriteLine("5. Read from File");
            Console.WriteLine("6. Delete File");
            while (true)
            {
                Console.ReadLine();
                Console.Write("Enter the operation number: ");
                int operation = Convert.ToInt32(Console.ReadLine());
                // Perform operations based on user input
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Enter employee details:");
                        // Add Employee operation
                        objEmployeeManager.AddEmployeeOperation();
                        break;
                    case 2:
                        // Remove Employee operation
                        objEmployeeManager.RemoveEmployeeOperation();
                        break;
                    case 3:
                        // Display Employees through DataTable operation
                        objEmployeeManager.DisplayAllEmployees();
                        break;
                    case 4:
                        // Write to File operation
                        objEmployeeManager.WriteToFile();
                        break;
                    case 5:
                        // Read from File operation
                        objEmployeeManager.ReadFromFile();
                        break;
                    case 6:
                        // Delete File operation
                        objEmployeeManager.DeleteFile();
                        break;
                    case 7:
                        //Exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid operation number.");
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
        Console.ReadLine();
    }
}

